using API.External.Person.Feature.Notification.Messaging.Events;

namespace API.External.Person.Feature.Notification.Messaging.RabbiMQ;

public interface INotificationRabbiMQPublish
{
    void PublishAsync(NotificationEvent events);
}
