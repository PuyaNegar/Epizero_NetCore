using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140202211056 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionContext_CkFormat",
                table: "OnlineExamQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option1_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option2_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option3_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option4_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option5_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionContext_CkFormat",
                table: "OnlineExamQuestions");

            migrationBuilder.DropColumn(
                name: "Option1_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "Option2_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "Option3_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "Option4_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "Option5_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions");
        }
    }
}
