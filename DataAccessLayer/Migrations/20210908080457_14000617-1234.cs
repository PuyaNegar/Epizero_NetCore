using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006171234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalePartnerUserCustomCoursePrices");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "SalesPartnerUserOptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserOptions_CourseId",
                table: "SalesPartnerUserOptions",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPartnerUserOptions_Courses_CourseId",
                table: "SalesPartnerUserOptions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPartnerUserOptions_Courses_CourseId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserOptions_CourseId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.CreateTable(
                name: "SalePartnerUserCustomCoursePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
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
                name: "IX_SalePartnerUserCustomCoursePrices_ModUserId",
                table: "SalePartnerUserCustomCoursePrices",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_SalePartnerUserId",
                table: "SalePartnerUserCustomCoursePrices",
                column: "SalePartnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_CourseId_SalePartnerUserId",
                table: "SalePartnerUserCustomCoursePrices",
                columns: new[] { "CourseId", "SalePartnerUserId" },
                unique: true);
        }
    }
}
