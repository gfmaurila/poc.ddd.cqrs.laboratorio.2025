using API.HR.Core.Feature.Notification.Messaging.Request;

namespace API.HR.Core.Feature.Notification.Messaging.Service;

public interface INotificationService
{
    Task NotificationAsync(NotificationRequest dto);
}
