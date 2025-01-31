namespace Common.Core._08.Kafka;

public interface IKafkaConsumer
{
    Task ConsumeAsync(string topic, Func<string, Task> messageHandler, CancellationToken cancellationToken);
}
