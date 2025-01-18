using Common.Core._08.Domain.Enumerado;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events;

public class ExempleCreateDomainEvent : ExempleBaseEvent
{
    public ExempleCreateDomainEvent(Guid id,
                                    string firstName,
                                    string lastName,
                                    EGender gender,
                                    ENotificationType notification,
                                    string email,
                                    string phone,
                                    List<string> role,
                                    DateTime? dtInsert,
                                    Guid? dtInsertId,
                                    DateTime? dtUpdate,
                                    Guid? dtUpdateId,
                                    DateTime? dtDelete,
                                    Guid? dtDeleteId,
                                    bool status) :
        base(id, firstName, lastName, gender, notification, email, phone, role, status, dtInsert, dtInsertId, null, null, null, null)
    {
    }
}
