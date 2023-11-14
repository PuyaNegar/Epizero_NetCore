using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002041228 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserPrefixes_TeacherUserPrefixId",
                table: "TeacherUserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_TeacherUserProfiles_TeacherUserPrefixId",
                table: "TeacherUserProfiles");

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeacherUserPrefixId",
                table: "TeacherUserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "TeacherPrefixId",
                table: "TeacherUserProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUserProfiles_TeacherPrefixId",
                table: "TeacherUserProfiles",
                column: "TeacherPrefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserPrefixes_TeacherPrefixId",
                table: "TeacherUserProfiles",
                column: "TeacherPrefixId",
                principalTable: "TeacherUserPrefixes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserPrefixes_TeacherPrefixId",
                table: "TeacherUserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_TeacherUserProfiles_TeacherPrefixId",
                table: "TeacherUserProfiles");

            migrationBuilder.DropColumn(
                name: "TeacherPrefixId",
                table: "TeacherUserProfiles");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherUserPrefixId",
                table: "TeacherUserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUserProfiles_TeacherUserPrefixId",
                table: "TeacherUserProfiles",
                column: "TeacherUserPrefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserPrefixes_TeacherUserPrefixId",
                table: "TeacherUserProfiles",
                column: "TeacherUserPrefixId",
                principalTable: "TeacherUserPrefixes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
