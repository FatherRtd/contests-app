using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contests_app.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAvatarColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("930a6a70-73ce-40f4-9ada-b7bdc91e4730"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, false, "user", "User", "$2a$11$6gZzKPLL6r5smZ7JcZA4MeS982pU/9.zQCMdLO3BFhIYiazXd3yo6", "User", null },
                    { new Guid("b75dcc9e-9605-4a3f-8f0e-024f03f0ae1c"), "https://material.angular.io/assets/img/examples/shiba1.jpg", true, false, "admin", "Admin", "$2a$11$SQE779EseVoOL6XTAYZ0BuCZY56Cz3xe7FwhBHkn0VJTrcrdSYlNK", "Admin", null },
                    { new Guid("f516eab8-32e9-48ea-9eee-276628b4fe53"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, true, "mentor", "Mentor", "$2a$11$vIosaE2NY7sVgKXGN.i7re82uyoGSwXb54KX6ZJJOe.kFzfzvyqdG", "Mentor", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("930a6a70-73ce-40f4-9ada-b7bdc91e4730"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b75dcc9e-9605-4a3f-8f0e-024f03f0ae1c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f516eab8-32e9-48ea-9eee-276628b4fe53"));

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
