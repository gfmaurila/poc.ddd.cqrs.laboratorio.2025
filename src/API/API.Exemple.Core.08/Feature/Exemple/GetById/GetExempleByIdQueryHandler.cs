using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Interface;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.GetById;


public class GetExempleByIdQueryHandler : IRequestHandler<GetExempleByIdQuery, ApiResult<ExempleQueryModel>>
{
    private readonly IExempleRepository _repo;
    private readonly IRedisCacheService<ExempleQueryModel> _cacheService;
    private readonly GetExempleByIdQueryValidator _validator;
    public GetExempleByIdQueryHandler(IExempleRepository repo,
                                      IRedisCacheService<ExempleQueryModel> cacheService,
                                      GetExempleByIdQueryValidator validator)
    {
        _repo = repo;
        _cacheService = cacheService;
        _validator = validator;
    }

    public async Task<ApiResult<ExempleQueryModel>> Handle(GetExempleByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ApiResult<ExempleQueryModel>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);

        var cacheKey = $"{nameof(GetExempleByIdQuery)}_{request.Id}";

        var modelRedis = await _cacheService.GetAsync(cacheKey);

        // Db Redis
        if (modelRedis is not null)
            return ApiResult<ExempleQueryModel>.CreateSuccess(
                modelRedis,
                "Registro recuperado com sucesso.");

        var entity = await _repo.GetByIdAsync(request.Id);

        // DB SQL Server
        if (entity is not null)
            return ApiResult<ExempleQueryModel>.CreateSuccess(
                await _cacheService.GetOrCreateAsync(cacheKey, () => _repo.GetByIdAsync(request.Id), TimeSpan.FromHours(2)),
                "Registro recuperado com sucesso.");

        return ApiResult<ExempleQueryModel>.CreateSuccess(entity, "Nenhum registro encontrado!");
    }

}


