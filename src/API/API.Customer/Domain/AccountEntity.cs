using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Customer.Domain;

public class AccountEntity : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<AccountSubscriptionEntity> Subscriptions { get; set; } = new();
    public List<AccountPersonUserEntity> PersonUsers { get; set; } = new();
}


