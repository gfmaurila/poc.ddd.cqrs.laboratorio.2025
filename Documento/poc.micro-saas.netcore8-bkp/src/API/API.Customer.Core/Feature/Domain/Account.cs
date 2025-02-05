using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Customer.Core.Feature.Domain;

public class Account : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<AccountSubscription> Subscriptions { get; set; } = new();
    public List<AccountPersonUser> PersonUsers { get; set; } = new();
}

public class AccountPersonUser : BaseEntity, IAggregateRoot
{
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public Guid UserId { get; set; }
    public Guid PersonId { get; set; }
}

public class AccountSubscription : BaseEntity, IAggregateRoot
{
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public Guid SubscriptionPlanId { get; set; }
    public SubscriptionPlan SubscriptionPlan { get; set; }
    public List<MessageUsage> MessageUsages { get; set; } = new();
}


public class SubscriptionPlan : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public decimal MonthlyPrice { get; set; }
    public int EmailLimit { get; set; }
    public int SmsLimit { get; set; }
    public int WhatsAppLimit { get; set; }
    public decimal OverageCostPerEmail { get; set; }
    public decimal OverageCostPerSms { get; set; }
    public decimal OverageCostPerWhatsApp { get; set; }
}

public class MessageUsage : BaseEntity, IAggregateRoot
{
    public Guid AccountSubscriptionId { get; set; }
    public AccountSubscription AccountSubscription { get; set; }
    public DateTime Period { get; set; } // Mês de referência
    public List<MessageUsageItem> MessageUsageItems { get; set; } = new();
    public decimal ExtraCharges => MessageUsageItems.Sum(i => i.TotalCost);
}

public class MessageUsageItem : BaseEntity
{
    public Guid MessageUsageId { get; set; }
    public MessageUsage MessageUsage { get; set; }
    public string MessageType { get; set; } // Email, SMS, WhatsApp
    public int Quantity { get; set; }
    public decimal CostPerUnit { get; set; }
    public decimal TotalCost => Quantity * CostPerUnit;
}

public class AccountProduct : BaseEntity, IAggregateRoot
{
    public Guid AccountSubscriptionId { get; set; }
    public AccountSubscription AccountSubscription { get; set; }
    public string ProductName { get; set; } // API.Clinic.Core, API.Freelancer.Core, etc.
}