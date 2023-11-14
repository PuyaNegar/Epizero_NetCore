using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140204181430 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseStudentQuestionLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    CourseStudentQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudentQuestionLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseStudentQuestionLikes_CourseStudentQuestions_CourseStudentQuestionId",
                        column: x => x.CourseStudentQuestionId,
                        principalTable: "CourseStudentQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStudentQuestionLikes_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStudentQuestionLikes_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentQuestionLikes_CourseStudentQuestionId",
                table: "CourseStudentQuestionLikes",
                column: "CourseStudentQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentQuestionLikes_ModUserId",
                table: "CourseStudentQuestionLikes",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentQuestionLikes_StudentUserId",
                table: "CourseStudentQuestionLikes",
                column: "StudentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudentQuestionLikes");
        }
    }
}
