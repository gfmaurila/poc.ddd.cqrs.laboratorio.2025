using API.HR.Core.Feature.Domain.Exemple.Events.Messaging;

namespace API.HR.Core.Feature.Exemple.Commands.Update.Events.Messaging.RabbiMQ;

public interface IUpdateExemplePublish
{
    void PublishAsync(ExempleUpdateEvent events);
}
