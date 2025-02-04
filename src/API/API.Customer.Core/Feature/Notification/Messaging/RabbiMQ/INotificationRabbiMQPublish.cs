using API.Customer.Core.Feature.Notification.Messaging.Events;

namespace API.Customer.Core.Feature.Notification.Messaging.RabbiMQ;

public interface INotificationRabbiMQPublish
{
    void PublishAsync(NotificationEvent events);
}
