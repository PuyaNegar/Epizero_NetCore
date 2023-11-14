using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006161015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalePartnerUserCustomCoursePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SalePartnerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePartnerUserCustomCoursePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePartnerUserCustomCoursePrices_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalePartnerUserCustomCoursePrices_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalePartnerUserCustomCoursePrices_Users_SalePartnerUserId",
                        column: x => x.SalePartnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_CourseId",
                table: "SalePartnerUserCustomCoursePrices",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_ModUserId",
                table: "SalePartnerUserCustomCoursePrices",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_SalePartnerUserId",
                table: "SalePartnerUserCustomCoursePrices",
                column: "SalePartnerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalePartnerUserCustomCoursePrices");
        }
    }
}
