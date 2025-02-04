using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Freelancer.Core.Infrastructure.Database.Mappings;

public class TaskMap : IEntityTypeConfiguration<API.Freelancer.Core.Feature.Domain.Task>
{
    public void Configure(EntityTypeBuilder<API.Freelancer.Core.Feature.Domain.Task> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .HasMaxLength(500);

        builder.Property(t => t.Status)
            .IsRequired();

        builder.Property(t => t.DueDate)
            .IsRequired();

        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId);
    }
}

