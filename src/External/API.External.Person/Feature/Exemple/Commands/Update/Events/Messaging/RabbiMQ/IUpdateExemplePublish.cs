using API.External.Person.Feature.Domain.Exemple.Events.Messaging;

namespace API.External.Person.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;

public interface IUpdateExemplePublish
{
    void PublishAsync(ExempleUpdateEvent events);
}
