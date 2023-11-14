using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140010221835 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Absentations_Date_StudentUserId",
                table: "Absentations");

            migrationBuilder.CreateIndex(
                name: "IX_Absentations_Date_StudentUserId_CourseMeetingId",
                table: "Absentations",
                columns: new[] { "Date", "StudentUserId", "CourseMeetingId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Absentations_Date_StudentUserId_CourseMeetingId",
                table: "Absentations");

            migrationBuilder.CreateIndex(
                name: "IX_Absentations_Date_StudentUserId",
                table: "Absentations",
                columns: new[] { "Date", "StudentUserId" },
                unique: true);
        }
    }
}
