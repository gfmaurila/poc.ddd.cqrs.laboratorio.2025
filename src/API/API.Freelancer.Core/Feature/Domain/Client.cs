using System.Diagnostics.Contracts;

namespace API.Freelancer.Core.Feature.Domain;

public class Client
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Relacionamentos
    public ICollection<Project> Projects { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}
