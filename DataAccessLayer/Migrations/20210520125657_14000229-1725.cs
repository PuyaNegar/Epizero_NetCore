using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002291725 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeworkAnswerFiles");

            migrationBuilder.DropTable(
                name: "HomeworkFiles");

            migrationBuilder.DropColumn(
                name: "Context",
                table: "Homeworks");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Homeworks",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "HomeworkAnswers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "HomeworkAnswers",
                type: "nvarchar(300)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "HomeworkAnswers");

            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "Homeworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "HomeworkAnswers",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HomeworkAnswerFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    HomeworkAnswerId = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkAnswerFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkAnswerFiles_HomeworkAnswers_HomeworkAnswerId",
                        column: x => x.HomeworkAnswerId,
                        principalTable: "HomeworkAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkAnswerFiles_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    HomeworkId = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkFiles_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkFiles_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswerFiles_HomeworkAnswerId",
                table: "HomeworkAnswerFiles",
                column: "HomeworkAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswerFiles_ModUserId",
                table: "HomeworkAnswerFiles",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkFiles_HomeworkId",
                table: "HomeworkFiles",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkFiles_ModUserId",
                table: "HomeworkFiles",
                column: "ModUserId");
        }
    }
}
