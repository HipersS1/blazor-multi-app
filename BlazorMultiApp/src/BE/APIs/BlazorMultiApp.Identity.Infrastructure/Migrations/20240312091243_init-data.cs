using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorMultiApp.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8e721037-c9fc-4ca0-80da-b414f5b72d36"), 0, "3b93bf92-b055-4df3-999f-be3220304b32", "admin@adm.com", true, "Jim", "Cool", false, null, "", null, "ADMIN@ADM.COM", "AQAAAAIAAYagAAAAEDIfPrh7W1j2jgqvoCMAwA2OFvRJd+Nh+xhVDHeXXwzlBHidRaMPACKykQBxmQ9iEA==", null, false, "2a3259cc-3d58-4771-bd66-a074fddd66c0", false, "admin@adm.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e721037-c9fc-4ca0-80da-b414f5b72d36"));
        }
    }
}
