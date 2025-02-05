using API.Freelancer.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.Freelancer.Core.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;

public interface IUpdateExemplePublish
{
    void PublishAsync(ExempleUpdateEvent events);
}
