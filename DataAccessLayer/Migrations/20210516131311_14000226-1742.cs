using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002261742 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CourseMeetings",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "CourseMeetings",
                type: "time(7)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TeacherUserId",
                table: "CourseMeetings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetings_TeacherUserId",
                table: "CourseMeetings",
                column: "TeacherUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeetings_Users_TeacherUserId",
                table: "CourseMeetings",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeetings_Users_TeacherUserId",
                table: "CourseMeetings");

            migrationBuilder.DropIndex(
                name: "IX_CourseMeetings_TeacherUserId",
                table: "CourseMeetings");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CourseMeetings");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "CourseMeetings");

            migrationBuilder.DropColumn(
                name: "TeacherUserId",
                table: "CourseMeetings");
        }
    }
}
