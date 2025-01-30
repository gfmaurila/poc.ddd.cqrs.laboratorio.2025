using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Publish;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Notification;

public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, ApiResult<CreateNotificationResponse>>
{
    private readonly ILogger<CreateNotificationCommandHandler> _logger;
    private readonly INotificationRabbiMQPublish _producer;
    public CreateNotificationCommandHandler(ILogger<CreateNotificationCommandHandler> logger,
                                            INotificationRabbiMQPublish producer)
    {
        _logger = logger;
        _producer = producer;
    }
    public async Task<ApiResult<CreateNotificationResponse>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        // Kafka


        // RabbiMQ
        _logger.LogInformation("CreateNotificationCommand => RabbiMQ");
        _producer.PublishAsync(new NotificationEvent(request.Notification, request.From, request.Body, request.To));
        return ApiResult<CreateNotificationResponse>.CreateSuccess(new CreateNotificationResponse(Guid.NewGuid()), "Mensagem enviada");
    }
}
