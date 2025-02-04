using API.HR.Core.Feature.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.HR.Core.Infrastructure.Database.Mappings;

public class PerformanceReviewMap : IEntityTypeConfiguration<PerformanceReview>
{
    public void Configure(EntityTypeBuilder<PerformanceReview> builder)
    {
        builder.HasKey(pr => pr.Id);

        builder.Property(pr => pr.ReviewDate)
            .IsRequired();

        builder.Property(pr => pr.Reviewer)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(pr => pr.Comments)
            .HasMaxLength(500);

        builder.Property(pr => pr.Rating)
            .IsRequired();

        // Relacionamento
        builder.HasOne(pr => pr.Employee)
            .WithMany(e => e.PerformanceReviews)
            .HasForeignKey(pr => pr.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
