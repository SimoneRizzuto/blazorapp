using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededDefaultUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8de12038-9c75-4ae7-a9fb-f3093923a5d3", "7f954239-a672-4719-a5a6-689e2c3e8dc6", "Administrator", "ADMINISTRATOR" },
                    { "e78308a2-2ce6-4f79-a99e-0dc3ea7bb463", "2e61e7b7-d0dd-4f82-b32b-a3731164997d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a96a8373-a059-4b40-a798-47a2bb2a0232", 0, "48b07800-9b43-43e4-97c3-4bb7e7f4dc3e", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMINBOOKSTORE", "AQAAAAEAACcQAAAAEA3dMSYhZ8j3JyJNXs6/O/om9O4A4m71f6EtaT4/WTEUesCIH8By6SciC7QDfPkyGg==", null, false, "c88da687-5f42-489c-8358-13abc0eb1988", false, "adminbookstore" },
                    { "d257ec95-e3ce-4c86-ae95-afbf5cc6a324", 0, "f82c8381-488a-4372-a54d-2dd2f8b58c77", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USERBOOKSTORE", "AQAAAAEAACcQAAAAEE0erYMVr7eXOKCWv5EYgy66cBmrMGjwczFGf3lbg8Jwr0aakorb1VrbeOZkWWij4A==", null, false, "6a6d2fa6-94ef-4f51-91d8-f3447618d751", false, "userbookstore" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8de12038-9c75-4ae7-a9fb-f3093923a5d3", "a96a8373-a059-4b40-a798-47a2bb2a0232" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e78308a2-2ce6-4f79-a99e-0dc3ea7bb463", "d257ec95-e3ce-4c86-ae95-afbf5cc6a324" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8de12038-9c75-4ae7-a9fb-f3093923a5d3", "a96a8373-a059-4b40-a798-47a2bb2a0232" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e78308a2-2ce6-4f79-a99e-0dc3ea7bb463", "d257ec95-e3ce-4c86-ae95-afbf5cc6a324" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8de12038-9c75-4ae7-a9fb-f3093923a5d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e78308a2-2ce6-4f79-a99e-0dc3ea7bb463");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a96a8373-a059-4b40-a798-47a2bb2a0232");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d257ec95-e3ce-4c86-ae95-afbf5cc6a324");
        }
    }
}
