using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006161038 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_CourseId",
                table: "SalePartnerUserCustomCoursePrices");

            migrationBuilder.CreateIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_CourseId_SalePartnerUserId",
                table: "SalePartnerUserCustomCoursePrices",
                columns: new[] { "CourseId", "SalePartnerUserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_CourseId_SalePartnerUserId",
                table: "SalePartnerUserCustomCoursePrices");

            migrationBuilder.CreateIndex(
                name: "IX_SalePartnerUserCustomCoursePrices_CourseId",
                table: "SalePartnerUserCustomCoursePrices",
                column: "CourseId");
        }
    }
}
