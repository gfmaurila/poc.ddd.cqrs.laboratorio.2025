using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Events;

namespace API.Exemple.Core._08.Feature.Notification.Messaging.RabbiMQ.Events;

public class NotificationEvent : Event
{
    public NotificationEvent(ENotificationType notificationType, string from, string body, string to)
    {
        NotificationType = notificationType;
        From = from;
        Body = body;
        To = to;
    }

    public int Id { get; private set; }
    public ENotificationType NotificationType { get; private set; }
    public string From { get; private set; }
    public string Body { get; private set; }
    public string To { get; private set; }
}
