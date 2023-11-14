using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002151632 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePromos_CoursePromoSectionGroups_CoursePromoSectionGroupId",
                table: "CoursePromos");

            migrationBuilder.DropTable(
                name: "CoursePromoSectionGroups");

            migrationBuilder.RenameColumn(
                name: "CoursePromoSectionGroupId",
                table: "CoursePromos",
                newName: "CoursePromoSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CoursePromos_CoursePromoSectionGroupId",
                table: "CoursePromos",
                newName: "IX_CoursePromos_CoursePromoSectionId");

            migrationBuilder.CreateTable(
                name: "CoursePromoSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePromoSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePromoSections_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromoSections_ModUserId",
                table: "CoursePromoSections",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePromos_CoursePromoSections_CoursePromoSectionId",
                table: "CoursePromos",
                column: "CoursePromoSectionId",
                principalTable: "CoursePromoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePromos_CoursePromoSections_CoursePromoSectionId",
                table: "CoursePromos");

            migrationBuilder.DropTable(
                name: "CoursePromoSections");

            migrationBuilder.RenameColumn(
                name: "CoursePromoSectionId",
                table: "CoursePromos",
                newName: "CoursePromoSectionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_CoursePromos_CoursePromoSectionId",
                table: "CoursePromos",
                newName: "IX_CoursePromos_CoursePromoSectionGroupId");

            migrationBuilder.CreateTable(
                name: "CoursePromoSectionGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePromoSectionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePromoSectionGroups_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePromoSectionGroups_ModUserId",
                table: "CoursePromoSectionGroups",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePromos_CoursePromoSectionGroups_CoursePromoSectionGroupId",
                table: "CoursePromos",
                column: "CoursePromoSectionGroupId",
                principalTable: "CoursePromoSectionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
