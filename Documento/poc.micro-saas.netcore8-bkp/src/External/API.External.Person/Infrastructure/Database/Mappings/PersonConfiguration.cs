using API.External.Person.Feature.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.External.Person.Infrastructure.Database.Mappings;

public class PersonConfiguration : IEntityTypeConfiguration<API.External.Person.Feature.Domain.Person>
{
    public void Configure(EntityTypeBuilder<API.External.Person.Feature.Domain.Person> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(p => p.Type)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(1);
    }
}



public class IndividualPersonConfiguration : IEntityTypeConfiguration<IndividualPerson>
{
    public void Configure(EntityTypeBuilder<IndividualPerson> builder)
    {
        builder.HasBaseType<API.External.Person.Feature.Domain.Person>();

        builder.Property(ip => ip.CPF)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(14);

        builder.Property(ip => ip.BirthDate)
            .IsRequired();
    }
}


public class LegalEntityConfiguration : IEntityTypeConfiguration<LegalEntity>
{
    public void Configure(EntityTypeBuilder<LegalEntity> builder)
    {
        builder.HasBaseType<API.External.Person.Feature.Domain.Person>();

        builder.Property(le => le.CNPJ)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(18);
    }
}


public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(d => d.Type)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50);

        builder.Property(d => d.Number)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50);

        builder.HasOne(d => d.Person)
            .WithMany(p => p.Documents)
            .HasForeignKey(d => d.PersonId);
    }
}


public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(a => a.Type)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);

        builder.Property(a => a.Street)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(a => a.ZipCode)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(10);

        builder.HasOne(a => a.Person)
            .WithMany(p => p.Addresses)
            .HasForeignKey(a => a.PersonId);
    }
}


public class PhoneConfiguration : IEntityTypeConfiguration<PhoneEntity>
{
    public void Configure(EntityTypeBuilder<PhoneEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(p => p.Type)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(15);

        builder.Property(p => p.Number)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);

        builder.HasOne(p => p.Person)
            .WithMany(p => p.Phones)
            .HasForeignKey(p => p.PersonId);
    }
}

public class EmailConfiguration : IEntityTypeConfiguration<EmailEntity>
{
    public void Configure(EntityTypeBuilder<EmailEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(e => e.Address)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(254);

        builder.HasOne(e => e.Person)
            .WithMany(p => p.Emails)
            .HasForeignKey(e => e.PersonId);
    }
}
