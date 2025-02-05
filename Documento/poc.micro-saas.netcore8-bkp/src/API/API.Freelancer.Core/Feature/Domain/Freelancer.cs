using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Freelancer.Core.Feature.Domain;

public class Freelancer : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Skills { get; set; } = new();
    public string PortfolioUrl { get; set; }
    public List<Project> Projects { get; set; } = new();
    public List<Proposal> Proposals { get; set; } = new();
}

public class Client : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Project> Projects { get; set; } = new();
}

public class Project : BaseEntity, IAggregateRoot
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Budget { get; set; }
    public DateTime Deadline { get; set; }
    public ProjectStatus Status { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public List<Proposal> Proposals { get; set; } = new();
}

public class Proposal : BaseEntity, IAggregateRoot
{
    public Guid FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public decimal ProposedPrice { get; set; }
    public DateTime EstimatedCompletion { get; set; }
    public ProposalStatus Status { get; set; }
}

public class Contract : BaseEntity, IAggregateRoot
{
    public Guid ProposalId { get; set; }
    public Proposal Proposal { get; set; }
    public ContractStatus Status { get; set; }
    public List<Payment> Payments { get; set; } = new();
}

public class Payment : BaseEntity, IAggregateRoot
{
    public Guid ContractId { get; set; }
    public Contract Contract { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
    public string PaymentMethod { get; set; }
}

public class Review : BaseEntity, IAggregateRoot
{
    public Guid FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public int Rating { get; set; }
    public string Comments { get; set; }
}

public enum ProjectStatus
{
    Open,
    InProgress,
    Completed,
    Cancelled
}

public enum ProposalStatus
{
    Pending,
    Accepted,
    Rejected
}

public enum ContractStatus
{
    Active,
    Completed,
    Cancelled
}

public enum PaymentStatus
{
    Pending,
    Processed,
    Completed
}
