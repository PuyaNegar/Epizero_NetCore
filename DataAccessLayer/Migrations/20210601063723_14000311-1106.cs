using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003111106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChequesStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequesStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentFinancialDebts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    DebtAmount = table.Column<int>(type: "int", nullable: false),
                    CourseStudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFinancialDebts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFinancialDebts_Users_CourseStudentId",
                        column: x => x.CourseStudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentFinancialDebts_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFinancialPaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFinancialPaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentFinancialPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentFinancialPaymentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFinancialPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFinancialPayments_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentFinancialPayments_StudentFinancialPaymentTypes_StudentFinancialPaymentTypeId",
                        column: x => x.StudentFinancialPaymentTypeId,
                        principalTable: "StudentFinancialPaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChequesNo = table.Column<string>(type: "varchar(30)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ChequesStatusTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentFinancialPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
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
                name: "IX_StudentFinancialDebts_CourseStudentId",
                table: "StudentFinancialDebts",
                column: "CourseStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialDebts_ModUserId",
                table: "StudentFinancialDebts",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialPayments_ModUserId",
                table: "StudentFinancialPayments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialPayments_StudentFinancialPaymentTypeId",
                table: "StudentFinancialPayments",
                column: "StudentFinancialPaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "StudentFinancialDebts");

            migrationBuilder.DropTable(
                name: "ChequesStatusTypes");

            migrationBuilder.DropTable(
                name: "StudentFinancialPayments");

            migrationBuilder.DropTable(
                name: "StudentFinancialPaymentTypes");
        }
    }
}
