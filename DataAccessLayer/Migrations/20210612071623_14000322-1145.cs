using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003221145 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosBanks");

            migrationBuilder.CreateTable(
                name: "PosPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    TrackingNo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosPayments_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosPayments_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosPayments_StudentFinancialPayments_StudentFinancialPaymentId",
                        column: x => x.StudentFinancialPaymentId,
                        principalTable: "StudentFinancialPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosPayments_BankId",
                table: "PosPayments",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_PosPayments_ModUserId",
                table: "PosPayments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PosPayments_StudentFinancialPaymentId",
                table: "PosPayments",
                column: "StudentFinancialPaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosPayments");

            migrationBuilder.CreateTable(
                name: "PosBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(type: "int", nullable: false),
                    TrackingNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosBanks_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosBanks_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosBanks_StudentFinancialPayments_StudentFinancialPaymentId",
                        column: x => x.StudentFinancialPaymentId,
                        principalTable: "StudentFinancialPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosBanks_BankId",
                table: "PosBanks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_PosBanks_ModUserId",
                table: "PosBanks",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PosBanks_StudentFinancialPaymentId",
                table: "PosBanks",
                column: "StudentFinancialPaymentId");
        }
    }
}
