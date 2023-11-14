using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009181244 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PaidCheques_RemainingAmount",
                table: "PaidCheques");

            migrationBuilder.CreateCheckConstraint(
                name: "CK_PaidCheques_RemainingAmount",
                table: "PaidCheques",
                sql: "[RemainingAmount] >= 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_PaidCheques_RemainingAmount",
                table: "PaidCheques");

            migrationBuilder.CreateIndex(
                name: "IX_PaidCheques_RemainingAmount",
                table: "PaidCheques",
                column: "RemainingAmount",
                filter: "RemainingAmount > -1");
        }
    }
}
