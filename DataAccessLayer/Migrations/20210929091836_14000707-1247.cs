using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007071247 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingId",
                table: "OnlineExams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherUserId",
                table: "OnlineExams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Inx",
                table: "LessonTopics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams",
                column: "CourseMeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_CourseMeetings_CourseMeetingId",
                table: "OnlineExams",
                column: "CourseMeetingId",
                principalTable: "CourseMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_CourseMeetings_CourseMeetingId",
                table: "OnlineExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "CourseMeetingId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "TeacherUserId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "Inx",
                table: "LessonTopics");
        }
    }
}
