using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003031711 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HomeworkAnswers_HomeWorkId",
                table: "HomeworkAnswers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswers_HomeWorkId",
                table: "HomeworkAnswers",
                column: "HomeWorkId",
                unique: true);
        }
    }
}
