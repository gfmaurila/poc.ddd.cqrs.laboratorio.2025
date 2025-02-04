namespace API.Customer.Core.Feature.Domain;

public class Subscription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Guid PlanId { get; set; }
    public Plan Plan { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }

    // Status da Assinatura
    public SubscriptionStatus Status { get; set; }
}
