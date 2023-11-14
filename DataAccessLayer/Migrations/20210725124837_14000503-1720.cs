using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140005031720 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserOptions_SalesPartnerUserId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.AddColumn<int>(
                name: "SalesPartnerUserOptionId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserOptions_SalesPartnerUserId",
                table: "SalesPartnerUserOptions",
                column: "SalesPartnerUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserOptions_SalesPartnerUserId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.DropColumn(
                name: "SalesPartnerUserOptionId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserOptions_SalesPartnerUserId",
                table: "SalesPartnerUserOptions",
                column: "SalesPartnerUserId");
        }
    }
}
