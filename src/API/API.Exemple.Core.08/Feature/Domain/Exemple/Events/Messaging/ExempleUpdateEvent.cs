using API.Exemple.Core._08.Feature.Domain.Exemple.Events;
using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Update;

namespace API.Exemple1.Core._08.Feature.Domain.Exemple.Events.Messaging;

public class ExempleUpdateEvent : ExempleBaseEvent
{
    public ExempleUpdateEvent(Guid id,
                                      UpdateExempleCommand request,
                                      AuthExempleCreateUpdateDeleteModel model) :
        base(id, request.FirstName, request.LastName, request.Gender, request.Notification, request.Email, request.Phone, request.Role, request.Status, model)
    {
    }
}
