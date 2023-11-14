using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007071305 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingStudentId",
                table: "OnlineExamStudents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents",
                column: "CourseMeetingStudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExamStudents_CourseMeetingStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents",
                column: "CourseMeetingStudentId",
                principalTable: "CourseMeetingStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExamStudents_CourseMeetingStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExamStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents");

            migrationBuilder.DropColumn(
                name: "CourseMeetingStudentId",
                table: "OnlineExamStudents");
        }
    }
}
