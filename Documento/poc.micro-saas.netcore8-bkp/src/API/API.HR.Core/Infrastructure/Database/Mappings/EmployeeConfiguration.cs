using API.HR.Core.Feature.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.HR.Core.Infrastructure.Database.Mappings;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(e => e.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(e => e.Email)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(e => e.PhoneNumber)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);

        builder.Property(e => e.CurrentSalary)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId);
    }
}

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(d => d.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100);
    }
}

public class SalaryHistoryConfiguration : IEntityTypeConfiguration<SalaryHistory>
{
    public void Configure(EntityTypeBuilder<SalaryHistory> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(sh => sh.Employee)
            .WithMany(e => e.SalaryHistories)
            .HasForeignKey(sh => sh.EmployeeId);
    }
}

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(p => p.Employee)
            .WithMany(e => e.Promotions)
            .HasForeignKey(p => p.EmployeeId);
    }
}

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(a => a.Employee)
            .WithMany(e => e.Addresses)
            .HasForeignKey(a => a.EmployeeId);
    }
}

public class FinancialControlConfiguration : IEntityTypeConfiguration<FinancialControl>
{
    public void Configure(EntityTypeBuilder<FinancialControl> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(fc => fc.TotalPayroll)
            .HasColumnType("decimal(18,2)");

        builder.Property(fc => fc.Taxes)
            .HasColumnType("decimal(18,2)");

        builder.Property(fc => fc.Benefits)
            .HasColumnType("decimal(18,2)");
    }
}
