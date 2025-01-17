using API.Exemple.Core._08.Feature.Domain.Exemple.Events;
using API.Exemple.Core._08.Feature.Exemple.Update;
using Common.Core._08.Domain;
using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain.ValueObjects;

namespace API.Exemple.Core._08.Feature.Domain.Exemple;

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
        AddDomainEvent(new ExempleCreateDomainEvent(Id, firstName, lastName, gender, notification, email.Address, phone.Phone, role));
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="command"></param>
    public ExempleEntity(UpdateExempleCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Gender = command.Gender;
        Notification = command.Notification;
        Email = new Email(command.Email);
        Phone = new PhoneNumber(command.Phone);
        Role = command.Role;
        AddDomainEvent(new ExempleUpdateDomainEvent(Id, command.FirstName, command.LastName, command.Gender, command.Notification, command.Email, command.Phone, command.Role));
    }

    /// <summary>
    /// Delete
    /// </summary>
    public void Delete()
        => AddDomainEvent(new ExempleDeleteDomainEvent(Id, FirstName, LastName, Gender, Notification, Email.Address, Phone.Phone, Role));

}
