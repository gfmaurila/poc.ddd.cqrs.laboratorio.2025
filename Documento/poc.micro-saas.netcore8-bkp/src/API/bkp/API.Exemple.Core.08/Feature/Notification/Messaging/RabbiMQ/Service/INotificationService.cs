using API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Request;

namespace API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Service;

public interface INotificationService
{
    Task NotificationAsync(NotificationRequest dto);
}
