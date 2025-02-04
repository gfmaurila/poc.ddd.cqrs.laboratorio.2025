namespace API.Freelancer.Core.Feature.Domain;

public class Task
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime DueDate { get; set; }

    // Relacionamentos
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}
