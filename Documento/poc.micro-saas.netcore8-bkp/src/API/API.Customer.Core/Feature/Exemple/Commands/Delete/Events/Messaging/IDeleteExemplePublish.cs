using API.Customer.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.Customer.Core.Feature.Exemple.Commands.Delete.Events.Messaging;

public interface IDeleteExemplePublish
{
    void PublishAsync(ExempleDeleteEvent events);
}
