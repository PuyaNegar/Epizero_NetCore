using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003031445 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Homeworks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswers_HomeWorkId",
                table: "HomeworkAnswers",
                column: "HomeWorkId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HomeworkAnswers_HomeWorkId",
                table: "HomeworkAnswers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Homeworks");
        }
    }
}
