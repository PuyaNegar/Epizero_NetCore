using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140011102030 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentUserMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnsweredQuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnsweredDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUserMessages_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserMessages_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserMessages_ModUserId",
                table: "StudentUserMessages",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserMessages_StudentUserId",
                table: "StudentUserMessages",
                column: "StudentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUserMessages");
        }
    }
}
