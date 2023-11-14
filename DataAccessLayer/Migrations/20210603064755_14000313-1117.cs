using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003131117 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMeetingHomeWorkGrades");

            migrationBuilder.AddColumn<int>(
                name: "UnVerifyAnswerCount",
                table: "CourseStudentQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnVerifyAnswerCount",
                table: "CourseStudentQuestions");

            migrationBuilder.CreateTable(
                name: "CourseMeetingHomeWorkGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeetingHomeWorkGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMeetingHomeWorkGrades_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingHomeWorkGrades_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingHomeWorkGrades_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingHomeWorkGrades_CourseMeetingId",
                table: "CourseMeetingHomeWorkGrades",
                column: "CourseMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingHomeWorkGrades_ModUserId",
                table: "CourseMeetingHomeWorkGrades",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingHomeWorkGrades_StudentUserId",
                table: "CourseMeetingHomeWorkGrades",
                column: "StudentUserId");
        }
    }
}
