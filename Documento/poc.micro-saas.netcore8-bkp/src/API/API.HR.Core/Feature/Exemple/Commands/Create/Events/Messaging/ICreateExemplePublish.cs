using API.HR.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.HR.Core.Feature.Exemple.Commands.Create.Events.Messaging;

public interface ICreateExemplePublish
{
    void PublishAsync(ExempleCreateEvent events);
}
