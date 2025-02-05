using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Events;
using API.Exemple.Core._08.Infrastructure.Messaging.RabbiMQ;
using Common.Core._08.Interface;
using System.Text;
using System.Text.Json;

namespace API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Producer;

public class NotificationProducer : INotificationProducer
{
    private readonly IMessageBusService _messageBusService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<NotificationProducer> _logger;
    public NotificationProducer(IMessageBusService messageBusService, IConfiguration configuration, ILogger<NotificationProducer> logger)
    {
        _messageBusService = messageBusService;
        _configuration = configuration;
        _logger = logger;
    }

    public void PublishAsync(NotificationEvent notification)
    {
        string QUEUE_NAME = _configuration.GetValue<string>(RabbiMQConsts.QUEUENotification);
        var notificationInfoJson = JsonSerializer.Serialize(notification);
        var notificationInfoBytes = Encoding.UTF8.GetBytes(notificationInfoJson);
        _messageBusService.Publish(QUEUE_NAME, notificationInfoBytes);
    }
}
