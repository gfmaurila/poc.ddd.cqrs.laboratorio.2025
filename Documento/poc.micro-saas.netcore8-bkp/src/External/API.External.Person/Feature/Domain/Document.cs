using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.External.Person.Feature.Domain;

public class Document : BaseEntity, IAggregateRoot
{
    public string Type { get; set; } // CPF, RG, CNPJ, etc.
    public string Number { get; set; }
    public DateTime IssueDate { get; set; }
    public string IssuingAuthority { get; set; }
    public string Country { get; set; }
    public Guid PersonId { get; set; }
    public Person Person { get; set; }
}
