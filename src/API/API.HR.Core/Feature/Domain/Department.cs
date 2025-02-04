namespace API.HR.Core.Feature.Domain;

public class Department
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }

    // Relacionamentos
    public ICollection<Employee> Employees { get; set; }
}
