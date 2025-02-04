namespace API.Exemple1.Core._08.Feature.Domain;

public class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod Method { get; set; }
}
