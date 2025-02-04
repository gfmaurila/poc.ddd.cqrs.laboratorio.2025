using API.Freelancer.Core.Feature.Notification.Messaging.Events;

namespace API.Freelancer.Core.Feature.Notification.Messaging.RabbiMQ;

public interface INotificationRabbiMQPublish
{
    void PublishAsync(NotificationEvent events);
}
