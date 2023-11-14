using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003221644 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosPayments_Banks_BankId",
                table: "PosPayments");

            migrationBuilder.DropIndex(
                name: "IX_PosPayments_BankId",
                table: "PosPayments");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "PosPayments");

            migrationBuilder.AddColumn<int>(
                name: "BankPosDeviceId",
                table: "PosPayments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Courses",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankPosDevicesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(nullable: true),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    ModUserId = table.Column<int>(nullable: false),
                    AccountNo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankPosDevicesModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankPosDevicesModel_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankPosDevicesModel_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosPayments_BankPosDeviceId",
                table: "PosPayments",
                column: "BankPosDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_BankPosDevicesModel_BankId",
                table: "BankPosDevicesModel",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankPosDevicesModel_ModUserId",
                table: "BankPosDevicesModel",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PosPayments_BankPosDevicesModel_BankPosDeviceId",
                table: "PosPayments",
                column: "BankPosDeviceId",
                principalTable: "BankPosDevicesModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PosPayments_BankPosDevicesModel_BankPosDeviceId",
                table: "PosPayments");

            migrationBuilder.DropTable(
                name: "BankPosDevicesModel");

            migrationBuilder.DropIndex(
                name: "IX_PosPayments_BankPosDeviceId",
                table: "PosPayments");

            migrationBuilder.DropColumn(
                name: "BankPosDeviceId",
                table: "PosPayments");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "PosPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PosPayments_BankId",
                table: "PosPayments",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_PosPayments_Banks_BankId",
                table: "PosPayments",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
