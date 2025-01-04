using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contests_app.API.Migrations
{
    /// <inheritdoc />
    public partial class DefaultUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("124beadd-a131-4277-a5aa-af3506fe3b59"), "", true, false, "admin", "Admin", "$2a$11$OGgY.r9OKM4qZgwylQEpnOQjWD4TvxgKzBLN9J8.GBb9PSbsJGNaO", "Admin", null },
                    { new Guid("448bb116-6a2f-4c04-9e5f-162d686f9720"), "", false, true, "mentor", "Mentor", "$2a$11$vWUBFNEctvGRWS9DFaAU9uM98nf9rPv3QV/UcH3vP7knsrtJMwDJ6", "Mentor", null },
                    { new Guid("ef24cd9d-1b46-4957-8d7f-5ee4492bb52e"), "", false, false, "user", "User", "$2a$11$xuWK8EfPJjyapYJEsUo4TOCp.LitO8J9Mev4rGSlDzzJq1WcONOkG", "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("124beadd-a131-4277-a5aa-af3506fe3b59"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("448bb116-6a2f-4c04-9e5f-162d686f9720"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ef24cd9d-1b46-4957-8d7f-5ee4492bb52e"));
        }
    }
}
