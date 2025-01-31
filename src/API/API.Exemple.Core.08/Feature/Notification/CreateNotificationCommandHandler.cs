using API.Exemple.Core._08.Feature.Notification.Messaging.Kafka.Publish;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Publish;
using API.Exemple1.Core._08.Feature.Notification.Messaging.Events;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Notification;

public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, ApiResult<CreateNotificationResponse>>
{
    private readonly ILogger<CreateNotificationCommandHandler> _logger;
    private readonly INotificationRabbiMQPublish _producer;
    private readonly INotificationKafkaPublish _producerKafka;
    public CreateNotificationCommandHandler(ILogger<CreateNotificationCommandHandler> logger,
                                            INotificationRabbiMQPublish producer,
                                            INotificationKafkaPublish producerKafka)
    {
        _logger = logger;
        _producer = producer;
        _producerKafka = producerKafka;
    }
    public async Task<ApiResult<CreateNotificationResponse>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        // Kafka
        _logger.LogInformation("CreateNotificationCommand => Kafka");
        await _producerKafka.PublishAsync(new NotificationEvent(request.Notification, $"Kafka => {request.From}", $"Kafka => {request.Body}", request.To, Guid.NewGuid()));

        // RabbiMQ
        _logger.LogInformation("CreateNotificationCommand => RabbiMQ");
        _producer.PublishAsync(new NotificationEvent(request.Notification, request.From, request.Body, request.To, Guid.NewGuid()));
        return ApiResult<CreateNotificationResponse>.CreateSuccess(new CreateNotificationResponse(Guid.NewGuid()), "Mensagem enviada");
    }
}
