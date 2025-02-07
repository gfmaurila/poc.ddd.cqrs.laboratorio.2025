
using API.Customer.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Customer.Infrastructure.Database.Mappings;


public class MessageUsageItemConfiguration : IEntityTypeConfiguration<MessageUsageItemEntity>
{
    public void Configure(EntityTypeBuilder<MessageUsageItemEntity> builder)
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