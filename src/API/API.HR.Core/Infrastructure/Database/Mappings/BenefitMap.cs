using API.HR.Core.Feature.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.HR.Core.Infrastructure.Database.Mappings;

public class BenefitMap : IEntityTypeConfiguration<Benefit>
{
    public void Configure(EntityTypeBuilder<Benefit> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Description)
            .HasMaxLength(250);

        builder.Property(b => b.Amount)
            .HasColumnType("decimal(18,2)");
    }
}
