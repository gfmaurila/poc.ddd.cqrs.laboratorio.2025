namespace API.External.Person.Feature.Domain;

public class LegalEntity : Person
{
    public string CNPJ { get; set; }
    public string TradeName { get; set; }
    public DateTime OpeningDate { get; set; }
    public string? StateRegistration { get; set; }
    public string? MunicipalRegistration { get; set; }
    public List<string> Partners { get; set; } = new();
}
