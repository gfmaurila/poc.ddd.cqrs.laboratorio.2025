using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Domain.Enumerado;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events;

public class ExempleUpdateDomainEvent : ExempleBaseEvent
{
    public ExempleUpdateDomainEvent(Guid id,
                                    string firstName,
                                    string lastName,
                                    EGender gender,
                                    ENotificationType notification,
                                    string email,
                                    string phone,
                                    List<string> role,
                                    bool status,
                                    AuthExempleCreateUpdateDeleteModel model) :
        base(id, firstName, lastName, gender, notification, email, phone, role, status, model)
    {
    }
}
