using API.Customer.Core.Feature.Notification.Messaging.Request;

namespace API.Customer.Core.Feature.Notification.Messaging.Service;

public interface INotificationService
{
    Task NotificationAsync(NotificationRequest dto);
}
