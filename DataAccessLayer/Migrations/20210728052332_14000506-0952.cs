using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140005060952 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_NationalCode",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalCode_UserGroupId",
                table: "Users",
                columns: new[] { "NationalCode", "UserGroupId" },
                unique: true,
                filter: "[NationalCode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_NationalCode_UserGroupId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalCode",
                table: "Users",
                column: "NationalCode",
                unique: true,
                filter: "[NationalCode] IS NOT NULL");
        }
    }
}
