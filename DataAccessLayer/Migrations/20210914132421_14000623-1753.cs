using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006231753 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentPosPayments_StudentFinancialPaymentId",
                table: "StudentPosPayments");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_StudentFinancialPaymentId",
                table: "StudentCheques");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPosPayments_StudentFinancialPaymentId",
                table: "StudentPosPayments",
                column: "StudentFinancialPaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_StudentFinancialPaymentId",
                table: "StudentCheques",
                column: "StudentFinancialPaymentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentPosPayments_StudentFinancialPaymentId",
                table: "StudentPosPayments");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_StudentFinancialPaymentId",
                table: "StudentCheques");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPosPayments_StudentFinancialPaymentId",
                table: "StudentPosPayments",
                column: "StudentFinancialPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_StudentFinancialPaymentId",
                table: "StudentCheques",
                column: "StudentFinancialPaymentId");
        }
    }
}
