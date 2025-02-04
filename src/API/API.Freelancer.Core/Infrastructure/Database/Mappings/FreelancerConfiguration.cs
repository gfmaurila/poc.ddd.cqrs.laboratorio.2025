using API.Freelancer.Core.Feature.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Common.Core._08.Extensions;

namespace API.Freelancer.Core.Infrastructure.Database.Mappings;

public class FreelancerConfiguration : IEntityTypeConfiguration<API.Freelancer.Core.Feature.Domain.Freelancer>
{
    public void Configure(EntityTypeBuilder<API.Freelancer.Core.Feature.Domain.Freelancer> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(f => f.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(f => f.Email)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(f => f.PhoneNumber)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);
    }
}

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(c => c.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(c => c.Email)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);
    }
}

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(p => p.Title)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnType("TEXT");

        builder.Property(p => p.Budget)
            .IsRequired();
    }
}

public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
{
    public void Configure(EntityTypeBuilder<Proposal> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(p => p.Freelancer)
            .WithMany(f => f.Proposals)
            .HasForeignKey(p => p.FreelancerId);
    }
}
