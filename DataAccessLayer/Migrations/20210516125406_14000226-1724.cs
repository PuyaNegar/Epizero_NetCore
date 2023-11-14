using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002261724 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseMeetingHomeWorkGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MeetingAbsentations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingAbsentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingAbsentations_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingAbsentations_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingAbsentations_Users_StudentUserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAbsentations_CourseMeetingId",
                table: "MeetingAbsentations",
                column: "CourseMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAbsentations_ModUserId",
                table: "MeetingAbsentations",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAbsentations_StudentUserId",
                table: "MeetingAbsentations",
                column: "StudentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMeetingHomeWorkGrades");

            migrationBuilder.DropTable(
                name: "MeetingAbsentations");
        }
    }
}
