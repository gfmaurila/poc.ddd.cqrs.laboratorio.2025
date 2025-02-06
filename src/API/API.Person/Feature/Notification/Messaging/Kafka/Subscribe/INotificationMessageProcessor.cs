namespace API.Person.Feature.Notification.Messaging.Kafka.Subscribe;

public interface INotificationMessageProcessor
{
    Task ProcessMessageAsync(string message);
}
