using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Create;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events;

public class ExempleCreateDomainEvent : ExempleBaseEvent
{
    public ExempleCreateDomainEvent(Guid id,
                                    CreateExempleCommand request,
                                    AuthExempleCreateUpdateDeleteModel model) :
        base(id, request.FirstName, request.LastName, request.Gender, request.Notification, request.Email, request.Phone, request.Role, request.Status, model)
    {
    }
}
