using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contests_app.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Teams_OwnedTeamId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_OwnedTeamId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OwnedTeamId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OwnerId",
                table: "Teams",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_User_OwnerId",
                table: "Teams",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_User_OwnerId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_OwnerId",
                table: "Teams");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnedTeamId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_OwnedTeamId",
                table: "User",
                column: "OwnedTeamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Teams_OwnedTeamId",
                table: "User",
                column: "OwnedTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
