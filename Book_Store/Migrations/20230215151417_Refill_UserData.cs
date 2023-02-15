using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class RefillUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41f9740b-0884-4ae8-a69e-f424bcddd275", "26420015-7938-4115-bd88-c0bdc452b92a", "Customer", "CUSTOMER" },
                    { "a1d46f4c-f4eb-4204-88c1-07ae4354528c", "4c601943-4775-45e0-a906-029435dc7bb0", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "795050ed-2e6d-45c7-a2c0-a44c14186a2d", 0, "8ba0f4fc-6d55-4d28-8dc7-528bf09074a0", "admin@example.com", true, "admin", "admin", false, null, 0f, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAELrMlp/lj9BzeFG82CPyT+Y3SdC+C/InCMq6Q+5WguwCGPuE26l1QOj1lv5gA9uuVQ==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a1d46f4c-f4eb-4204-88c1-07ae4354528c", "795050ed-2e6d-45c7-a2c0-a44c14186a2d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41f9740b-0884-4ae8-a69e-f424bcddd275");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1d46f4c-f4eb-4204-88c1-07ae4354528c", "795050ed-2e6d-45c7-a2c0-a44c14186a2d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1d46f4c-f4eb-4204-88c1-07ae4354528c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "795050ed-2e6d-45c7-a2c0-a44c14186a2d");

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
    }
}
