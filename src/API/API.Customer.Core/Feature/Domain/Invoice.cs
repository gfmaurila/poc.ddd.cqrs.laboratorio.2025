namespace API.Exemple1.Core._08.Feature.Domain;

public class Invoice
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }

    public DateTime DueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public InvoiceStatus Status { get; set; }
}
