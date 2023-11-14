using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140005021457 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentUserSmsOptions_SmsOptionId",
                table: "StudentUserSmsOptions");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserSmsOptions_SmsOptionId_StudentUserId",
                table: "StudentUserSmsOptions",
                columns: new[] { "SmsOptionId", "StudentUserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentUserSmsOptions_SmsOptionId_StudentUserId",
                table: "StudentUserSmsOptions");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserSmsOptions_SmsOptionId",
                table: "StudentUserSmsOptions",
                column: "SmsOptionId");
        }
    }
}
