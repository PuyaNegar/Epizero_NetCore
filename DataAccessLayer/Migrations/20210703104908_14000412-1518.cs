using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004121518 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdentifierUserId",
                table: "StudentUserProfiles",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "IdentifierChargeSettings",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bool");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserProfiles_IdentifierUserId",
                table: "StudentUserProfiles",
                column: "IdentifierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserProfiles_Users_IdentifierUserId",
                table: "StudentUserProfiles",
                column: "IdentifierUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserProfiles_Users_IdentifierUserId",
                table: "StudentUserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_StudentUserProfiles_IdentifierUserId",
                table: "StudentUserProfiles");

            migrationBuilder.DropColumn(
                name: "IdentifierUserId",
                table: "StudentUserProfiles");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "IdentifierChargeSettings",
                type: "bool",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
