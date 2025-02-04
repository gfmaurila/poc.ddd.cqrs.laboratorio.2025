namespace API.Freelancer.Core.Feature.Domain;

public class Invoice
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string InvoiceNumber { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public InvoiceStatus Status { get; set; }

    // Relacionamentos
    public Guid ContractId { get; set; }
    public Contract Contract { get; set; }
}
