namespace API.Customer.Domain;
using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

public class MessageUsageEntity : BaseEntity, IAggregateRoot
{
    public Guid AccountSubscriptionId { get; set; }
    public AccountSubscriptionEntity AccountSubscription { get; set; }
    public DateTime Period { get; set; } // Mês de referência
    public List<MessageUsageItemEntity> MessageUsageItems { get; set; } = new();
    public decimal ExtraCharges => MessageUsageItems.Sum(i => i.TotalCost);
}


