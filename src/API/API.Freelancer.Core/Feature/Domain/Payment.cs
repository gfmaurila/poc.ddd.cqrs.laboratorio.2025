namespace API.Freelancer.Core.Feature.Domain;

public class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ContractId { get; set; }
    public Contract Contract { get; set; }

    public DateTime PaymentDate { get; set; }
    public decimal AmountPaid { get; set; }
    public PaymentMethod Method { get; set; }
}
