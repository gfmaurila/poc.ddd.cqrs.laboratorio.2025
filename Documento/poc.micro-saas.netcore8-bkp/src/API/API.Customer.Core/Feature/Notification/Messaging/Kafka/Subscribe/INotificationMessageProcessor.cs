namespace API.Customer.Core.Feature.Notification.Messaging.Kafka.Subscribe;

public interface INotificationMessageProcessor
{
    Task ProcessMessageAsync(string message);
}
