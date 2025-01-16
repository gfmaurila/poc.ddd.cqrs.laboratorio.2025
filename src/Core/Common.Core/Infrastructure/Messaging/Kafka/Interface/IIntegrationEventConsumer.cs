namespace Common.Core.Infrastructure.Messaging.Kafka.Interface;

public interface IIntegrationEventConsumer
{
    Task ConsumeAsync(CancellationToken cancellationToken);
}
