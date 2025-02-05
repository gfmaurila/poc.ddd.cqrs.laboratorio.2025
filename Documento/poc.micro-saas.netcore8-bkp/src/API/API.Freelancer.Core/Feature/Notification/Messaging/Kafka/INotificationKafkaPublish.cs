using API.Freelancer.Core.Feature.Notification.Messaging.Events;

namespace API.Freelancer.Core.Feature.Notification.Messaging.Kafka;

public interface INotificationKafkaPublish
{
    Task PublishAsync(NotificationEvent notification);
}
