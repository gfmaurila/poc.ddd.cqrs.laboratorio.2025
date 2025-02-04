using API.Freelancer.Core.Feature.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Freelancer.Core.Infrastructure.Database.Mappings;

public class SkillMap : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(s => s.Freelancer)
            .WithMany(f => f.Skills)
            .HasForeignKey(s => s.FreelancerId);
    }
}
