using API.Person.Feature.Notification.Messaging.Events;

namespace API.Person.Feature.Notification.Messaging.RabbiMQ;

public interface INotificationRabbiMQPublish
{
    void PublishAsync(NotificationEvent events);
}
