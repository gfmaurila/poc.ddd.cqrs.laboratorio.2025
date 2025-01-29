using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Create;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;

public class ExempleCreateRabbitMQEvent : ExempleBaseEvent
{
    public ExempleCreateRabbitMQEvent(Guid id,
                                    CreateExempleCommand request,
                                    AuthExempleCreateUpdateDeleteModel model) :
        base(id, request.FirstName, request.LastName, request.Gender, request.Notification, request.Email, request.Phone, request.Role, request.Status, model)
    {
    }
}
