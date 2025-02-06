using API.Person.Feature.Domain.Exemple.Events.Messaging;

namespace API.Person.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;

public interface IUpdateExemplePublish
{
    void PublishAsync(ExempleUpdateEvent events);
}
