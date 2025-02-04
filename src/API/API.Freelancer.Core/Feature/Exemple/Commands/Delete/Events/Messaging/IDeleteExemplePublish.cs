using API.Freelancer.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.Freelancer.Core.Feature.Exemple.Commands.Delete.Events.Messaging;

public interface IDeleteExemplePublish
{
    void PublishAsync(ExempleDeleteEvent events);
}
