using API.External.Person.Feature.Notification.Messaging.Request;

namespace API.External.Person.Feature.Notification.Messaging.Service;

public interface INotificationService
{
    Task NotificationAsync(NotificationRequest dto);
}
