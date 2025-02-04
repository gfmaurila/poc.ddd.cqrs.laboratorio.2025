namespace API.Exemple1.Core._08.Feature.Domain;

public class User
{
    public int Id { get; set; } = 0;
    public string Name { get; set; }
    public string Email { get; set; }
    
    // Relacionamento
    public ICollection<Customer> Customers { get; set; }
}
