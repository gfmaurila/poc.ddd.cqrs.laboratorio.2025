namespace API.Customer.Core.Feature.Domain;

public class User
{
    public int Id { get; set; } = 0;
    public string Name { get; set; }
    public string Email { get; set; }
    
    // Relacionamento
    public ICollection<Customer> Customers { get; set; }
}
