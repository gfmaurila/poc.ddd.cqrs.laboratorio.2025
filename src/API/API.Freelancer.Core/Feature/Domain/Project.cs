namespace API.Freelancer.Core.Feature.Domain;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectStatus Status { get; set; }

    // Relacionamentos
    public Guid ClientId { get; set; }
    public Client Client { get; set; }

    public Guid FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }

    public ICollection<Task> Tasks { get; set; }
}
