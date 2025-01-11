using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contests_app.API.Migrations
{
    /// <inheritdoc />
    public partial class EvaluationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0b761354-4e56-4c37-ae0c-10b15103ef54"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("790d07da-7abd-4f80-bffa-7edc3924df43"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ded6fcf7-7ad2-4216-855e-4f5a44665715"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("7955e387-9445-477d-b0cf-75ebaca2599a"), "https://material.angular.io/assets/img/examples/shiba1.jpg", true, false, "admin", "Admin", "$2a$11$wvIRl2D9DZjDQ6c5oLUblu8BjbJ7r5W.IKQpzr3mS6/lS4wIGBTke", "Admin", null },
                    { new Guid("a3873af6-b340-4665-981b-0a2800f78dc5"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, false, "user", "User", "$2a$11$LNtSiy9Doajy0WGzfkIKNu7.LFdBdDbdEP8hywD6cHtJ8uD3j7zua", "User", null },
                    { new Guid("dfdee906-a518-4379-b4c6-3f89d1b1f062"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, true, "mentor", "Mentor", "$2a$11$lH2ihOr5y5hez/zPcNcVs.n4qgYeMntixbi.Er2aTSgCQj2AchNZO", "Mentor", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7955e387-9445-477d-b0cf-75ebaca2599a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a3873af6-b340-4665-981b-0a2800f78dc5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("dfdee906-a518-4379-b4c6-3f89d1b1f062"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("0b761354-4e56-4c37-ae0c-10b15103ef54"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, true, "mentor", "Mentor", "$2a$11$oWCaC7MXgL53YwYQXEWr/u2F3/lK9D09gGjtQcxv6UpbvwySs5OFe", "Mentor", null },
                    { new Guid("790d07da-7abd-4f80-bffa-7edc3924df43"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, false, "user", "User", "$2a$11$.oHPyS3h1vrvhIaQvaPyJewNsSPOERiNyudAgkIWhOI5X3LeAK.iS", "User", null },
                    { new Guid("ded6fcf7-7ad2-4216-855e-4f5a44665715"), "https://material.angular.io/assets/img/examples/shiba1.jpg", true, false, "admin", "Admin", "$2a$11$qq/cldQp9HxbVwWON48KNOFL045BDT440gAJD8jURyZ0nitOWrxl2", "Admin", null }
                });
        }
    }
}
