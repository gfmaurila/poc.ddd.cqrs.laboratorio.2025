namespace API.Customer.Domain;
using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

public class AccountPersonUserEntity : BaseEntity, IAggregateRoot
{
    public Guid AccountId { get; set; }
    public AccountEntity Account { get; set; }
    public Guid UserId { get; set; }
    public Guid PersonId { get; set; }
}

