using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class ConnectCustomerCustomerOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25c89d70-c37f-4803-9cb1-6b5cb64b5909");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4eeb4283-6499-4422-b649-893f91ef6c58", "d8b7db7c-24c0-43ed-b862-1482838df863" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eeb4283-6499-4422-b649-893f91ef6c58");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8b7db7c-24c0-43ed-b862-1482838df863");

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrders_CustomerId",
                table: "CustomerOrders");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25c89d70-c37f-4803-9cb1-6b5cb64b5909", "1d7b6727-5c0a-48f0-ba35-79dd52ab43fe", "Customer", "CUSTOMER" },
                    { "4eeb4283-6499-4422-b649-893f91ef6c58", "eaf0e678-50a3-4b0e-b4c7-89da4f37ecda", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d8b7db7c-24c0-43ed-b862-1482838df863", 0, "577478c3-76ed-4b40-b7e8-48f6cab5e378", "admin@example.com", true, "admin", "admin", false, null, 0f, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEMXT2sQZoPyr1wQP6WoI4OYZG+WqBo24GjEtfxU5uMRLNcCuy4fbDzFgdCrXz2F3/Q==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4eeb4283-6499-4422-b649-893f91ef6c58", "d8b7db7c-24c0-43ed-b862-1482838df863" });
        }
    }
}
