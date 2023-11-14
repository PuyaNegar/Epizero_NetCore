using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009201230 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseMultiTeacherShareTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMultiTeacherShareTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseMultiTeacherShares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    AmountOrPercent = table.Column<int>(nullable: false),
                    TeacherUserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseMultiTeacherShareTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMultiTeacherShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMultiTeacherShares_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMultiTeacherShares_CourseMultiTeacherShareTypes_CourseMultiTeacherShareTypeId",
                        column: x => x.CourseMultiTeacherShareTypeId,
                        principalTable: "CourseMultiTeacherShareTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMultiTeacherShares_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMultiTeacherShares_Users_TeacherUserId",
                        column: x => x.TeacherUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMultiTeacherShares_CourseId",
                table: "CourseMultiTeacherShares",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMultiTeacherShares_CourseMultiTeacherShareTypeId",
                table: "CourseMultiTeacherShares",
                column: "CourseMultiTeacherShareTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMultiTeacherShares_ModUserId",
                table: "CourseMultiTeacherShares",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMultiTeacherShares_TeacherUserId",
                table: "CourseMultiTeacherShares",
                column: "TeacherUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMultiTeacherShares");

            migrationBuilder.DropTable(
                name: "CourseMultiTeacherShareTypes");
        }
    }
}
