using API.Customer.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.Customer.Core.Feature.Exemple.Commands.Create.Events.Messaging;

public interface ICreateExemplePublish
{
    void PublishAsync(ExempleCreateEvent events);
}
