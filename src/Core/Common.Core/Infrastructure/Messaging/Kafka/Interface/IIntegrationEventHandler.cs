using Common.Core.CommonCore.Events;

namespace Common.Core.Infrastructure.Messaging.Kafka.Interface;

public interface IIntegrationEventHandler<TEvent> where TEvent : IntegrationEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
}