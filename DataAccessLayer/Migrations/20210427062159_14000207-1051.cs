using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002071051 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePromoSections_CoursePromoSectionGroups_PromoSectionId",
                table: "CoursePromoSections");

            migrationBuilder.RenameColumn(
                name: "PromoSectionId",
                table: "CoursePromoSections",
                newName: "CoursePromoSectionGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_CoursePromoSections_PromoSectionId",
                table: "CoursePromoSections",
                newName: "IX_CoursePromoSections_CoursePromoSectionGroupId");

            migrationBuilder.CreateTable(
                name: "ProductPromoSectionGroups",
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
                    table.PrimaryKey("PK_ProductPromoSectionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPromoSectionGroups_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPromoSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    ProductPromoSectionGroupId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPromoSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPromoSections_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPromoSections_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPromoSections_ProductPromoSectionGroups_ProductPromoSectionGroupId",
                        column: x => x.ProductPromoSectionGroupId,
                        principalTable: "ProductPromoSectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromoSectionGroups_ModUserId",
                table: "ProductPromoSectionGroups",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromoSections_ModUserId",
                table: "ProductPromoSections",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromoSections_ProductId",
                table: "ProductPromoSections",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromoSections_ProductPromoSectionGroupId",
                table: "ProductPromoSections",
                column: "ProductPromoSectionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePromoSections_CoursePromoSectionGroups_CoursePromoSectionGroupId",
                table: "CoursePromoSections",
                column: "CoursePromoSectionGroupId",
                principalTable: "CoursePromoSectionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursePromoSections_CoursePromoSectionGroups_CoursePromoSectionGroupId",
                table: "CoursePromoSections");

            migrationBuilder.DropTable(
                name: "ProductPromoSections");

            migrationBuilder.DropTable(
                name: "ProductPromoSectionGroups");

            migrationBuilder.RenameColumn(
                name: "CoursePromoSectionGroupId",
                table: "CoursePromoSections",
                newName: "PromoSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CoursePromoSections_CoursePromoSectionGroupId",
                table: "CoursePromoSections",
                newName: "IX_CoursePromoSections_PromoSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursePromoSections_CoursePromoSectionGroups_PromoSectionId",
                table: "CoursePromoSections",
                column: "PromoSectionId",
                principalTable: "CoursePromoSectionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
