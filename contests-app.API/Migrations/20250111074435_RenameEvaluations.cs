using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contests_app.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameEvaluations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationEntity_Teams_TeamId",
                table: "EvaluationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationEntity_User_EvaluatorId",
                table: "EvaluationEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationEntity",
                table: "EvaluationEntity");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1db8b694-16d7-4cb3-a410-1969b64009c0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6a98836f-c019-4b44-9c87-68e6b76c143b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bcf4085c-3c31-486b-b237-ec3e93a9c060"));

            migrationBuilder.RenameTable(
                name: "EvaluationEntity",
                newName: "Evaluations");

            migrationBuilder.RenameIndex(
                name: "IX_EvaluationEntity_TeamId",
                table: "Evaluations",
                newName: "IX_Evaluations_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_EvaluationEntity_EvaluatorId",
                table: "Evaluations",
                newName: "IX_Evaluations_EvaluatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations",
                column: "Id");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("0b761354-4e56-4c37-ae0c-10b15103ef54"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, true, "mentor", "Mentor", "$2a$11$oWCaC7MXgL53YwYQXEWr/u2F3/lK9D09gGjtQcxv6UpbvwySs5OFe", "Mentor", null },
                    { new Guid("790d07da-7abd-4f80-bffa-7edc3924df43"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, false, "user", "User", "$2a$11$.oHPyS3h1vrvhIaQvaPyJewNsSPOERiNyudAgkIWhOI5X3LeAK.iS", "User", null },
                    { new Guid("ded6fcf7-7ad2-4216-855e-4f5a44665715"), "https://material.angular.io/assets/img/examples/shiba1.jpg", true, false, "admin", "Admin", "$2a$11$qq/cldQp9HxbVwWON48KNOFL045BDT440gAJD8jURyZ0nitOWrxl2", "Admin", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Teams_TeamId",
                table: "Evaluations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_User_EvaluatorId",
                table: "Evaluations",
                column: "EvaluatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Teams_TeamId",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_User_EvaluatorId",
                table: "Evaluations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations");

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

            migrationBuilder.RenameTable(
                name: "Evaluations",
                newName: "EvaluationEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_TeamId",
                table: "EvaluationEntity",
                newName: "IX_EvaluationEntity_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_EvaluatorId",
                table: "EvaluationEntity",
                newName: "IX_EvaluationEntity_EvaluatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationEntity",
                table: "EvaluationEntity",
                column: "Id");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("1db8b694-16d7-4cb3-a410-1969b64009c0"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, true, "mentor", "Mentor", "$2a$11$7ygo7OxGppgj9OnertzMoOPc.IYH7nbWuoXh56Cb5wtRsLCnacmIK", "Mentor", null },
                    { new Guid("6a98836f-c019-4b44-9c87-68e6b76c143b"), "https://material.angular.io/assets/img/examples/shiba1.jpg", true, false, "admin", "Admin", "$2a$11$MhN40fCNzDwAmYNZcs.OF./HqS0O.Qb1vKR13N0cy4TCuHNxzoZmu", "Admin", null },
                    { new Guid("bcf4085c-3c31-486b-b237-ec3e93a9c060"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, false, "user", "User", "$2a$11$J9M75HCd3FmaWmFXkmRtzOdJ8qq5eGUd6dZbxs9LHyt195hpKIaHm", "User", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationEntity_Teams_TeamId",
                table: "EvaluationEntity",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationEntity_User_EvaluatorId",
                table: "EvaluationEntity",
                column: "EvaluatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
