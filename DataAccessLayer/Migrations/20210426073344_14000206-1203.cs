using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002061203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseMeetingStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    CourseMeetingId = table.Column<int>(nullable: false),
                    StudentUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeetingStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMeetingStudents_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingStudents_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingStudents_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingStudents_CourseMeetingId",
                table: "CourseMeetingStudents",
                column: "CourseMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingStudents_ModUserId",
                table: "CourseMeetingStudents",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingStudents_StudentUserId_CourseMeetingId",
                table: "CourseMeetingStudents",
                columns: new[] { "StudentUserId", "CourseMeetingId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMeetingStudents");
        }
    }
}
