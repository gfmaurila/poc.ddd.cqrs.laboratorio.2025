using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Events;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Producer;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Notification;

public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, ApiResult<CreateNotificationResponse>>
{
    private readonly ILogger<CreateNotificationCommandHandler> _logger;
    private readonly IMediator _mediator;
    private readonly INotificationProducer _producer;
    public CreateNotificationCommandHandler(ILogger<CreateNotificationCommandHandler> logger,
                                            IMediator mediator,
                                            INotificationProducer producer)
    {
        _logger = logger;
        _mediator = mediator;
        _producer = producer;
    }
    public async Task<ApiResult<CreateNotificationResponse>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        _producer.PublishAsync(new NotificationEvent(request.Notification, request.From, request.Body, request.To));
        return ApiResult<CreateNotificationResponse>.CreateSuccess(new CreateNotificationResponse(Guid.NewGuid()), "Mensagem enviada");
    }
}
