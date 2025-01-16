using Common.Core.CommonCore.Events;

namespace Common.Core.Infrastructure.Messaging.Kafka.Interface;

public interface IIntegrationEventPublisher
{
    Task PublishAsync<T>(T @event) where T : IntegrationEvent;
}
