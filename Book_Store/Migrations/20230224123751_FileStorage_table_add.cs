using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class FileStoragetableadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e867f38-0dae-45e7-9d20-10a519f474fe");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "750a7428-bbdf-407e-afcd-db76c2f9db18", "880aba66-0a7f-45a4-a1d6-df5eda91c75e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "750a7428-bbdf-407e-afcd-db76c2f9db18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "880aba66-0a7f-45a4-a1d6-df5eda91c75e");

            migrationBuilder.CreateTable(
                name: "FileStore",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UploadedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Extension = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHA512Hash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Version = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStore", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "731070e4-3f4e-4b31-860d-43f795ee27d1", "a2988721-2c91-41f8-8651-905b62d28ae7", "Admin", "ADMIN" },
                    { "7fe5bf20-e50b-4a60-89b1-f65c94458656", "3d36fabb-5f35-4782-9327-b8d959b2831e", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae2642b1-6d08-459d-8bbc-77c3dfe69b68", 0, "3618edec-597b-476e-8997-f58e2a27c50c", "admin@example.com", true, "admin", "admin", false, null, 0f, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEKtkqviYEjLkX369DN3FKj91JGYhntKQ6ei8kjoQr4yjl0dCCTjb/RtaW0IIA/JH7g==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "731070e4-3f4e-4b31-860d-43f795ee27d1", "ae2642b1-6d08-459d-8bbc-77c3dfe69b68" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileStore");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fe5bf20-e50b-4a60-89b1-f65c94458656");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "731070e4-3f4e-4b31-860d-43f795ee27d1", "ae2642b1-6d08-459d-8bbc-77c3dfe69b68" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "731070e4-3f4e-4b31-860d-43f795ee27d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae2642b1-6d08-459d-8bbc-77c3dfe69b68");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "750a7428-bbdf-407e-afcd-db76c2f9db18", "567ffebd-cd22-4176-8fb3-d61f080c11dd", "Admin", "ADMIN" },
                    { "8e867f38-0dae-45e7-9d20-10a519f474fe", "c396c320-6ff3-4c10-b63c-093aec50929c", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "880aba66-0a7f-45a4-a1d6-df5eda91c75e", 0, "bceb1f14-24ab-40b4-9623-9836e6bc1b81", "admin@example.com", true, "admin", "admin", false, null, 0f, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEFL5r+ar2tjzjkfdB4lf7XBzrGxp58vWbue4JnH0ojNIdQZumtRHzuk6R1o4lTmwRQ==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "750a7428-bbdf-407e-afcd-db76c2f9db18", "880aba66-0a7f-45a4-a1d6-df5eda91c75e" });
        }
    }
}
