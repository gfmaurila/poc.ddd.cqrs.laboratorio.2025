using API.Exemple.Core._08.Feature.Domain.Exemple;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Domain.ValueObjects;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.Create;

public class CreateExempleCommandHandler : IRequestHandler<CreateExempleCommand, ApiResult<CreateExempleResponse>>
{
    private readonly CreateExempleCommandValidator _validator;
    private readonly IExempleRepository _repo;
    private readonly ILogger<CreateExempleCommandHandler> _logger;
    private readonly IMediator _mediator;
    public CreateExempleCommandHandler(ILogger<CreateExempleCommandHandler> logger,
                                       IExempleRepository repo,
                                       IMediator mediator,
                                       CreateExempleCommandValidator validator)
    {
        _repo = repo;
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }
    public async Task<ApiResult<CreateExempleResponse>> Handle(CreateExempleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ApiResult<CreateExempleResponse>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);

        var email = new Email(request.Email);
        var phone = new PhoneNumber(request.Phone);

        if (await _repo.ExistsByEmailAsync(email))
            return ApiResult<CreateExempleResponse>.CreateError(
                new List<ErrorDetail> {
                    new ErrorDetail("O endereço de e-mail informado já está sendo utilizado.")
                },
                400);

        var entity = new ExempleEntity(request.FirstName,
            request.LastName,
            request.Gender,
            request.Notification,
            email,
            phone,
            request.Role);

        await _repo.Create(entity);

        // Executa DomainEvent
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);
        entity.ClearDomainEvents();

        // Executa KafkaEvent
        // Executa RabbiMQEvent

        return ApiResult<CreateExempleResponse>.CreateSuccess(new CreateExempleResponse(entity.Id), "Cadastrado com sucesso!");
    }
}
