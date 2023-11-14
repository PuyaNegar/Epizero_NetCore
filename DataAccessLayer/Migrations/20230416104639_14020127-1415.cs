using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140201271415 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionAudioPath",
                table: "CourseStudentQuestions",
                newName: "AudioPath");

            migrationBuilder.AddColumn<string>(
                name: "AnswerFilePath",
                table: "CourseStudentQuestionAnswers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnswerPicPath",
                table: "CourseStudentQuestionAnswers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudioPath",
                table: "CourseStudentQuestionAnswers",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerFilePath",
                table: "CourseStudentQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "AnswerPicPath",
                table: "CourseStudentQuestionAnswers");

            migrationBuilder.DropColumn(
                name: "AudioPath",
                table: "CourseStudentQuestionAnswers");

            migrationBuilder.RenameColumn(
                name: "AudioPath",
                table: "CourseStudentQuestions",
                newName: "QuestionAudioPath");
        }
    }
}
