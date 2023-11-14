using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140008060959 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLogs_Users_UsersModelId",
                table: "UserLoginLogs");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginLogs_UsersModelId",
                table: "UserLoginLogs");

            migrationBuilder.DropColumn(
                name: "UsersModelId",
                table: "UserLoginLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersModelId",
                table: "UserLoginLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLogs_UsersModelId",
                table: "UserLoginLogs",
                column: "UsersModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginLogs_Users_UsersModelId",
                table: "UserLoginLogs",
                column: "UsersModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
