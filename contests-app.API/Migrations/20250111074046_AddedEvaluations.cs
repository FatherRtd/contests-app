using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contests_app.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedEvaluations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18070b67-8ec7-43ba-846c-4bac2e806584"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a269c122-173a-40fc-9251-56974558b05b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c8b7080b-5703-4844-8e51-4fb497394b51"));

            migrationBuilder.CreateTable(
                name: "EvaluationEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    EvaluatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationEntity_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationEntity_User_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("1db8b694-16d7-4cb3-a410-1969b64009c0"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, true, "mentor", "Mentor", "$2a$11$7ygo7OxGppgj9OnertzMoOPc.IYH7nbWuoXh56Cb5wtRsLCnacmIK", "Mentor", null },
                    { new Guid("6a98836f-c019-4b44-9c87-68e6b76c143b"), "https://material.angular.io/assets/img/examples/shiba1.jpg", true, false, "admin", "Admin", "$2a$11$MhN40fCNzDwAmYNZcs.OF./HqS0O.Qb1vKR13N0cy4TCuHNxzoZmu", "Admin", null },
                    { new Guid("bcf4085c-3c31-486b-b237-ec3e93a9c060"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, false, "user", "User", "$2a$11$J9M75HCd3FmaWmFXkmRtzOdJ8qq5eGUd6dZbxs9LHyt195hpKIaHm", "User", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationEntity_EvaluatorId",
                table: "EvaluationEntity",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationEntity_TeamId",
                table: "EvaluationEntity",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationEntity");

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

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("18070b67-8ec7-43ba-846c-4bac2e806584"), "https://material.angular.io/assets/img/examples/shiba1.jpg", true, false, "admin", "Admin", "$2a$11$C.Ul4Cx/U0/yOv2bYxR22ueNRtYYgfjMqWTAPOzruhVN/GeNLk9RO", "Admin", null },
                    { new Guid("a269c122-173a-40fc-9251-56974558b05b"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, true, "mentor", "Mentor", "$2a$11$OubmklCEtei8LtdFcrKrXe4a5.h/zlw2l66DRl1ZV4m2cjjyrbcGG", "Mentor", null },
                    { new Guid("c8b7080b-5703-4844-8e51-4fb497394b51"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, false, "user", "User", "$2a$11$uVqjFNmJ7spWSAPVXOw7TebPUsh/N3X0rQtxbjid1FjNySKwXav3K", "User", null }
                });
        }
    }
}
