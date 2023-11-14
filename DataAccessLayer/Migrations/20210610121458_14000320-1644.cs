using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003201644 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosBanksMap_Banks_BankId",
                table: "PosBanksMap");

            migrationBuilder.DropForeignKey(
                name: "FK_PosBanksMap_Users_ModUserId",
                table: "PosBanksMap");

            migrationBuilder.DropForeignKey(
                name: "FK_PosBanksMap_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "PosBanksMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PosBanksMap",
                table: "PosBanksMap");

            migrationBuilder.RenameTable(
                name: "PosBanksMap",
                newName: "PosBanks");

            migrationBuilder.RenameIndex(
                name: "IX_PosBanksMap_StudentFinancialPaymentId",
                table: "PosBanks",
                newName: "IX_PosBanks_StudentFinancialPaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_PosBanksMap_ModUserId",
                table: "PosBanks",
                newName: "IX_PosBanks_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PosBanksMap_BankId",
                table: "PosBanks",
                newName: "IX_PosBanks_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosBanks",
                table: "PosBanks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosBanks_Banks_BankId",
                table: "PosBanks",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PosBanks_Users_ModUserId",
                table: "PosBanks",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PosBanks_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "PosBanks",
                column: "StudentFinancialPaymentId",
                principalTable: "StudentFinancialPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosBanks_Banks_BankId",
                table: "PosBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_PosBanks_Users_ModUserId",
                table: "PosBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_PosBanks_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "PosBanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PosBanks",
                table: "PosBanks");

            migrationBuilder.RenameTable(
                name: "PosBanks",
                newName: "PosBanksMap");

            migrationBuilder.RenameIndex(
                name: "IX_PosBanks_StudentFinancialPaymentId",
                table: "PosBanksMap",
                newName: "IX_PosBanksMap_StudentFinancialPaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_PosBanks_ModUserId",
                table: "PosBanksMap",
                newName: "IX_PosBanksMap_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PosBanks_BankId",
                table: "PosBanksMap",
                newName: "IX_PosBanksMap_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosBanksMap",
                table: "PosBanksMap",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PosBanksMap_Banks_BankId",
                table: "PosBanksMap",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PosBanksMap_Users_ModUserId",
                table: "PosBanksMap",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PosBanksMap_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "PosBanksMap",
                column: "StudentFinancialPaymentId",
                principalTable: "StudentFinancialPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
