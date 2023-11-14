using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140012181300 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseNotifications_Users_ModUserId",
                table: "CourseNotifications");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CourseNotifications");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "CourseNotifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CourseNotifications");

            migrationBuilder.DropColumn(
                name: "ModDateTime",
                table: "CourseNotifications");

            migrationBuilder.DropColumn(
                name: "RegDateTime",
                table: "CourseNotifications");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CourseNotifications");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "CourseNotifications");

            migrationBuilder.RenameColumn(
                name: "ModUserId",
                table: "CourseNotifications",
                newName: "NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseNotifications_ModUserId",
                table: "CourseNotifications",
                newName: "IX_CourseNotifications_NotificationId");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ModUserId",
                table: "Notifications",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseNotifications_Notifications_NotificationId",
                table: "CourseNotifications",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseNotifications_Notifications_NotificationId",
                table: "CourseNotifications");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "CourseNotifications",
                newName: "ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseNotifications_NotificationId",
                table: "CourseNotifications",
                newName: "IX_CourseNotifications_ModUserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CourseNotifications",
                type: "nvarchar(2000)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "CourseNotifications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CourseNotifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModDateTime",
                table: "CourseNotifications",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegDateTime",
                table: "CourseNotifications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CourseNotifications",
                type: "nvarchar(300)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "CourseNotifications",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_CourseNotifications_Users_ModUserId",
                table: "CourseNotifications",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
