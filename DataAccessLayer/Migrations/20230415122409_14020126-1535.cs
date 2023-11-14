using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140201261535 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionAudioPath",
                table: "CourseStudentQuestions",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionFilePath",
                table: "CourseStudentQuestions",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionPicPath",
                table: "CourseStudentQuestions",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionAudioPath",
                table: "CourseStudentQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionFilePath",
                table: "CourseStudentQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionPicPath",
                table: "CourseStudentQuestions");
        }
    }
}
