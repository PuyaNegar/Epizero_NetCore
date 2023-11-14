using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002151710 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineExamPromoSections");

            migrationBuilder.DropTable(
                name: "ProductPromoSections");

            migrationBuilder.DropTable(
                name: "OnlineExamPromoSectionGroups");

            migrationBuilder.CreateTable(
                name: "ProductPromos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    ProductPromoSectionId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPromos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPromos_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPromos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPromos_ProductPromoSectionGroups_ProductPromoSectionId",
                        column: x => x.ProductPromoSectionId,
                        principalTable: "ProductPromoSectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromos_ModUserId",
                table: "ProductPromos",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromos_ProductId",
                table: "ProductPromos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromos_ProductPromoSectionId",
                table: "ProductPromos",
                column: "ProductPromoSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPromos");

            migrationBuilder.CreateTable(
                name: "OnlineExamPromoSectionGroups",
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
                    table.PrimaryKey("PK_OnlineExamPromoSectionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamPromoSectionGroups_Users_ModUserId",
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
                    Inx = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductPromoSectionGroupId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "OnlineExamPromoSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    OnlineExamId = table.Column<int>(type: "int", nullable: false),
                    OnlineExamPromoSectionGroupId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamPromoSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamPromoSections_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamPromoSections_OnlineExams_OnlineExamId",
                        column: x => x.OnlineExamId,
                        principalTable: "OnlineExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamPromoSections_OnlineExamPromoSectionGroups_OnlineExamPromoSectionGroupId",
                        column: x => x.OnlineExamPromoSectionGroupId,
                        principalTable: "OnlineExamPromoSectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamPromoSectionGroups_ModUserId",
                table: "OnlineExamPromoSectionGroups",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamPromoSections_ModUserId",
                table: "OnlineExamPromoSections",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamPromoSections_OnlineExamId",
                table: "OnlineExamPromoSections",
                column: "OnlineExamId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamPromoSections_OnlineExamPromoSectionGroupId",
                table: "OnlineExamPromoSections",
                column: "OnlineExamPromoSectionGroupId");

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
        }
    }
}
