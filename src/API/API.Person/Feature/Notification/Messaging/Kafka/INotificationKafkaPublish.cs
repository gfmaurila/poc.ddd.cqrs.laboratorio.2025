using API.Person.Feature.Notification.Messaging.Events;

namespace API.Person.Feature.Notification.Messaging.Kafka;

public interface INotificationKafkaPublish
{
    Task PublishAsync(NotificationEvent notification);
}
