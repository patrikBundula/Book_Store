using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class adddiscriptionshippingmethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f8b9816-6aa8-4ac8-bfce-5a8b65565317");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7a359c7-94fb-4502-9f7f-2f4916b17267", "33aa394f-c630-44da-9907-84058cf08dbd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7a359c7-94fb-4502-9f7f-2f4916b17267");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33aa394f-c630-44da-9907-84058cf08dbd");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShippingMethods",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShippingMethods");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f8b9816-6aa8-4ac8-bfce-5a8b65565317", "a2ae5487-91e1-475e-aed7-15947b0b9767", "Customer", "CUSTOMER" },
                    { "f7a359c7-94fb-4502-9f7f-2f4916b17267", "1f349634-5999-4f14-96fe-dcf0efc1693a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33aa394f-c630-44da-9907-84058cf08dbd", 0, "b9a35a73-cd97-4ca7-a212-c2b87cb95533", "admin@example.com", true, "admin", "admin", false, null, 0f, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEEny6HS27/QIhNEIIt60MnryTW6uHuSNYYwO60zNce1xN9j4ok2iQNhEkXYiY4Xxfg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f7a359c7-94fb-4502-9f7f-2f4916b17267", "33aa394f-c630-44da-9907-84058cf08dbd" });
        }
    }
}
