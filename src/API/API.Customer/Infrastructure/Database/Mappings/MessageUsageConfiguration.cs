using API.Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Common.Core._08.Extensions;
namespace API.Customer.Infrastructure.Database.Mappings;

public class MessageUsageConfiguration : IEntityTypeConfiguration<MessageUsageEntity>
{
    public void Configure(EntityTypeBuilder<MessageUsageEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(mu => mu.AccountSubscription)
            .WithMany(s => s.MessageUsages)
            .HasForeignKey(mu => mu.AccountSubscriptionId);
    }
}