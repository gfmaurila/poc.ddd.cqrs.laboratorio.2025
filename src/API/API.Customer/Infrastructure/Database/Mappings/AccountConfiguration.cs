using API.Customer.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace API.Customer.Core.Infrastructure.Database.Mappings;

public class AccountConfiguration : IEntityTypeConfiguration<AccountEntity>
{
    public void Configure(EntityTypeBuilder<AccountEntity> builder)
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

        builder.HasMany(a => a.Subscriptions)
            .WithOne()
            .HasForeignKey(s => s.AccountId);

        builder.HasMany(a => a.PersonUsers)
            .WithOne(pu => pu.Account)
            .HasForeignKey(pu => pu.AccountId);
    }
}












