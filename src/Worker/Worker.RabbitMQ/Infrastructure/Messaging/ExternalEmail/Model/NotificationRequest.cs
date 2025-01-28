using Common.Core._08.Domain.Enumerado;


namespace Worker.RabbitMQ.Infrastructure.Messaging.ExternalEmail.Model;

public class NotificationRequest
{
    public AuthNotification Auth { get; set; }
    public string To { get; set; }
    public ENotificationType Notification { get; set; }
    public string Body { get; set; }
}

public class AuthNotification
{
    public string AccountSid { get; set; }
    public string AuthToken { get; set; }
    public string From { get; set; }
}
