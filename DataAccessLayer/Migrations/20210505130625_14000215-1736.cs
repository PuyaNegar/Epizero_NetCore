using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002151736 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromos_ProductPromoSectionGroups_ProductPromoSectionId",
                table: "ProductPromos");

            migrationBuilder.DropTable(
                name: "ProductPromoSectionGroups");

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
                    Title = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromoSections_ModUserId",
                table: "ProductPromoSections",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPromos_ProductPromoSections_ProductPromoSectionId",
                table: "ProductPromos",
                column: "ProductPromoSectionId",
                principalTable: "ProductPromoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromos_ProductPromoSections_ProductPromoSectionId",
                table: "ProductPromos");

            migrationBuilder.DropTable(
                name: "ProductPromoSections");

            migrationBuilder.CreateTable(
                name: "ProductPromoSectionGroups",
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
                    table.PrimaryKey("PK_ProductPromoSectionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPromoSectionGroups_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromoSectionGroups_ModUserId",
                table: "ProductPromoSectionGroups",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPromos_ProductPromoSectionGroups_ProductPromoSectionId",
                table: "ProductPromos",
                column: "ProductPromoSectionId",
                principalTable: "ProductPromoSectionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
