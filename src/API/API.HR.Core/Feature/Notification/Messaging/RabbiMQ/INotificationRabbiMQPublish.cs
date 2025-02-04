using API.HR.Core.Feature.Notification.Messaging.Events;

namespace API.HR.Core.Feature.Notification.Messaging.RabbiMQ;

public interface INotificationRabbiMQPublish
{
    void PublishAsync(NotificationEvent events);
}
