using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006020940 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingStudentId",
                table: "StudentFines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingStudentId",
                table: "StudentFinancialReturnPayments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingStudentId",
                table: "StudentFinancialPayments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentFines_CourseMeetingStudentId",
                table: "StudentFines",
                column: "CourseMeetingStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialReturnPayments_CourseMeetingStudentId",
                table: "StudentFinancialReturnPayments",
                column: "CourseMeetingStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialPayments_CourseMeetingStudentId",
                table: "StudentFinancialPayments",
                column: "CourseMeetingStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFinancialPayments_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFinancialPayments",
                column: "CourseMeetingStudentId",
                principalTable: "CourseMeetingStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFinancialReturnPayments_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFinancialReturnPayments",
                column: "CourseMeetingStudentId",
                principalTable: "CourseMeetingStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFines_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFines",
                column: "CourseMeetingStudentId",
                principalTable: "CourseMeetingStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFinancialPayments_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFinancialPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentFinancialReturnPayments_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFinancialReturnPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentFines_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFines");

            migrationBuilder.DropIndex(
                name: "IX_StudentFines_CourseMeetingStudentId",
                table: "StudentFines");

            migrationBuilder.DropIndex(
                name: "IX_StudentFinancialReturnPayments_CourseMeetingStudentId",
                table: "StudentFinancialReturnPayments");

            migrationBuilder.DropIndex(
                name: "IX_StudentFinancialPayments_CourseMeetingStudentId",
                table: "StudentFinancialPayments");

            migrationBuilder.DropColumn(
                name: "CourseMeetingStudentId",
                table: "StudentFines");

            migrationBuilder.DropColumn(
                name: "CourseMeetingStudentId",
                table: "StudentFinancialReturnPayments");

            migrationBuilder.DropColumn(
                name: "CourseMeetingStudentId",
                table: "StudentFinancialPayments");
        }
    }
}
