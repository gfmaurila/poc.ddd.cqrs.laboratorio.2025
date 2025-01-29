using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Delete;

public class DeleteExempleCommandHandler : IRequestHandler<DeleteExempleCommand, ApiResult<DeleteExempleResponse>>
{
    private readonly DeleteExempleCommandValidator _validator;
    private readonly IExempleRepository _repo;
    private readonly ILogger<DeleteExempleCommandHandler> _logger;
    private readonly IMediator _mediator;
    public DeleteExempleCommandHandler(ILogger<DeleteExempleCommandHandler> logger,
                                    IExempleRepository repo,
                                    DeleteExempleCommandValidator validator,
                                    IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<ApiResult<DeleteExempleResponse>> Handle(DeleteExempleCommand request, CancellationToken cancellationToken)
    {
        // Validanto a requisição.
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ApiResult<DeleteExempleResponse>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);

        // Obtendo o registro da base.
        var entity = await _repo.Get(request.Id);
        if (entity == null)
            return ApiResult<DeleteExempleResponse>.CreateError(
                new List<ErrorDetail> {
                    new ErrorDetail($"Nenhum registro encontrado pelo Id: {request.Id}")
                },
                400);

        entity.Delete();

        await _repo.Remove(entity);

        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return ApiResult<DeleteExempleResponse>.CreateSuccess(new DeleteExempleResponse(request.Id), "Removido com sucesso!");
    }
}
