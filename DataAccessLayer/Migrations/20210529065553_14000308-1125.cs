using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003081125 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "StudentUserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserProfiles_LevelId",
                table: "StudentUserProfiles",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserProfiles_Levels_LevelId",
                table: "StudentUserProfiles",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserProfiles_Levels_LevelId",
                table: "StudentUserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_StudentUserProfiles_LevelId",
                table: "StudentUserProfiles");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "StudentUserProfiles");
        }
    }
}
