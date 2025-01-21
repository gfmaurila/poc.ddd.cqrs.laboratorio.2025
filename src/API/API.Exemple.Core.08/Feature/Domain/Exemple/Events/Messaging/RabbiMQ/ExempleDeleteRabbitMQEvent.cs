using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Update;
using Common.Core._08.Domain.Enumerado;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;

public class ExempleDeleteRabbitMQEvent : ExempleBaseEvent
{
    public ExempleDeleteRabbitMQEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, List<string> role) :
        base(id, firstName, lastName, gender, notification, email, phone, role)
    {
    }
}
