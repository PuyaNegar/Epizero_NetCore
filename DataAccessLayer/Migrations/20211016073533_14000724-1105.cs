using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007241105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeacherUserId",
                table: "OnlineExams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_TeacherUserId",
                table: "OnlineExams",
                column: "TeacherUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_Users_TeacherUserId",
                table: "OnlineExams",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_Users_TeacherUserId",
                table: "OnlineExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_TeacherUserId",
                table: "OnlineExams");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherUserId",
                table: "OnlineExams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
