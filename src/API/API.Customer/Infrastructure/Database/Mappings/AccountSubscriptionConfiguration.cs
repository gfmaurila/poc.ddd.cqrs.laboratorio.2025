using API.Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;

namespace API.Customer.Infrastructure.Database.Mappings;

public class AccountSubscriptionConfiguration : IEntityTypeConfiguration<AccountSubscriptionEntity>
{
    public void Configure(EntityTypeBuilder<AccountSubscriptionEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(s => s.Account)
            .WithMany(a => a.Subscriptions)
            .HasForeignKey(s => s.AccountId);
    }
}
