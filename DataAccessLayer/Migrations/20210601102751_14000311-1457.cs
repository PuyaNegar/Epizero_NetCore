using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003111457 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFinancialDebts_Users_CourseStudentId",
                table: "StudentFinancialDebts");

            migrationBuilder.DropIndex(
                name: "IX_StudentFinancialDebts_CourseStudentId",
                table: "StudentFinancialDebts");

            migrationBuilder.DropColumn(
                name: "CourseStudentId",
                table: "StudentFinancialDebts");

            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingStudentId",
                table: "StudentFinancialDebts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialDebts_CourseMeetingStudentId",
                table: "StudentFinancialDebts",
                column: "CourseMeetingStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFinancialDebts_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFinancialDebts",
                column: "CourseMeetingStudentId",
                principalTable: "CourseMeetingStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFinancialDebts_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFinancialDebts");

            migrationBuilder.DropIndex(
                name: "IX_StudentFinancialDebts_CourseMeetingStudentId",
                table: "StudentFinancialDebts");

            migrationBuilder.DropColumn(
                name: "CourseMeetingStudentId",
                table: "StudentFinancialDebts");

            migrationBuilder.AddColumn<int>(
                name: "CourseStudentId",
                table: "StudentFinancialDebts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialDebts_CourseStudentId",
                table: "StudentFinancialDebts",
                column: "CourseStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFinancialDebts_Users_CourseStudentId",
                table: "StudentFinancialDebts",
                column: "CourseStudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
