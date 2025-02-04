using API.HR.Core.Feature.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.HR.Core.Infrastructure.Database.Mappings;

public class PayrollMap : IEntityTypeConfiguration<Payroll>
{
    public void Configure(EntityTypeBuilder<Payroll> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PaymentDate)
            .IsRequired();

        builder.Property(p => p.GrossSalary)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.NetSalary)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Deductions)
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Notes)
            .HasMaxLength(500);

        // Relacionamento
        builder.HasOne(p => p.Employee)
            .WithMany(e => e.Payrolls)
            .HasForeignKey(p => p.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
