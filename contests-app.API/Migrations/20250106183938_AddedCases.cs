using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contests_app.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedCases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "SelectedCaseId",
                table: "Teams",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "IsAdmin", "IsMentor", "Login", "Name", "PasswordHash", "SurName", "TeamId" },
                values: new object[,]
                {
                    { new Guid("18070b67-8ec7-43ba-846c-4bac2e806584"), "https://material.angular.io/assets/img/examples/shiba1.jpg", true, false, "admin", "Admin", "$2a$11$C.Ul4Cx/U0/yOv2bYxR22ueNRtYYgfjMqWTAPOzruhVN/GeNLk9RO", "Admin", null },
                    { new Guid("a269c122-173a-40fc-9251-56974558b05b"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, true, "mentor", "Mentor", "$2a$11$OubmklCEtei8LtdFcrKrXe4a5.h/zlw2l66DRl1ZV4m2cjjyrbcGG", "Mentor", null },
                    { new Guid("c8b7080b-5703-4844-8e51-4fb497394b51"), "https://material.angular.io/assets/img/examples/shiba1.jpg", false, false, "user", "User", "$2a$11$uVqjFNmJ7spWSAPVXOw7TebPUsh/N3X0rQtxbjid1FjNySKwXav3K", "User", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SelectedCaseId",
                table: "Teams",
                column: "SelectedCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_OwnerId",
                table: "Cases",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Cases_SelectedCaseId",
                table: "Teams",
                column: "SelectedCaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Cases_SelectedCaseId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Teams_SelectedCaseId",
                table: "Teams");

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

            migrationBuilder.DropColumn(
                name: "SelectedCaseId",
                table: "Teams");

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
    }
}
