using API.External.Person.Feature.Domain.Exemple.Events.Messaging;

namespace API.External.Person.Feature.Exemple.Commands.Delete.Events.Messaging;

public interface IDeleteExemplePublish
{
    void PublishAsync(ExempleDeleteEvent events);
}
