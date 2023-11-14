using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002071237 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Courses_CoursesId",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Users_ModUserId",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Users_StudentUsersId",
                table: "CourseStudents");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudents_CoursesId",
                table: "CourseStudents");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudents_StudentUsersId",
                table: "CourseStudents");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "CourseStudents");

            migrationBuilder.DropColumn(
                name: "StudentUsersId",
                table: "CourseStudents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDateTime",
                table: "CourseStudents",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDateTime",
                table: "CourseStudents",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_CourseId",
                table: "CourseStudents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentUserId_CourseId",
                table: "CourseStudents",
                columns: new[] { "StudentUserId", "CourseId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Courses_CourseId",
                table: "CourseStudents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Users_ModUserId",
                table: "CourseStudents",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Users_StudentUserId",
                table: "CourseStudents",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Courses_CourseId",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Users_ModUserId",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Users_StudentUserId",
                table: "CourseStudents");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudents_CourseId",
                table: "CourseStudents");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudents_StudentUserId_CourseId",
                table: "CourseStudents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDateTime",
                table: "CourseStudents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDateTime",
                table: "CourseStudents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "CourseStudents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentUsersId",
                table: "CourseStudents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_CoursesId",
                table: "CourseStudents",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentUsersId",
                table: "CourseStudents",
                column: "StudentUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Courses_CoursesId",
                table: "CourseStudents",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Users_ModUserId",
                table: "CourseStudents",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Users_StudentUsersId",
                table: "CourseStudents",
                column: "StudentUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
