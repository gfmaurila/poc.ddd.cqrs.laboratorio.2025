using MassTransit.Courier.Contracts;

namespace API.Customer.Core.Feature.Domain;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Relacionamento
    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<Subscription> Subscriptions { get; set; }
}
