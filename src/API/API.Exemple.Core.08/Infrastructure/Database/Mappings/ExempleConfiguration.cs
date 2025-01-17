using API.Exemple.Core._08.Infrastructure.Domain.Exemple;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace API.Exemple.Core._08.Infrastructure.Database.Mappings;

public class ExempleConfiguration : IEntityTypeConfiguration<ExempleEntity>
{
    public void Configure(EntityTypeBuilder<ExempleEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder
            .Property(entity => entity.FirstName)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(100);

        builder
            .Property(entity => entity.LastName)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(100);

        builder
            .Property(entity => entity.Gender)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(6)
            .HasConversion<string>();

        builder
            .Property(entity => entity.Notification)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(10)
            .HasConversion<string>();

        builder.OwnsOne(entity => entity.Phone, ownedNav =>
        {
            ownedNav
                .Property(phone => phone.Phone)
                .IsRequired() // NOT NULL
                .IsUnicode(false) // VARCHAR
                .HasMaxLength(20)
                .HasColumnName(nameof(ExempleEntity.Phone));
        });

        builder.OwnsOne(entity => entity.Email, ownedNav =>
        {
            ownedNav
                .Property(email => email.Address)
                .IsRequired() // NOT NULL
                .IsUnicode(false) // VARCHAR
                .HasMaxLength(254)
                .HasColumnName(nameof(ExempleEntity.Email));
        });

        builder.Property(entity => entity.Role)
            .IsRequired()
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
            .IsUnicode(false)
            .HasMaxLength(2048);

    }
}
