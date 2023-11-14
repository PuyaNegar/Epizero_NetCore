using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003231318 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "PosPayments");

            migrationBuilder.CreateTable(
                name: "ReturnPaymentTypesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NameEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnPaymentTypesModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCheques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChequesNo = table.Column<string>(type: "varchar(30)", nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    ChequesStatusTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCheques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCheques_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCheques_ChequesStatusTypes_ChequesStatusTypeId",
                        column: x => x.ChequesStatusTypeId,
                        principalTable: "ChequesStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCheques_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCheques_StudentFinancialPayments_StudentFinancialPaymentId",
                        column: x => x.StudentFinancialPaymentId,
                        principalTable: "StudentFinancialPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPosPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    TrackingNo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BankPosDeviceId = table.Column<int>(nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPosPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPosPayments_BankPosDevices_BankPosDeviceId",
                        column: x => x.BankPosDeviceId,
                        principalTable: "BankPosDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentPosPayments_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentPosPayments_StudentFinancialPayments_StudentFinancialPaymentId",
                        column: x => x.StudentFinancialPaymentId,
                        principalTable: "StudentFinancialPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentReturnPaymentsModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(nullable: true),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    ModUserId = table.Column<int>(nullable: false),
                    AmountFines = table.Column<int>(nullable: false),
                    ReturnAmount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ReturnPaymentTypeId = table.Column<int>(nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentReturnPaymentsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentReturnPaymentsModel_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentReturnPaymentsModel_ReturnPaymentTypesModel_ReturnPaymentTypeId",
                        column: x => x.ReturnPaymentTypeId,
                        principalTable: "ReturnPaymentTypesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentReturnPaymentsModel_StudentFinancialPayments_StudentFinancialPaymentId",
                        column: x => x.StudentFinancialPaymentId,
                        principalTable: "StudentFinancialPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_BankId",
                table: "StudentCheques",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_ChequesStatusTypeId",
                table: "StudentCheques",
                column: "ChequesStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_ModUserId",
                table: "StudentCheques",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_StudentFinancialPaymentId",
                table: "StudentCheques",
                column: "StudentFinancialPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPosPayments_BankPosDeviceId",
                table: "StudentPosPayments",
                column: "BankPosDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPosPayments_ModUserId",
                table: "StudentPosPayments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPosPayments_StudentFinancialPaymentId",
                table: "StudentPosPayments",
                column: "StudentFinancialPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentReturnPaymentsModel_ModUserId",
                table: "StudentReturnPaymentsModel",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentReturnPaymentsModel_ReturnPaymentTypeId",
                table: "StudentReturnPaymentsModel",
                column: "ReturnPaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentReturnPaymentsModel_StudentFinancialPaymentId",
                table: "StudentReturnPaymentsModel",
                column: "StudentFinancialPaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCheques");

            migrationBuilder.DropTable(
                name: "StudentPosPayments");

            migrationBuilder.DropTable(
                name: "StudentReturnPaymentsModel");

            migrationBuilder.DropTable(
                name: "ReturnPaymentTypesModel");

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    ChequesNo = table.Column<string>(type: "varchar(30)", nullable: true),
                    ChequesStatusTypeId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheques_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cheques_ChequesStatusTypes_ChequesStatusTypeId",
                        column: x => x.ChequesStatusTypeId,
                        principalTable: "ChequesStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cheques_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cheques_StudentFinancialPayments_StudentFinancialPaymentId",
                        column: x => x.StudentFinancialPaymentId,
                        principalTable: "StudentFinancialPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PosPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankPosDeviceId = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(type: "int", nullable: false),
                    TrackingNo = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosPayments_BankPosDevices_BankPosDeviceId",
                        column: x => x.BankPosDeviceId,
                        principalTable: "BankPosDevices",
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
                name: "IX_Cheques_BankId",
                table: "Cheques",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_ChequesStatusTypeId",
                table: "Cheques",
                column: "ChequesStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_ModUserId",
                table: "Cheques",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_StudentFinancialPaymentId",
                table: "Cheques",
                column: "StudentFinancialPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PosPayments_BankPosDeviceId",
                table: "PosPayments",
                column: "BankPosDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_PosPayments_ModUserId",
                table: "PosPayments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PosPayments_StudentFinancialPaymentId",
                table: "PosPayments",
                column: "StudentFinancialPaymentId");
        }
    }
}
