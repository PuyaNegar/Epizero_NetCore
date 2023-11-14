using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _1400009021055 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaidChequeId",
                table: "StudentCheques",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaidChequesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(nullable: true),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    ModUserId = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ChequesNo = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    ChequesStatusTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidChequesModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaidChequesModel_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaidChequesModel_ChequesStatusTypes_ChequesStatusTypeId",
                        column: x => x.ChequesStatusTypeId,
                        principalTable: "ChequesStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaidChequesModel_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_PaidChequeId",
                table: "StudentCheques",
                column: "PaidChequeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaidChequesModel_BankId",
                table: "PaidChequesModel",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_PaidChequesModel_ChequesStatusTypeId",
                table: "PaidChequesModel",
                column: "ChequesStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaidChequesModel_ModUserId",
                table: "PaidChequesModel",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_PaidChequesModel_PaidChequeId",
                table: "StudentCheques",
                column: "PaidChequeId",
                principalTable: "PaidChequesModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_PaidChequesModel_PaidChequeId",
                table: "StudentCheques");

            migrationBuilder.DropTable(
                name: "PaidChequesModel");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_PaidChequeId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "PaidChequeId",
                table: "StudentCheques");
        }
    }
}
