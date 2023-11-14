using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140110171111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTextQuestionContext",
                table: "OnlineExamQuestions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTextOption1",
                table: "OnlineExamMultipleChoiceQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTextOption2",
                table: "OnlineExamMultipleChoiceQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTextOption3",
                table: "OnlineExamMultipleChoiceQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTextOption4",
                table: "OnlineExamMultipleChoiceQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTextQuestionContext",
                table: "OnlineExamQuestions");

            migrationBuilder.DropColumn(
                name: "IsTextOption1",
                table: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "IsTextOption2",
                table: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "IsTextOption3",
                table: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "IsTextOption4",
                table: "OnlineExamMultipleChoiceQuestions");
        }
    }
}
