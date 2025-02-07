namespace API.Customer.Domain;
using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;


public class AccountSubscriptionEntity : BaseEntity, IAggregateRoot
{
    public Guid AccountId { get; set; }
    public AccountEntity Account { get; set; }
    public Guid SubscriptionPlanId { get; set; }
    public SubscriptionPlanEntity SubscriptionPlan { get; set; }
    public List<MessageUsageEntity> MessageUsages { get; set; } = new();
}

