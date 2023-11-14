using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002161318 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuggestionTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TeacherUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestionTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuggestionTeachers_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuggestionTeachers_Users_TeacherUserId",
                        column: x => x.TeacherUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionTeachers_ModUserId",
                table: "SuggestionTeachers",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionTeachers_TeacherUserId",
                table: "SuggestionTeachers",
                column: "TeacherUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuggestionTeachers");
        }
    }
}
