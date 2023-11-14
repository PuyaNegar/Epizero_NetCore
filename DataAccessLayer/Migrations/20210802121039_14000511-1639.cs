using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140005111639 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserShares_OrderDetailId",
                table: "SalesPartnerUserShares");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserShares_OrderDetailId",
                table: "SalesPartnerUserShares",
                column: "OrderDetailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserShares_OrderDetailId",
                table: "SalesPartnerUserShares");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserShares_OrderDetailId",
                table: "SalesPartnerUserShares",
                column: "OrderDetailId");
        }
    }
}
