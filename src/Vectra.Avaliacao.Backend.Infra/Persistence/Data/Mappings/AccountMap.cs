using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Infra.Persistence.Data.Mappings;

public class AccountMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnName(nameof(Account.UpdatedAt))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName(nameof(Account.CreatedAt))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.Branch)
                .IsRequired()
                .HasColumnName(nameof(Account.Branch))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

        builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnName(nameof(Account.Number))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);

        builder.Property(x => x.Balance)
                .IsRequired()
                .HasColumnName(nameof(Account.Balance))
                .HasColumnType("NUMERIC(10,2)")
                .HasDefaultValue(0.00M);

        builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName(nameof(Account.IsActive))
                .HasColumnType("BIT")
                .HasDefaultValue(false);

        builder.HasIndex(x => x.Number, "IX_Account_Number");

        builder.HasOne(x => x.Client)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_Account_User")
                .OnDelete(DeleteBehavior.Cascade);                
    }
}
