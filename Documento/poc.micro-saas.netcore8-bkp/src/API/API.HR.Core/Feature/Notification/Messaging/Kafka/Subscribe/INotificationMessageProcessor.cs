namespace API.HR.Core.Feature.Notification.Messaging.Kafka.Subscribe;

public interface INotificationMessageProcessor
{
    Task ProcessMessageAsync(string message);
}
