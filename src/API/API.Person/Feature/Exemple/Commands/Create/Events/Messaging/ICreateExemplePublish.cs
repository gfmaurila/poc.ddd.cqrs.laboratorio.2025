using API.Person.Feature.Domain.Exemple.Events.Messaging;

namespace API.Person.Feature.Exemple.Commands.Create.Events.Messaging;

public interface ICreateExemplePublish
{
    void PublishAsync(ExempleCreateEvent events);
}
