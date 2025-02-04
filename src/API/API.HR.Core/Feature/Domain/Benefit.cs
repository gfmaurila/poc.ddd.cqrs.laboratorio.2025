namespace API.HR.Core.Feature.Domain;

public class Benefit
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }

    // Relacionamentos
    public ICollection<Employee> Employees { get; set; }
}
