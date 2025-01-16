using Common.Core.Domain;
using Common.Core.Domain.Enumerado;
using Common.Core.Domain.ValueObjects;
using MediatR;

namespace API.Auth.Feature.Modelo.Domain.Events;

public sealed class ModeloEntity : AggregateRoot<ModeloEntity>
{
    public string Name { get; private set; }
    public EGender Gender { get; private set; }
    public Email Email { get; private set; }
    public PhoneNumber Phone { get; private set; }

    public ModeloEntity(string name, EGender gender, Email email, PhoneNumber phone)
    {
        Name = name;
        Gender = gender;
        Email = email;
        Phone = phone;
        
        // Adicionando a nova instãncia nos eventos de domínio.
        //AddDomainEvent(new UserCreatedEvent(Id, firstName, lastName, gender, notification, email.Address, phone.Phone, password, role, dateOfBirth));
    }
}
