using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.External.Person.Feature.Domain;

public class Address : BaseEntity, IAggregateRoot
{
    public string Type { get; set; } // Residencial, Comercial, etc.
    public string Street { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public Guid PersonId { get; set; }
    public Person Person { get; set; }
}

