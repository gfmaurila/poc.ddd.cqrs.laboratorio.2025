using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Interface;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Get;

public class GetExempleQueryHandler : IRequestHandler<GetExempleQuery, ApiResult<List<ExempleQueryModel>>>
{
    private readonly IExempleRepository _repo;
    private readonly IRedisCacheService<List<ExempleQueryModel>> _cacheService;
    public GetExempleQueryHandler(IExempleRepository repo, IRedisCacheService<List<ExempleQueryModel>> cacheService)
    {
        _repo = repo;
        _cacheService = cacheService;
    }

    public async Task<ApiResult<List<ExempleQueryModel>>> Handle(GetExempleQuery request, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetExempleQuery);
        var users = await _cacheService.GetOrCreateAsync(cacheKey, () => _repo.GetAllAsync(), TimeSpan.FromHours(2));

        if (users is not null && users.Any())
            return ApiResult<List<ExempleQueryModel>>.CreateSuccess(users, "Registros recuperados com sucesso.");

        return ApiResult<List<ExempleQueryModel>>.CreateSuccess(new List<ExempleQueryModel>(), "Nenhum registro encontrado.");
    }
}
