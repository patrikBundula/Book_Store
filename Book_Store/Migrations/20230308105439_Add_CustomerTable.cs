using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Money = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0f4e54e-89fd-4520-9874-742a0149381b", "8ab1fe07-bad3-467b-984f-a59ae1d1d292", "Customer", "CUSTOMER" },
                    { "e23f9022-92be-48fe-a5ae-df7c9f7011a8", "53aa715c-98f9-409d-a44b-633cb4d8dec7", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e88fcad-76ed-4ccf-a055-9c6bc8802202", 0, "95b83dac-9479-4a2f-94ea-fe233402f69c", "admin@example.com", true, "admin", "admin", false, null, 0f, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEMHhviK5K1IkD5dXLfMJaFJUa82ZwhvgMgrFdXRNSVrJq9+JwcDUQRNCiLgg8LnJqg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e23f9022-92be-48fe-a5ae-df7c9f7011a8", "1e88fcad-76ed-4ccf-a055-9c6bc8802202" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0f4e54e-89fd-4520-9874-742a0149381b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e23f9022-92be-48fe-a5ae-df7c9f7011a8", "1e88fcad-76ed-4ccf-a055-9c6bc8802202" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23f9022-92be-48fe-a5ae-df7c9f7011a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e88fcad-76ed-4ccf-a055-9c6bc8802202");

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
    }
}
