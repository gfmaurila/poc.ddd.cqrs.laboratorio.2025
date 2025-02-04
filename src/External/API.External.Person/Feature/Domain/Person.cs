using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.External.Person.Feature.Domain;

public class Person : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Type { get; set; } // "F" para Pessoa Física, "J" para Pessoa Jurídica
    public List<Document> Documents { get; set; } = new();
    public List<Address> Addresses { get; set; } = new();
    public List<PhoneEntity> Phones { get; set; } = new();
    public List<EmailEntity> Emails { get; set; } = new();
}
