using API.Customer.Core.Feature.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace API.Customer.Core.Infrastructure.Database.Mappings;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(a => a.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(a => a.Email)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(a => a.PhoneNumber)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);
    }
}

public class AccountSubscriptionConfiguration : IEntityTypeConfiguration<AccountSubscription>
{
    public void Configure(EntityTypeBuilder<AccountSubscription> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(s => s.Account)
            .WithMany(a => a.Subscriptions)
            .HasForeignKey(s => s.AccountId);
    }
}

public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
{
    public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(sp => sp.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100);
    }
}

public class MessageUsageConfiguration : IEntityTypeConfiguration<MessageUsage>
{
    public void Configure(EntityTypeBuilder<MessageUsage> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(mu => mu.AccountSubscription)
            .WithMany(s => s.MessageUsages)
            .HasForeignKey(mu => mu.AccountSubscriptionId);
    }
}

public class MessageUsageItemConfiguration : IEntityTypeConfiguration<MessageUsageItem>
{
    public void Configure(EntityTypeBuilder<MessageUsageItem> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(mui => mui.MessageUsage)
            .WithMany(mu => mu.MessageUsageItems)
            .HasForeignKey(mui => mui.MessageUsageId);

        builder.Property(mui => mui.MessageType)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50);
    }
}

public class AccountProductConfiguration : IEntityTypeConfiguration<AccountProduct>
{
    public void Configure(EntityTypeBuilder<AccountProduct> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(ap => ap.AccountSubscription)
            .WithMany()
            .HasForeignKey(ap => ap.AccountSubscriptionId);
    }
}
