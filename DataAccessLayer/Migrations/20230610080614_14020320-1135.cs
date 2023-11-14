using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140203201135 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserScores");

            migrationBuilder.DropTable(
                name: "UserScoreTypes");

            migrationBuilder.CreateTable(
                name: "StudentUserScoreTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserScoreTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    UserScoreTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUserScores_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserScores_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserScores_StudentUserScoreTypes_UserScoreTypeId",
                        column: x => x.UserScoreTypeId,
                        principalTable: "StudentUserScoreTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserScores_ModUserId",
                table: "StudentUserScores",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserScores_StudentUserId",
                table: "StudentUserScores",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserScores_UserScoreTypeId",
                table: "StudentUserScores",
                column: "UserScoreTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUserScores");

            migrationBuilder.DropTable(
                name: "StudentUserScoreTypes");

            migrationBuilder.CreateTable(
                name: "UserScoreTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScoreTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserScoreTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserScores_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserScores_UserScoreTypes_UserScoreTypeId",
                        column: x => x.UserScoreTypeId,
                        principalTable: "UserScoreTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserScores_UserId",
                table: "UserScores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScores_UserScoreTypeId",
                table: "UserScores",
                column: "UserScoreTypeId");
        }
    }
}
