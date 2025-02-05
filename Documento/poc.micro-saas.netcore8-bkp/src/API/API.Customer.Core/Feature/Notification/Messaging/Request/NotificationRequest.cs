using Common.Core._08.Domain.Enumerado;

namespace API.Customer.Core.Feature.Notification.Messaging.Request;

public class NotificationRequest
{
    public AuthNotification Auth { get; set; }
    public string To { get; set; }
    public ENotificationType Notification { get; set; }
    public string Body { get; set; }
}
