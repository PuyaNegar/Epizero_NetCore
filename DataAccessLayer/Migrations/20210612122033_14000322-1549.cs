using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003221549 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankPosDevicesModel_Banks_BankId",
                table: "BankPosDevicesModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BankPosDevicesModel_Users_ModUserId",
                table: "BankPosDevicesModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PosPayments_BankPosDevicesModel_BankPosDeviceId",
                table: "PosPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankPosDevicesModel",
                table: "BankPosDevicesModel");

            migrationBuilder.RenameTable(
                name: "BankPosDevicesModel",
                newName: "BankPosDevices");

            migrationBuilder.RenameIndex(
                name: "IX_BankPosDevicesModel_ModUserId",
                table: "BankPosDevices",
                newName: "IX_BankPosDevices_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BankPosDevicesModel_BankId",
                table: "BankPosDevices",
                newName: "IX_BankPosDevices_BankId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDateTime",
                table: "BankPosDevices",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDateTime",
                table: "BankPosDevices",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BankPosDevices",
                type: "nvarchar(300)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "BankPosDevices",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankPosDevices",
                table: "BankPosDevices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankPosDevices_Banks_BankId",
                table: "BankPosDevices",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankPosDevices_Users_ModUserId",
                table: "BankPosDevices",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PosPayments_BankPosDevices_BankPosDeviceId",
                table: "PosPayments",
                column: "BankPosDeviceId",
                principalTable: "BankPosDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankPosDevices_Banks_BankId",
                table: "BankPosDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_BankPosDevices_Users_ModUserId",
                table: "BankPosDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_PosPayments_BankPosDevices_BankPosDeviceId",
                table: "PosPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankPosDevices",
                table: "BankPosDevices");

            migrationBuilder.RenameTable(
                name: "BankPosDevices",
                newName: "BankPosDevicesModel");

            migrationBuilder.RenameIndex(
                name: "IX_BankPosDevices_ModUserId",
                table: "BankPosDevicesModel",
                newName: "IX_BankPosDevicesModel_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BankPosDevices_BankId",
                table: "BankPosDevicesModel",
                newName: "IX_BankPosDevicesModel_BankId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDateTime",
                table: "BankPosDevicesModel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDateTime",
                table: "BankPosDevicesModel",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BankPosDevicesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "BankPosDevicesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankPosDevicesModel",
                table: "BankPosDevicesModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankPosDevicesModel_Banks_BankId",
                table: "BankPosDevicesModel",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankPosDevicesModel_Users_ModUserId",
                table: "BankPosDevicesModel",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PosPayments_BankPosDevicesModel_BankPosDeviceId",
                table: "PosPayments",
                column: "BankPosDeviceId",
                principalTable: "BankPosDevicesModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
