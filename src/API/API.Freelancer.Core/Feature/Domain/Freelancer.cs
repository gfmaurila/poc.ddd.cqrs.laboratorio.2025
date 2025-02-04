namespace API.Freelancer.Core.Feature.Domain;

public class Freelancer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal HourlyRate { get; set; }

    // Relacionamentos
    public ICollection<Skill> Skills { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Contract> Contracts { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
