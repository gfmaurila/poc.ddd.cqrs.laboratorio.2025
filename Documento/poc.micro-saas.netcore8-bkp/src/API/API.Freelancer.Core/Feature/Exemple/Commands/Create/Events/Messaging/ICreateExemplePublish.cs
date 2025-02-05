using API.Freelancer.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.Freelancer.Core.Feature.Exemple.Commands.Create.Events.Messaging;

public interface ICreateExemplePublish
{
    void PublishAsync(ExempleCreateEvent events);
}
