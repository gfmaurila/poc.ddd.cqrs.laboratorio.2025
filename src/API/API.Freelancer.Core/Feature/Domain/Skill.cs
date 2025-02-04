namespace API.Freelancer.Core.Feature.Domain;

public class Skill
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }

    // Relacionamentos
    public Guid FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }
}
