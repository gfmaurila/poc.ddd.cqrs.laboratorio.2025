using API.Person.Feature.Notification.Messaging.Request;

namespace API.Person.Feature.Notification.Messaging.Service;

public interface INotificationService
{
    Task NotificationAsync(NotificationRequest dto);
}
