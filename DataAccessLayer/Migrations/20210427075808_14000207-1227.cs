using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002071227 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseMeetingOnlineExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    OnlineExamId = table.Column<int>(type: "int", nullable: false),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeetingOnlineExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMeetingOnlineExams_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingOnlineExams_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingOnlineExams_OnlineExams_OnlineExamId",
                        column: x => x.OnlineExamId,
                        principalTable: "OnlineExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingOnlineExams_ModUserId",
                table: "CourseMeetingOnlineExams",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingOnlineExams_OnlineExamId",
                table: "CourseMeetingOnlineExams",
                column: "OnlineExamId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingOnlineExams_CourseMeetingId_OnlineExamId",
                table: "CourseMeetingOnlineExams",
                columns: new[] { "CourseMeetingId", "OnlineExamId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMeetingOnlineExams");
        }
    }
}
