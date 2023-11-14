using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140008251615 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Absentations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absentations_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absentations_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absentations_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absentations_CourseMeetingId",
                table: "Absentations",
                column: "CourseMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Absentations_ModUserId",
                table: "Absentations",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Absentations_StudentUserId",
                table: "Absentations",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Absentations_Date_StudentUserId",
                table: "Absentations",
                columns: new[] { "Date", "StudentUserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absentations");
        }
    }
}
