using API.Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Common.Core._08.Extensions;

namespace API.Customer.Infrastructure.Database.Mappings;

public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlanEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionPlanEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(sp => sp.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100);
    }
}
