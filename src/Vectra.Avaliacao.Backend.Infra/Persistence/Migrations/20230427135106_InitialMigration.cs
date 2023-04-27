﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vectra.Avaliacao.Backend.Infra.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2023, 4, 27, 13, 51, 5, 909, DateTimeKind.Utc).AddTicks(8034)),
                    CreatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2023, 4, 27, 13, 51, 5, 909, DateTimeKind.Utc).AddTicks(7673)),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2023, 4, 27, 13, 51, 5, 910, DateTimeKind.Utc).AddTicks(1309)),
                    CreatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2023, 4, 27, 13, 51, 5, 910, DateTimeKind.Utc).AddTicks(950)),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    Number = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Balance = table.Column<decimal>(type: "NUMERIC(10,2)", nullable: false, defaultValue: 0.00m),
                    UpdatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2023, 4, 27, 13, 51, 5, 909, DateTimeKind.Utc).AddTicks(2882)),
                    CreatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2023, 4, 27, 13, 51, 5, 909, DateTimeKind.Utc).AddTicks(2371)),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Number",
                table: "Account",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                table: "Account",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
