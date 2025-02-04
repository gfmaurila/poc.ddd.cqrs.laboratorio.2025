using API.External.Person.Feature.Notification.Messaging.Events;

namespace API.External.Person.Feature.Notification.Messaging.Kafka;

public interface INotificationKafkaPublish
{
    Task PublishAsync(NotificationEvent notification);
}
