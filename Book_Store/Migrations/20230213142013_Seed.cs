using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90c95ed7-a901-4969-85e4-169f892d803c", "2bbfc084-0137-4087-97b7-d9ed7261c4ff", "Customer", "CUSTOMER" },
                    { "c6284aff-ddde-415b-9e09-c5bae6cd4a44", "a9f2fd39-8480-4028-b68f-4a7fda9917ad", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6b147a14-86de-4afc-b573-4ee9f76c363b", 0, "e8b9d00a-a4b8-408a-85a0-4fc9565f3c2f", "admin@example.com", true, "admin", "admin", false, null, 0f, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEM1sCVzUG+e8FlWV/8j8yFs/AVuzmFauGSKnPfDIJpeMRt9fAaZ7m3tauU5O/FHr3g==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c6284aff-ddde-415b-9e09-c5bae6cd4a44", "6b147a14-86de-4afc-b573-4ee9f76c363b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90c95ed7-a901-4969-85e4-169f892d803c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6284aff-ddde-415b-9e09-c5bae6cd4a44", "6b147a14-86de-4afc-b573-4ee9f76c363b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6284aff-ddde-415b-9e09-c5bae6cd4a44");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b147a14-86de-4afc-b573-4ee9f76c363b");
        }
    }
}
