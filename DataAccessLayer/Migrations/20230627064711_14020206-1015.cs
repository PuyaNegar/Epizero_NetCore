using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140202061015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWebSite",
                table: "FAQ",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CourseFAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inx = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    FAQId = table.Column<int>(type: "int", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFAQs_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseFAQs_FAQ_FAQId",
                        column: x => x.FAQId,
                        principalTable: "FAQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseFAQs_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFAQs_CourseId",
                table: "CourseFAQs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFAQs_FAQId",
                table: "CourseFAQs",
                column: "FAQId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFAQs_ModUserId",
                table: "CourseFAQs",
                column: "ModUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseFAQs");

            migrationBuilder.DropColumn(
                name: "IsWebSite",
                table: "FAQ");
        }
    }
}
