using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140010121445 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFinancialManualDebts_CourseMeetings_CourseMeetingId",
                table: "StudentFinancialManualDebts");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "StudentFinancialManualDebts");

            migrationBuilder.RenameColumn(
                name: "CourseMeetingId",
                table: "StudentFinancialManualDebts",
                newName: "CourseMeetingStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentFinancialManualDebts_CourseMeetingId",
                table: "StudentFinancialManualDebts",
                newName: "IX_StudentFinancialManualDebts_CourseMeetingStudentId");

            migrationBuilder.AddColumn<long>(
                name: "DebtAmount",
                table: "StudentFinancialManualDebts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFinancialManualDebts_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFinancialManualDebts",
                column: "CourseMeetingStudentId",
                principalTable: "CourseMeetingStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFinancialManualDebts_CourseMeetingStudents_CourseMeetingStudentId",
                table: "StudentFinancialManualDebts");

            migrationBuilder.DropColumn(
                name: "DebtAmount",
                table: "StudentFinancialManualDebts");

            migrationBuilder.RenameColumn(
                name: "CourseMeetingStudentId",
                table: "StudentFinancialManualDebts",
                newName: "CourseMeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentFinancialManualDebts_CourseMeetingStudentId",
                table: "StudentFinancialManualDebts",
                newName: "IX_StudentFinancialManualDebts_CourseMeetingId");

            migrationBuilder.AddColumn<long>(
                name: "Amount",
                table: "StudentFinancialManualDebts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFinancialManualDebts_CourseMeetings_CourseMeetingId",
                table: "StudentFinancialManualDebts",
                column: "CourseMeetingId",
                principalTable: "CourseMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
