using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140010041523 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseMultiTeacherShares_TeacherUserId",
                table: "CourseMultiTeacherShares");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMultiTeacherShares_TeacherUserId_CourseId",
                table: "CourseMultiTeacherShares",
                columns: new[] { "TeacherUserId", "CourseId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseMultiTeacherShares_TeacherUserId_CourseId",
                table: "CourseMultiTeacherShares");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMultiTeacherShares_TeacherUserId",
                table: "CourseMultiTeacherShares",
                column: "TeacherUserId");
        }
    }
}
