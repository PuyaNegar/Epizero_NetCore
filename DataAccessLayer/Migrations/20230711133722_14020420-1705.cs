using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140204201705 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModDateTime",
                table: "CourseStudentNewComments",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModUserId",
                table: "CourseStudentNewComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentNewComments_ModUserId",
                table: "CourseStudentNewComments",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentNewComments_Users_ModUserId",
                table: "CourseStudentNewComments",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentNewComments_Users_ModUserId",
                table: "CourseStudentNewComments");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudentNewComments_ModUserId",
                table: "CourseStudentNewComments");

            migrationBuilder.DropColumn(
                name: "ModDateTime",
                table: "CourseStudentNewComments");

            migrationBuilder.DropColumn(
                name: "ModUserId",
                table: "CourseStudentNewComments");
        }
    }
}
