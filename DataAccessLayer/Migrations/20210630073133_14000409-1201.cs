using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004091201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReturnPayments_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentReturnPayments");

            migrationBuilder.RenameColumn(
                name: "StudentFinancialPaymentId",
                table: "StudentReturnPayments",
                newName: "StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentReturnPayments_StudentFinancialPaymentId",
                table: "StudentReturnPayments",
                newName: "IX_StudentReturnPayments_StudentUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StudentFines",
                type: "nvarchar(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReturnPayments_Users_StudentUserId",
                table: "StudentReturnPayments",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReturnPayments_Users_StudentUserId",
                table: "StudentReturnPayments");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "StudentReturnPayments",
                newName: "StudentFinancialPaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentReturnPayments_StudentUserId",
                table: "StudentReturnPayments",
                newName: "IX_StudentReturnPayments_StudentFinancialPaymentId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StudentFines",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReturnPayments_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentReturnPayments",
                column: "StudentFinancialPaymentId",
                principalTable: "StudentFinancialPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
