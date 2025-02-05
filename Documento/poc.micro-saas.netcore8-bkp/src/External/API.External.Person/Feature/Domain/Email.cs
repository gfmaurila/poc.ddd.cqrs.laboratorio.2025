using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.External.Person.Feature.Domain;

public class EmailEntity : BaseEntity, IAggregateRoot
{
    public string Address { get; set; }
    public string Type { get; set; } // Pessoal, Comercial, etc.
    public Guid PersonId { get; set; }
    public Person Person { get; set; }
}
