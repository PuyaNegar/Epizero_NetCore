using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003111555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    QuestionContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    StudetUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentQuestions_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentQuestions_Users_StudetUserId",
                        column: x => x.StudetUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    AnswerContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    StudentQuestionId = table.Column<int>(nullable: false),
                    AnswerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentQuestionAnswers_Users_AnswerUserId",
                        column: x => x.AnswerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentQuestionAnswers_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentQuestionAnswers_StudentQuestions_StudentQuestionId",
                        column: x => x.StudentQuestionId,
                        principalTable: "StudentQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionAnswers_AnswerUserId",
                table: "StudentQuestionAnswers",
                column: "AnswerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionAnswers_ModUserId",
                table: "StudentQuestionAnswers",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionAnswers_StudentQuestionId",
                table: "StudentQuestionAnswers",
                column: "StudentQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_ModUserId",
                table: "StudentQuestions",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_StudetUserId",
                table: "StudentQuestions",
                column: "StudetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentQuestionAnswers");

            migrationBuilder.DropTable(
                name: "StudentQuestions");
        }
    }
}
