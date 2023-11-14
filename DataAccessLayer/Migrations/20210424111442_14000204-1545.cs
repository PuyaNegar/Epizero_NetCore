using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002041545 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Provinces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModDateTime",
                table: "Provinces",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModUserId",
                table: "Provinces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegDateTime",
                table: "Provinces",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModDateTime",
                table: "Cities",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModUserId",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegDateTime",
                table: "Cities",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ModUserId",
                table: "Provinces",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ModUserId",
                table: "Cities",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Users_ModUserId",
                table: "Cities",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Users_ModUserId",
                table: "Provinces",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Users_ModUserId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Users_ModUserId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_ModUserId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Cities_ModUserId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "ModDateTime",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "ModUserId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "RegDateTime",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ModDateTime",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ModUserId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "RegDateTime",
                table: "Cities");
        }
    }
}
