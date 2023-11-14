using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003121838 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedDateTime",
                table: "CourseStudentQuestions",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedDateTime",
                table: "CourseStudentQuestionAnswers",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerifiedDateTime",
                table: "CourseStudentQuestions");

            migrationBuilder.DropColumn(
                name: "VerifiedDateTime",
                table: "CourseStudentQuestionAnswers");
        }
    }
}
