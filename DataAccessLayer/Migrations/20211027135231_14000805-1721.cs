using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140008051721 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Option5",
                table: "MultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "Option5_Html",
                table: "MultipleChoiceQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserLoginLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserLoginLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Option5",
                table: "MultipleChoiceQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option5_Html",
                table: "MultipleChoiceQuestions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
