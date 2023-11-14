using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140202211136 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptiveAnswer_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptiveAnswer_CkFormat",
                table: "OnlineExamMultipleChoiceQuestions");
        }
    }
}
