namespace API.Freelancer.Core.Feature.Domain;

public class Contract
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ContractNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
    public ContractStatus Status { get; set; }

    // Relacionamentos
    public Guid FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}
