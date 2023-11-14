using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004141253 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserSMSOptions_Users_ModUserId",
                table: "StudentUserSMSOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserSMSOptions_SMSOptions_SMSOptionId",
                table: "StudentUserSMSOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserSMSOptions_Users_StudentUserId",
                table: "StudentUserSMSOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentUserSMSOptions",
                table: "StudentUserSMSOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SMSOptions",
                table: "SMSOptions");

            migrationBuilder.RenameTable(
                name: "StudentUserSMSOptions",
                newName: "StudentUserSmsOptions");

            migrationBuilder.RenameTable(
                name: "SMSOptions",
                newName: "SmsOptions");

            migrationBuilder.RenameColumn(
                name: "SMSOptionId",
                table: "StudentUserSmsOptions",
                newName: "SmsOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentUserSMSOptions_StudentUserId",
                table: "StudentUserSmsOptions",
                newName: "IX_StudentUserSmsOptions_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentUserSMSOptions_SMSOptionId",
                table: "StudentUserSmsOptions",
                newName: "IX_StudentUserSmsOptions_SmsOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentUserSMSOptions_ModUserId",
                table: "StudentUserSmsOptions",
                newName: "IX_StudentUserSmsOptions_ModUserId");

            migrationBuilder.AddColumn<int>(
                name: "SMSCredit",
                table: "StudentUserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentUserSmsOptions",
                table: "StudentUserSmsOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmsOptions",
                table: "SmsOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserSmsOptions_Users_ModUserId",
                table: "StudentUserSmsOptions",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserSmsOptions_SmsOptions_SmsOptionId",
                table: "StudentUserSmsOptions",
                column: "SmsOptionId",
                principalTable: "SmsOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserSmsOptions_Users_StudentUserId",
                table: "StudentUserSmsOptions",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserSmsOptions_Users_ModUserId",
                table: "StudentUserSmsOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserSmsOptions_SmsOptions_SmsOptionId",
                table: "StudentUserSmsOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserSmsOptions_Users_StudentUserId",
                table: "StudentUserSmsOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentUserSmsOptions",
                table: "StudentUserSmsOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmsOptions",
                table: "SmsOptions");

            migrationBuilder.DropColumn(
                name: "SMSCredit",
                table: "StudentUserProfiles");

            migrationBuilder.RenameTable(
                name: "StudentUserSmsOptions",
                newName: "StudentUserSMSOptions");

            migrationBuilder.RenameTable(
                name: "SmsOptions",
                newName: "SMSOptions");

            migrationBuilder.RenameColumn(
                name: "SmsOptionId",
                table: "StudentUserSMSOptions",
                newName: "SMSOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentUserSmsOptions_StudentUserId",
                table: "StudentUserSMSOptions",
                newName: "IX_StudentUserSMSOptions_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentUserSmsOptions_SmsOptionId",
                table: "StudentUserSMSOptions",
                newName: "IX_StudentUserSMSOptions_SMSOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentUserSmsOptions_ModUserId",
                table: "StudentUserSMSOptions",
                newName: "IX_StudentUserSMSOptions_ModUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentUserSMSOptions",
                table: "StudentUserSMSOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SMSOptions",
                table: "SMSOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserSMSOptions_Users_ModUserId",
                table: "StudentUserSMSOptions",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserSMSOptions_SMSOptions_SMSOptionId",
                table: "StudentUserSMSOptions",
                column: "SMSOptionId",
                principalTable: "SMSOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserSMSOptions_Users_StudentUserId",
                table: "StudentUserSMSOptions",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
