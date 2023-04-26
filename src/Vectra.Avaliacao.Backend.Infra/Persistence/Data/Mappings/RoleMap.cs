using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Infra.Persistence.Data.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(Role.Name))
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

        builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName(nameof(Role.CreatedAt))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnName(nameof(Role.UpdatedAt))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName(nameof(Role.IsActive))
                .HasColumnType("BIT")
                .HasDefaultValue(false);

        builder.HasIndex(x => x.Name, "IX_Role_Name")
                .IsUnique();
    }
}
