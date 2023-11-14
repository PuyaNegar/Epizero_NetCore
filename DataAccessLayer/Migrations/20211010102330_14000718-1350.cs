using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007181350 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptiveAnswer",
                table: "OnlineExamMultipleChoiceQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptiveAnswer",
                table: "MultipleChoiceQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptiveAnswer_Html",
                table: "MultipleChoiceQuestions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptiveAnswer",
                table: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "DescriptiveAnswer",
                table: "MultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "DescriptiveAnswer_Html",
                table: "MultipleChoiceQuestions");
        }
    }
}
