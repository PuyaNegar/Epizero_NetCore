using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004091239 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentReturnPayments");

            migrationBuilder.CreateTable(
                name: "StudentFinancialReturnPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    ReturnAmount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    ReturnPaymentTypeId = table.Column<int>(nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFinancialReturnPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFinancialReturnPayments_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentFinancialReturnPayments_ReturnPaymentTypes_ReturnPaymentTypeId",
                        column: x => x.ReturnPaymentTypeId,
                        principalTable: "ReturnPaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentFinancialReturnPayments_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialReturnPayments_ModUserId",
                table: "StudentFinancialReturnPayments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialReturnPayments_ReturnPaymentTypeId",
                table: "StudentFinancialReturnPayments",
                column: "ReturnPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialReturnPayments_StudentUserId",
                table: "StudentFinancialReturnPayments",
                column: "StudentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentFinancialReturnPayments");

            migrationBuilder.CreateTable(
                name: "StudentReturnPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReturnAmount = table.Column<int>(type: "int", nullable: false),
                    ReturnPaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentReturnPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentReturnPayments_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentReturnPayments_ReturnPaymentTypes_ReturnPaymentTypeId",
                        column: x => x.ReturnPaymentTypeId,
                        principalTable: "ReturnPaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentReturnPayments_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentReturnPayments_ModUserId",
                table: "StudentReturnPayments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentReturnPayments_ReturnPaymentTypeId",
                table: "StudentReturnPayments",
                column: "ReturnPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentReturnPayments_StudentUserId",
                table: "StudentReturnPayments",
                column: "StudentUserId");
        }
    }
}
