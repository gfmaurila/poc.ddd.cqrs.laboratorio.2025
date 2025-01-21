using API.Exemple.Core._08.Feature.Domain.Exemple.Events;
using API.Exemple.Core._08.Feature.Domain.Exemple.Events.Messaging.RabbiMQ;
using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Feature.Exemple.Create;
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

    public ExempleEntity(CreateExempleCommand request, AuthExempleCreateUpdateDeleteModel model)
    {
        var email = new Email(request.Email);
        var phone = new PhoneNumber(request.Phone);

        FirstName = request.FirstName;
        LastName = request.LastName;
        Gender = request.Gender;
        Notification = request.Notification;
        Email = email;
        Phone = phone;
        Role = request.Role;
        Status = request.Status;

        DtInsert = model.DtInsert;
        DtInsertId = model.DtInsertId;

        AddDomainEvent(new ExempleCreateDomainEvent(Id, request, model));

        // Evento que faz envio de email, whats por RabbiMQ
        AddDomainEvent(new ExempleCreateRabbitMQEvent(Id, request, model));
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="command"></param>
    public void Update(UpdateExempleCommand command, AuthExempleCreateUpdateDeleteModel model)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Gender = command.Gender;
        Notification = command.Notification;
        Email = new Email(command.Email);
        Phone = new PhoneNumber(command.Phone);
        Role = command.Role;
        DtUpdate = model.DtUpdate;
        DtUpdateId = model.DtUpdateId;
        Status = command.Status;

        AddDomainEvent(new ExempleUpdateDomainEvent(Id,
                                                    command.FirstName,
                                                    command.LastName,
                                                    command.Gender,
                                                    command.Notification,
                                                    command.Email,
                                                    command.Phone,
                                                    command.Role,
                                                    command.Status,
                                                    model));

        // Evento que faz envio de email, whats por RabbiMQ
        AddDomainEvent(new ExempleUpdateRabbitMQEvent(Id, command, model));

    }

    /// <summary>
    /// Delete
    /// </summary>
    public void Delete()
        => AddDomainEvent(new ExempleDeleteDomainEvent(Id, FirstName, LastName, Gender, Notification, Email.Address, Phone.Phone, Role));

}
