using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Freelancer.Core.Infrastructure.Database.Mappings;

public class ContractMap : IEntityTypeConfiguration<API.Freelancer.Core.Feature.Domain.Contract>
{
    public void Configure(EntityTypeBuilder<API.Freelancer.Core.Feature.Domain.Contract> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.ContractNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.TotalAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(c => c.Status)
            .IsRequired();

        builder.HasOne(c => c.Freelancer)
            .WithMany(f => f.Contracts)
            .HasForeignKey(c => c.FreelancerId);

        builder.HasOne(c => c.Client)
            .WithMany(cl => cl.Contracts)
            .HasForeignKey(c => c.ClientId);
    }
}

