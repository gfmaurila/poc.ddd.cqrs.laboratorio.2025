using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Events;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Events;

public abstract class ExempleBaseEvent : Event
{
    public Guid Id { get; private init; }
    public string FirstName { get; private init; }
    public string LastName { get; private init; }
    public EGender Gender { get; private init; }
    public ENotificationType Notification { get; private init; }
    public string Email { get; private init; }
    public string Phone { get; private init; }
    public List<string> Role { get; private init; } = new List<string>();
    public ExempleBaseEvent(Guid id, string firstName, string lastName, EGender gender, ENotificationType notification, string email, string phone, List<string> role)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Notification = notification;
        Email = email;
        Phone = phone;
        Role = role;
    }
}
