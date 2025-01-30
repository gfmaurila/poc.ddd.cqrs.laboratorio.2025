using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Events;
using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Producer;
using API.Exemple1.Core._08.Infrastructure.Messaging.Kafka;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Notification;

public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, ApiResult<CreateNotificationResponse>>
{
    private readonly ILogger<CreateNotificationCommandHandler> _logger;
    private readonly IMediator _mediator;
    private readonly INotificationProducer _producer;
    private readonly IKafkaProducer _kafkaProducer;
    public CreateNotificationCommandHandler(ILogger<CreateNotificationCommandHandler> logger,
                                            IMediator mediator,
                                            INotificationProducer producer,
                                            IKafkaProducer kafkaProducer)
    {
        _logger = logger;
        _mediator = mediator;
        _producer = producer;
        _kafkaProducer = kafkaProducer;
    }
    public async Task<ApiResult<CreateNotificationResponse>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        // Kafka
        _logger.LogInformation("CreateNotificationCommand => Kafka");
        _kafkaProducer.PublishAsync(new NotificationEvent(request.Notification, request.From, request.Body, request.To));

        // RabbiMQ
        _logger.LogInformation("CreateNotificationCommand => RabbiMQ");
        _producer.PublishAsync(new NotificationEvent(request.Notification, request.From, request.Body, request.To));
        return ApiResult<CreateNotificationResponse>.CreateSuccess(new CreateNotificationResponse(Guid.NewGuid()), "Mensagem enviada");
    }
}
