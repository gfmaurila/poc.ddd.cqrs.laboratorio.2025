using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Freelancer.Core.Infrastructure.Database.Mappings;

public class FreelancerMap : IEntityTypeConfiguration<API.Freelancer.Core.Feature.Domain.Freelancer>
{
    public void Configure(EntityTypeBuilder<API.Freelancer.Core.Feature.Domain.Freelancer> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(f => f.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(f => f.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Phone)
            .HasMaxLength(20);

        builder.Property(f => f.Address)
            .HasMaxLength(250);

        builder.Property(f => f.HourlyRate)
            .HasColumnType("decimal(18,2)");

        builder.HasMany(f => f.Skills)
            .WithOne(s => s.Freelancer)
            .HasForeignKey(s => s.FreelancerId);

        builder.HasMany(f => f.Projects)
            .WithOne(p => p.Freelancer)
            .HasForeignKey(p => p.FreelancerId);

        builder.HasMany(f => f.Contracts)
            .WithOne(c => c.Freelancer)
            .HasForeignKey(c => c.FreelancerId);
    }
}
