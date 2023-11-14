using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007030944 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inx",
                table: "LessonTopics");

            migrationBuilder.AddColumn<string>(
                name: "ParentRoute",
                table: "LessonTopics",
                type: "NVARCHAR(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentRoute",
                table: "LessonTopics");

            migrationBuilder.AddColumn<int>(
                name: "Inx",
                table: "LessonTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
