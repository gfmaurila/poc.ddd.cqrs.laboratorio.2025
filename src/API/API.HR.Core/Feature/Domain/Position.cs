namespace API.HR.Core.Feature.Domain;

public class Position
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal BaseSalary { get; set; }

    // Relacionamentos
    public ICollection<Employee> Employees { get; set; }
}
