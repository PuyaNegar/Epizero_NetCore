using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006101530 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "StudentPaymentLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentPaymentLinks_InvoiceId",
                table: "StudentPaymentLinks",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPaymentLinks_Invoices_InvoiceId",
                table: "StudentPaymentLinks",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPaymentLinks_Invoices_InvoiceId",
                table: "StudentPaymentLinks");

            migrationBuilder.DropIndex(
                name: "IX_StudentPaymentLinks_InvoiceId",
                table: "StudentPaymentLinks");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "StudentPaymentLinks");
        }
    }
}
