using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003081244 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherPaymentMethods_TeacherUserId",
                table: "TeacherPaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "TotalDebtAmount",
                table: "TeacherPaymentMethods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalSattledAmount",
                table: "TeacherPaymentMethods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPaymentMethods_TeacherUserId_CourseId",
                table: "TeacherPaymentMethods",
                columns: new[] { "TeacherUserId", "CourseId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherPaymentMethods_TeacherUserId_CourseId",
                table: "TeacherPaymentMethods");

            migrationBuilder.DropColumn(
                name: "TotalDebtAmount",
                table: "TeacherPaymentMethods");

            migrationBuilder.DropColumn(
                name: "TotalSattledAmount",
                table: "TeacherPaymentMethods");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPaymentMethods_TeacherUserId",
                table: "TeacherPaymentMethods",
                column: "TeacherUserId");
        }
    }
}
