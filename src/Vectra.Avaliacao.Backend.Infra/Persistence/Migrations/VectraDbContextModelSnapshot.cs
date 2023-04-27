﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vectra.Avaliacao.Backend.Infra.Persistence.Data;

#nullable disable

namespace Vectra.Avaliacao.Backend.Infra.Persistence.Migrations
{
    [DbContext(typeof(VectraDbContext))]
    partial class VectraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Vectra.Avaliacao.Backend.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMERIC(10,2)")
                        .HasDefaultValue(0.00m)
                        .HasColumnName("Balance");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR(40)")
                        .HasColumnName("Branch");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2023, 4, 27, 13, 51, 5, 909, DateTimeKind.Utc).AddTicks(2371))
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("IsActive");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)")
                        .HasColumnName("Number");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2023, 4, 27, 13, 51, 5, 909, DateTimeKind.Utc).AddTicks(2882))
                        .HasColumnName("UpdatedAt");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "Number" }, "IX_Account_Number")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Vectra.Avaliacao.Backend.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2023, 4, 27, 13, 51, 5, 909, DateTimeKind.Utc).AddTicks(7673))
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2023, 4, 27, 13, 51, 5, 909, DateTimeKind.Utc).AddTicks(8034))
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "IX_Role_Name")
                        .IsUnique();

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Vectra.Avaliacao.Backend.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2023, 4, 27, 13, 51, 5, 910, DateTimeKind.Utc).AddTicks(950))
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("Email");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("PasswordHash");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2023, 4, 27, 13, 51, 5, 910, DateTimeKind.Utc).AddTicks(1309))
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_User_Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("Vectra.Avaliacao.Backend.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_RoleId");

                    b.HasOne("Vectra.Avaliacao.Backend.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_UserId");
                });

            modelBuilder.Entity("Vectra.Avaliacao.Backend.Domain.Entities.Account", b =>
                {
                    b.HasOne("Vectra.Avaliacao.Backend.Domain.Entities.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Account_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Vectra.Avaliacao.Backend.Domain.Entities.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
