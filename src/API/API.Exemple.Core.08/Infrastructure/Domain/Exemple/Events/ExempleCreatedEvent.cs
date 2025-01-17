using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.ValueObjects;

namespace API.Exemple.Core._08.Infrastructure.Domain.Exemple.Events;

public class ExempleCreatedEvent : ExempleBaseEvent
{
    public ExempleCreatedEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, List<string> role) :
        base(id, firstName, lastName, gender, notification, email, phone, role)
    {
    }
}
