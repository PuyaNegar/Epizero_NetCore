using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009041035 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_ChequesStatusTypes_ChequesStatusTypesModelId",
                table: "StudentCheques");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentCheques");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_ChequesStatusTypesModelId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "ChequesStatusTypesModelId",
                table: "StudentCheques");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentCheques",
                column: "StudentFinancialPaymentId",
                principalTable: "StudentFinancialPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentCheques");

            migrationBuilder.AddColumn<int>(
                name: "ChequesStatusTypesModelId",
                table: "StudentCheques",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_ChequesStatusTypesModelId",
                table: "StudentCheques",
                column: "ChequesStatusTypesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_ChequesStatusTypes_ChequesStatusTypesModelId",
                table: "StudentCheques",
                column: "ChequesStatusTypesModelId",
                principalTable: "ChequesStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentCheques",
                column: "StudentFinancialPaymentId",
                principalTable: "StudentFinancialPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
