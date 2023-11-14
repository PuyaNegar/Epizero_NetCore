using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140110151239 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTextQuestionContext",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTextOption1",
                table: "MultipleChoiceQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTextOption2",
                table: "MultipleChoiceQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTextOption3",
                table: "MultipleChoiceQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTextOption4",
                table: "MultipleChoiceQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTextQuestionContext",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsTextOption1",
                table: "MultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "IsTextOption2",
                table: "MultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "IsTextOption3",
                table: "MultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "IsTextOption4",
                table: "MultipleChoiceQuestions");
        }
    }
}
