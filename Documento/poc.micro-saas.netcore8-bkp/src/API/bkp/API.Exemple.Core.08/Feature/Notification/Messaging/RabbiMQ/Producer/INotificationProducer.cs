using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Events;

namespace API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Producer;

public interface INotificationProducer
{
    void PublishAsync(NotificationEvent events);
}
