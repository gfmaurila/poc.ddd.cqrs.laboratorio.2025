namespace API.Exemple1.Core._08.Feature.Domain;

public class Plan
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Feature> Features { get; set; }
}
