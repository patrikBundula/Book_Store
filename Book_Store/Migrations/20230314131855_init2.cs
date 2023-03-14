using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
