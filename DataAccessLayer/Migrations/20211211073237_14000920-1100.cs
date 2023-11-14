using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009201100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseMeetingDedicatedTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false),
                    TeacherUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeetingDedicatedTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMeetingDedicatedTeachers_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingDedicatedTeachers_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingDedicatedTeachers_Users_TeacherUserId",
                        column: x => x.TeacherUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingDedicatedTeachers_CourseMeetingId",
                table: "CourseMeetingDedicatedTeachers",
                column: "CourseMeetingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingDedicatedTeachers_ModUserId",
                table: "CourseMeetingDedicatedTeachers",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingDedicatedTeachers_TeacherUserId",
                table: "CourseMeetingDedicatedTeachers",
                column: "TeacherUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMeetingDedicatedTeachers");
        }
    }
}
