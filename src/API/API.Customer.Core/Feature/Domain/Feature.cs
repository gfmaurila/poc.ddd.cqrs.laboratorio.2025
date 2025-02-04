namespace API.Exemple1.Core._08.Feature.Domain;

public class Feature
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid PlanId { get; set; }
    public Plan Plan { get; set; }
}
