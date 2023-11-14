using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007141317 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingStudentId",
                table: "OnlineExamStudents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents",
                column: "CourseMeetingStudentId",
                unique: true,
                filter: "[CourseMeetingStudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExamStudents_CourseMeetingStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents",
                column: "CourseMeetingStudentId",
                principalTable: "CourseMeetingStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
