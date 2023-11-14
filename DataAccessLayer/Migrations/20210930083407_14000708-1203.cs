using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007081203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams");

            migrationBuilder.AlterColumn<int>(
                name: "CourseMeetingId",
                table: "OnlineExams",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams",
                column: "CourseMeetingId",
                unique: true,
                filter: "[CourseMeetingId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams");

            migrationBuilder.AlterColumn<int>(
                name: "CourseMeetingId",
                table: "OnlineExams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams",
                column: "CourseMeetingId",
                unique: true);
        }
    }
}
