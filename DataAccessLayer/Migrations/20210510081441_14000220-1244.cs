using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002201244 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBooklet",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HasExam",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HasHomework",
                table: "Courses");

            migrationBuilder.AddColumn<bool>(
                name: "HasBooklet",
                table: "CourseMeetings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasExam",
                table: "CourseMeetings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasHomework",
                table: "CourseMeetings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBooklet",
                table: "CourseMeetings");

            migrationBuilder.DropColumn(
                name: "HasExam",
                table: "CourseMeetings");

            migrationBuilder.DropColumn(
                name: "HasHomework",
                table: "CourseMeetings");

            migrationBuilder.AddColumn<bool>(
                name: "HasBooklet",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasExam",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasHomework",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
