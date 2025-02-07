using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Customer.Domain;

public class AccountProductEntity : BaseEntity, IAggregateRoot
{
    public Guid AccountSubscriptionId { get; set; }
    public AccountSubscriptionEntity AccountSubscription { get; set; }
    public string ProductName { get; set; } // API.Clinic.Core, API.Freelancer.Core, etc.
}
