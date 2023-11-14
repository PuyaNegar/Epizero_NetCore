using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140204180932 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentQuestionLikes_Users_ModUserId",
                table: "CourseStudentQuestionLikes");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudentQuestionLikes_ModUserId",
                table: "CourseStudentQuestionLikes");

            migrationBuilder.DropColumn(
                name: "ModDateTime",
                table: "CourseStudentQuestionLikes");

            migrationBuilder.DropColumn(
                name: "ModUserId",
                table: "CourseStudentQuestionLikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModDateTime",
                table: "CourseStudentQuestionLikes",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModUserId",
                table: "CourseStudentQuestionLikes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentQuestionLikes_ModUserId",
                table: "CourseStudentQuestionLikes",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentQuestionLikes_Users_ModUserId",
                table: "CourseStudentQuestionLikes",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
