using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002151610 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_Users_TeacherUserId",
                table: "OnlineExams");

            migrationBuilder.DropTable(
                name: "CoursePromoSections");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_TeacherUserId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "TeacherUserId",
                table: "OnlineExams");

            migrationBuilder.AddColumn<int>(
                name: "UsersModelId",
                table: "OnlineExams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CoursePromos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    CoursePromoSectionGroupId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePromos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePromos_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursePromos_CoursePromoSectionGroups_CoursePromoSectionGroupId",
                        column: x => x.CoursePromoSectionGroupId,
                        principalTable: "CoursePromoSectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursePromos_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_UsersModelId",
                table: "OnlineExams",
                column: "UsersModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromos_CourseId",
                table: "CoursePromos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromos_CoursePromoSectionGroupId",
                table: "CoursePromos",
                column: "CoursePromoSectionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromos_ModUserId",
                table: "CoursePromos",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_Users_UsersModelId",
                table: "OnlineExams",
                column: "UsersModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_Users_UsersModelId",
                table: "OnlineExams");

            migrationBuilder.DropTable(
                name: "CoursePromos");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_UsersModelId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "UsersModelId",
                table: "OnlineExams");

            migrationBuilder.AddColumn<int>(
                name: "TeacherUserId",
                table: "OnlineExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CoursePromoSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CoursePromoSectionGroupId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePromoSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePromoSections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursePromoSections_CoursePromoSectionGroups_CoursePromoSectionGroupId",
                        column: x => x.CoursePromoSectionGroupId,
                        principalTable: "CoursePromoSectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursePromoSections_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_TeacherUserId",
                table: "OnlineExams",
                column: "TeacherUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromoSections_CourseId",
                table: "CoursePromoSections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromoSections_CoursePromoSectionGroupId",
                table: "CoursePromoSections",
                column: "CoursePromoSectionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromoSections_ModUserId",
                table: "CoursePromoSections",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_Users_TeacherUserId",
                table: "OnlineExams",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
