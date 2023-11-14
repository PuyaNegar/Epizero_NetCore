using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007071726 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_CourseMeetings_CourseMeetingsModelId",
                table: "OnlineExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExamStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_CourseMeetingsModelId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "CourseMeetingsModelId",
                table: "OnlineExams");

            migrationBuilder.AlterColumn<int>(
                name: "CourseMeetingStudentId",
                table: "OnlineExamStudents",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents",
                column: "CourseMeetingStudentId",
                unique: true,
                filter: "[CourseMeetingStudentId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OnlineExamStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents");

            migrationBuilder.AlterColumn<int>(
                name: "CourseMeetingStudentId",
                table: "OnlineExamStudents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingsModelId",
                table: "OnlineExams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudents_CourseMeetingStudentId",
                table: "OnlineExamStudents",
                column: "CourseMeetingStudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_CourseMeetingsModelId",
                table: "OnlineExams",
                column: "CourseMeetingsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_CourseMeetings_CourseMeetingsModelId",
                table: "OnlineExams",
                column: "CourseMeetingsModelId",
                principalTable: "CourseMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
