using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003201627 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PosBanksMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    TrackingNo = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosBanksMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosBanksMap_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosBanksMap_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosBanksMap_StudentFinancialPayments_StudentFinancialPaymentId",
                        column: x => x.StudentFinancialPaymentId,
                        principalTable: "StudentFinancialPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosBanksMap_BankId",
                table: "PosBanksMap",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_PosBanksMap_ModUserId",
                table: "PosBanksMap",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PosBanksMap_StudentFinancialPaymentId",
                table: "PosBanksMap",
                column: "StudentFinancialPaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosBanksMap");
        }
    }
}
