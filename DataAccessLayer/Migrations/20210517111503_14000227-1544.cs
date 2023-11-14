using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002271544 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClassesModel_CourseMeetings_CourseMeetingId",
                table: "OnlineClassesModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnlineClassesModel",
                table: "OnlineClassesModel");

            migrationBuilder.RenameTable(
                name: "OnlineClassesModel",
                newName: "OnlineClasses");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClassesModel_CourseMeetingId",
                table: "OnlineClasses",
                newName: "IX_OnlineClasses_CourseMeetingId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "OnlineClasses",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "RecordUrl",
                table: "OnlineClasses",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingId",
                table: "OnlineClasses",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "OnlineClasses",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnlineClasses",
                table: "OnlineClasses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineClasses_MeetingId",
                table: "OnlineClasses",
                column: "MeetingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineClasses_CourseMeetings_CourseMeetingId",
                table: "OnlineClasses",
                column: "CourseMeetingId",
                principalTable: "CourseMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineClasses_CourseMeetings_CourseMeetingId",
                table: "OnlineClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnlineClasses",
                table: "OnlineClasses");

            migrationBuilder.DropIndex(
                name: "IX_OnlineClasses_MeetingId",
                table: "OnlineClasses");

            migrationBuilder.RenameTable(
                name: "OnlineClasses",
                newName: "OnlineClassesModel");

            migrationBuilder.RenameIndex(
                name: "IX_OnlineClasses_CourseMeetingId",
                table: "OnlineClassesModel",
                newName: "IX_OnlineClassesModel_CourseMeetingId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "OnlineClassesModel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "RecordUrl",
                table: "OnlineClassesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingId",
                table: "OnlineClassesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "OnlineClassesModel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnlineClassesModel",
                table: "OnlineClassesModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineClassesModel_CourseMeetings_CourseMeetingId",
                table: "OnlineClassesModel",
                column: "CourseMeetingId",
                principalTable: "CourseMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
