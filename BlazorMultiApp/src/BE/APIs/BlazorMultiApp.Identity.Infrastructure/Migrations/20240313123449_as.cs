using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorMultiApp.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @as : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e721037-c9fc-4ca0-80da-b414f5b72d36"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "165fa94d-d610-4c03-a676-13ce9e35d737", "ADMIN@ADM.COM", "AQAAAAIAAYagAAAAEBKOjvBxxgqmLI4NJ//cff5f+DhTtRxs84Kc9z8X9qjODzFbrQ7HyB2uno2UEtMDmw==", "555a185e-68c5-4758-8021-b521b6df61cf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e721037-c9fc-4ca0-80da-b414f5b72d36"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b93bf92-b055-4df3-999f-be3220304b32", null, "AQAAAAIAAYagAAAAEDIfPrh7W1j2jgqvoCMAwA2OFvRJd+Nh+xhVDHeXXwzlBHidRaMPACKykQBxmQ9iEA==", "2a3259cc-3d58-4771-bd66-a074fddd66c0" });
        }
    }
}
