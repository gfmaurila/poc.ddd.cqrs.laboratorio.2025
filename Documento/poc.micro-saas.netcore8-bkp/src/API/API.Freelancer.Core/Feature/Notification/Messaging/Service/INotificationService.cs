using API.Freelancer.Core.Feature.Notification.Messaging.Request;

namespace API.Freelancer.Core.Feature.Notification.Messaging.Service;

public interface INotificationService
{
    Task NotificationAsync(NotificationRequest dto);
}
