using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Update;

public class UpdateExempleCommandHandler : IRequestHandler<UpdateExempleCommand, ApiResult<UpdateExempleResponse>>
{
    private readonly UpdateExempleCommandValidator _validator;
    private readonly IExempleRepository _repo;
    private readonly ILogger<UpdateExempleCommandHandler> _logger;
    private readonly IMediator _mediator;
    public UpdateExempleCommandHandler(ILogger<UpdateExempleCommandHandler> logger,
                                    IExempleRepository repo,
                                    UpdateExempleCommandValidator validator,
                                    IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }
    public async Task<ApiResult<UpdateExempleResponse>> Handle(UpdateExempleCommand request, CancellationToken cancellationToken)
    {
        // Validanto a requisição.
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ApiResult<UpdateExempleResponse>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);

        // Obtendo o registro da base.
        var entity = await _repo.Get(request.Id);
        if (entity == null)
            return ApiResult<UpdateExempleResponse>.CreateError(
                new List<ErrorDetail> {
                    new ErrorDetail($"Nenhum registro encontrado pelo Id: {request.Id}")
                },
                400);

        var authModel = new AuthExempleCreateUpdateDeleteModel(entity.DtInsert,
                                                               entity.DtInsertId,
                                                               entity.DtUpdate ?? DateTime.Now,
                                                               entity.DtUpdateId ?? 0,
                                                               entity.DtDelete,
                                                               entity.DtDeleteId);

        entity.Update(request, authModel);

        await _repo.Update(entity);

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return ApiResult<UpdateExempleResponse>.CreateSuccess(new UpdateExempleResponse(entity.Id), "Atualizado com sucesso!");
    }
}
