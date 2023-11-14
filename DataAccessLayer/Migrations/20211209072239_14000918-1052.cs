using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009181052 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentFinancialDebts_CourseMeetingStudentId",
                table: "StudentFinancialDebts");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialDebts_CourseMeetingStudentId",
                table: "StudentFinancialDebts",
                column: "CourseMeetingStudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentFinancialDebts_CourseMeetingStudentId",
                table: "StudentFinancialDebts");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialDebts_CourseMeetingStudentId",
                table: "StudentFinancialDebts",
                column: "CourseMeetingStudentId");
        }
    }
}
