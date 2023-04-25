using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Infra.Persistence.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnName(nameof(User.UpdatedAt))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName(nameof(User.CreatedAt))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName(nameof(User.Email))
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

        builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName(nameof(User.PasswordHash))
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

        builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName(nameof(User.IsActive))
                .HasColumnType("BIT")
                .HasDefaultValue(false);

        builder.HasIndex(x => x.Email, "IX_User_Email")
                .IsUnique();

        builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role.HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .HasConstraintName("FK_UserRole_RoleId")
                    .OnDelete(DeleteBehavior.Cascade),
                user => user.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_UserRole_UserId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}
