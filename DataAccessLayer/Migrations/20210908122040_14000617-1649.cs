using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006171649 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserOptions_CourseId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserOptions_CourseId_SalesPartnerUserId",
                table: "SalesPartnerUserOptions",
                columns: new[] { "CourseId", "SalesPartnerUserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserOptions_CourseId_SalesPartnerUserId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserOptions_CourseId",
                table: "SalesPartnerUserOptions",
                column: "CourseId");
        }
    }
}
