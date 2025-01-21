using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Update;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;

public class ExempleUpdateRabbitMQEvent : ExempleBaseEvent
{
    public ExempleUpdateRabbitMQEvent(Guid id,
                                      UpdateExempleCommand request,
                                      AuthExempleCreateUpdateDeleteModel model) :
        base(id, request.FirstName, request.LastName, request.Gender, request.Notification, request.Email, request.Phone, request.Role, request.Status, model)
    {
    }
}
