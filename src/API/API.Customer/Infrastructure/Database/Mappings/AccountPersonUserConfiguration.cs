using API.Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Common.Core._08.Extensions;

namespace API.Customer.Infrastructure.Database.Mappings;

public class AccountPersonUserConfiguration : IEntityTypeConfiguration<AccountPersonUserEntity>
{
    public void Configure(EntityTypeBuilder<AccountPersonUserEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(pu => pu.Account)
            .WithMany(a => a.PersonUsers)
            .HasForeignKey(pu => pu.AccountId);

        builder.Property(pu => pu.UserId)
            .IsRequired();

        builder.Property(pu => pu.PersonId)
            .IsRequired();
    }
}