using API.Exemple.Core._08.Infrastructure.Domain.Exemple.Events;
using Common.Core._08.Domain;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain.ValueObjects;

namespace API.Exemple.Core._08.Infrastructure.Domain.Exemple;

public class ExempleEntity : BaseEntity, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public EGender Gender { get; private set; }
    public ENotificationType Notification { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber Phone { get; private set; }

    /// <summary>
    /// ERole.cs
    /// RoleConstants.cs
    /// </summary>
    public List<string> Role { get; private set; } = new List<string>();



    public ExempleEntity() { } // ORM

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="gender"></param>
    /// <param name="notification"></param>
    /// <param name="email"></param>
    /// <param name="phone"></param>
    /// <param name="role"></param>
    public ExempleEntity(string firstName, string lastName, EGender gender, ENotificationType notification, Email email, PhoneNumber phone, List<string> role)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Notification = notification;
        Email = email;
        Phone = phone;
        Role = role;
        AddDomainEvent(new ExempleCreatedEvent(Id, firstName, lastName, gender, notification, email.Address, phone.Phone, role));
    }
}
