using API.HR.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.HR.Core.Feature.Exemple.Commands.Delete.Events.Messaging;

public interface IDeleteExemplePublish
{
    void PublishAsync(ExempleDeleteEvent events);
}
