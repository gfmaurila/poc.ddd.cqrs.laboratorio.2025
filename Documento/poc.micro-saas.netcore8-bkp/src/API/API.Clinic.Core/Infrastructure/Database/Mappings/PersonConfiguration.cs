using API.Exemple1.Core._08.Feature.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Common.Core._08.Extensions;

namespace API.Exemple1.Core._08.Infrastructure.Database.Mappings;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(p => p.Email)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);
    }
}

public class HealthcareProfessionalConfiguration : IEntityTypeConfiguration<HealthcareProfessional>
{
    public void Configure(EntityTypeBuilder<HealthcareProfessional> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(hp => hp.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(hp => hp.Specialty)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100);

        builder.Property(hp => hp.RegistrationNumber)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50);
    }
}

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);
    }
}

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId);

        builder.HasOne(a => a.HealthcareProfessional)
            .WithMany(hp => hp.Appointments)
            .HasForeignKey(a => a.HealthcareProfessionalId);
    }
}

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(ii => ii.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(150);
    }
}

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ConfigureBaseEntity();

        builder.HasOne(n => n.Appointment)
            .WithMany()
            .HasForeignKey(n => n.AppointmentId);
    }
}
