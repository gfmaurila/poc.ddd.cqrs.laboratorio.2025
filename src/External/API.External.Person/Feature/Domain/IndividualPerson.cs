using Common.Core._08.Domain.Enumerado;

namespace API.External.Person.Feature.Domain;

public class IndividualPerson : Person
{
    public string CPF { get; set; }
    public DateTime BirthDate { get; set; }
    public EGender Gender { get; set; } = EGender.None;
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
}
