using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007251318 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAbsentOnMainTime",
                table: "OnlineExamStudents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAbleToEnterExpiredExam",
                table: "OnlineExams",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAbsentOnMainTime",
                table: "OnlineExamStudents");

            migrationBuilder.DropColumn(
                name: "IsAbleToEnterExpiredExam",
                table: "OnlineExams");
        }
    }
}
