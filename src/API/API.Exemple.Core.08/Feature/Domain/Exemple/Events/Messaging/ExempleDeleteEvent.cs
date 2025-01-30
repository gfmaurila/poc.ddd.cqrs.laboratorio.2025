using API.Exemple.Core._08.Feature.Domain.Exemple.Events;
using Common.Core._08.Domain.Enumerado;

namespace API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;

public class ExempleDeleteEvent : ExempleBaseEvent
{
    public ExempleDeleteEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, List<string> role) :
        base(id, firstName, lastName, gender, notification, email, phone, role)
    {
    }
}
