using API.HR.Core.Feature.Notification.Messaging.Events;

namespace API.HR.Core.Feature.Notification.Messaging.Kafka;

public interface INotificationKafkaPublish
{
    Task PublishAsync(NotificationEvent notification);
}
