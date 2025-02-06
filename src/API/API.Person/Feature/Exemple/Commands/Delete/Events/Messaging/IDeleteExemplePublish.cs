using API.Person.Feature.Domain.Exemple.Events.Messaging;

namespace API.Person.Feature.Exemple.Commands.Delete.Events.Messaging;

public interface IDeleteExemplePublish
{
    void PublishAsync(ExempleDeleteEvent events);
}
