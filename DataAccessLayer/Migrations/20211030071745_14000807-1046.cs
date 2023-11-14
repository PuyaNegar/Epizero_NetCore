using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140008071046 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLoginLogs_StudentUserId",
                table: "UserLoginLogs");

            migrationBuilder.RenameColumn(
                name: "UserAgent",
                table: "UserLoginLogs",
                newName: "LastUserAgent");

            migrationBuilder.RenameColumn(
                name: "RegDateTime",
                table: "UserLoginLogs",
                newName: "LastLoginDateTime");

            migrationBuilder.RenameColumn(
                name: "Ip",
                table: "UserLoginLogs",
                newName: "LastIp");

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "UserLoginLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLogs_StudentUserId_Guid",
                table: "UserLoginLogs",
                columns: new[] { "StudentUserId", "Guid" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLoginLogs_StudentUserId_Guid",
                table: "UserLoginLogs");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "UserLoginLogs");

            migrationBuilder.RenameColumn(
                name: "LastUserAgent",
                table: "UserLoginLogs",
                newName: "UserAgent");

            migrationBuilder.RenameColumn(
                name: "LastLoginDateTime",
                table: "UserLoginLogs",
                newName: "RegDateTime");

            migrationBuilder.RenameColumn(
                name: "LastIp",
                table: "UserLoginLogs",
                newName: "Ip");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLogs_StudentUserId",
                table: "UserLoginLogs",
                column: "StudentUserId");
        }
    }
}
