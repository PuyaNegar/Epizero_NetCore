using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007071535 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams");

            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingsModelId",
                table: "OnlineExams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams",
                column: "CourseMeetingId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_CourseMeetings_CourseMeetingsModelId",
                table: "OnlineExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_CourseMeetingsModelId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "CourseMeetingsModelId",
                table: "OnlineExams");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_CourseMeetingId",
                table: "OnlineExams",
                column: "CourseMeetingId");
        }
    }
}
