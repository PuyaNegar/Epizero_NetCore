using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009181219 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PaidCheques_RemainingAmount",
                table: "PaidCheques",
                column: "RemainingAmount",
                filter: "RemainingAmount > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaidCheques_RemainingAmount",
                table: "PaidCheques");
        }
    }
}
