using API.Customer.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.Customer.Core.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;

public interface IUpdateExemplePublish
{
    void PublishAsync(ExempleUpdateEvent events);
}
