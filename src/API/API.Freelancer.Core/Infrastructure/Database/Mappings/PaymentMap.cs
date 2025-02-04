using API.Freelancer.Core.Feature.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Freelancer.Core.Infrastructure.Database.Mappings;

public class PaymentMap : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PaymentDate)
            .IsRequired();

        builder.Property(p => p.AmountPaid)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Method)
            .IsRequired();

        //builder.HasOne(p => p.Contract)
        //    .WithMany(c => c.Payments)
        //    .HasForeignKey(p => p.ContractId);
    }
}
