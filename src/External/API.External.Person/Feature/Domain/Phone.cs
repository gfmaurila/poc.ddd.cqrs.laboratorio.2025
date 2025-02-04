using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.External.Person.Feature.Domain;

public class PhoneEntity : BaseEntity, IAggregateRoot
{
    public string Type { get; set; } // Celular, Fixo, Comercial, etc.
    public string AreaCode { get; set; }
    public string Number { get; set; }
    public Guid PersonId { get; set; }
    public Person Person { get; set; }
}
