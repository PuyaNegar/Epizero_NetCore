using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140008060951 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLogs_Users_UserId",
                table: "UserLoginLogs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserLoginLogs",
                newName: "StudentUserId");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "UserLoginLogs",
                newName: "RegDateTime");

            migrationBuilder.RenameIndex(
                name: "IX_UserLoginLogs_UserId",
                table: "UserLoginLogs",
                newName: "IX_UserLoginLogs_StudentUserId");

            migrationBuilder.AddColumn<int>(
                name: "UsersModelId",
                table: "UserLoginLogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLogs_UsersModelId",
                table: "UserLoginLogs",
                column: "UsersModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginLogs_Users_StudentUserId",
                table: "UserLoginLogs",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginLogs_Users_UsersModelId",
                table: "UserLoginLogs",
                column: "UsersModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLogs_Users_StudentUserId",
                table: "UserLoginLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLogs_Users_UsersModelId",
                table: "UserLoginLogs");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginLogs_UsersModelId",
                table: "UserLoginLogs");

            migrationBuilder.DropColumn(
                name: "UsersModelId",
                table: "UserLoginLogs");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "UserLoginLogs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RegDateTime",
                table: "UserLoginLogs",
                newName: "DateTime");

            migrationBuilder.RenameIndex(
                name: "IX_UserLoginLogs_StudentUserId",
                table: "UserLoginLogs",
                newName: "IX_UserLoginLogs_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginLogs_Users_UserId",
                table: "UserLoginLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
