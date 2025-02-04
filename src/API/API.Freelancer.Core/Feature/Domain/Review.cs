namespace API.Freelancer.Core.Feature.Domain;

public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }

    public int Rating { get; set; } // Exemplo: 1 a 5
    public string Comments { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
