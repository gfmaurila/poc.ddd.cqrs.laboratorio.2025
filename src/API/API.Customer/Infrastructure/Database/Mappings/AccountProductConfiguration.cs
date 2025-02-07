using API.Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Common.Core._08.Extensions;

namespace API.Customer.Infrastructure.Database.Mappings;

public class AccountProductConfiguration : IEntityTypeConfiguration<AccountProductEntity>
{
    public void Configure(EntityTypeBuilder<AccountProductEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(ap => ap.AccountSubscription)
            .WithMany()
            .HasForeignKey(ap => ap.AccountSubscriptionId);
    }
}
