using API.External.Person.Feature.Domain.Exemple.Events.Messaging;

namespace API.External.Person.Feature.Exemple.Commands.Create.Events.Messaging;

public interface ICreateExemplePublish
{
    void PublishAsync(ExempleCreateEvent events);
}
