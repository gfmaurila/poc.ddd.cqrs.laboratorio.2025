using Common.Core._08.Domain.Enumerado;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events;

public class ExempleDeleteDomainEvent : ExempleBaseEvent
{
    public ExempleDeleteDomainEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, List<string> role) :
        base(id, firstName, lastName, gender, notification, email, phone, role)
    {
    }
}
