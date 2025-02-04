using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Freelancer.Core.Feature.Domain;

namespace API.Freelancer.Core.Infrastructure.Database.Mappings;

public class InvoiceMap : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.InvoiceNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(i => i.TotalAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(i => i.Status)
            .IsRequired();

        //builder.HasOne(i => i.Contract)
        //    .WithMany(c => c.Invoices)
        //    .HasForeignKey(i => i.ContractId);
    }
}
