using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _1400009021100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaidChequesModel_Banks_BankId",
                table: "PaidChequesModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PaidChequesModel_ChequesStatusTypes_ChequesStatusTypeId",
                table: "PaidChequesModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PaidChequesModel_Users_ModUserId",
                table: "PaidChequesModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_PaidChequesModel_PaidChequeId",
                table: "StudentCheques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaidChequesModel",
                table: "PaidChequesModel");

            migrationBuilder.RenameTable(
                name: "PaidChequesModel",
                newName: "PaidCheques");

            migrationBuilder.RenameIndex(
                name: "IX_PaidChequesModel_ModUserId",
                table: "PaidCheques",
                newName: "IX_PaidCheques_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaidChequesModel_ChequesStatusTypeId",
                table: "PaidCheques",
                newName: "IX_PaidCheques_ChequesStatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PaidChequesModel_BankId",
                table: "PaidCheques",
                newName: "IX_PaidCheques_BankId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDateTime",
                table: "PaidCheques",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDateTime",
                table: "PaidCheques",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "PaidCheques",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ChequesNo",
                table: "PaidCheques",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaidCheques",
                table: "PaidCheques",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaidCheques_Banks_BankId",
                table: "PaidCheques",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaidCheques_ChequesStatusTypes_ChequesStatusTypeId",
                table: "PaidCheques",
                column: "ChequesStatusTypeId",
                principalTable: "ChequesStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaidCheques_Users_ModUserId",
                table: "PaidCheques",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_PaidCheques_PaidChequeId",
                table: "StudentCheques",
                column: "PaidChequeId",
                principalTable: "PaidCheques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaidCheques_Banks_BankId",
                table: "PaidCheques");

            migrationBuilder.DropForeignKey(
                name: "FK_PaidCheques_ChequesStatusTypes_ChequesStatusTypeId",
                table: "PaidCheques");

            migrationBuilder.DropForeignKey(
                name: "FK_PaidCheques_Users_ModUserId",
                table: "PaidCheques");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_PaidCheques_PaidChequeId",
                table: "StudentCheques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaidCheques",
                table: "PaidCheques");

            migrationBuilder.RenameTable(
                name: "PaidCheques",
                newName: "PaidChequesModel");

            migrationBuilder.RenameIndex(
                name: "IX_PaidCheques_ModUserId",
                table: "PaidChequesModel",
                newName: "IX_PaidChequesModel_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaidCheques_ChequesStatusTypeId",
                table: "PaidChequesModel",
                newName: "IX_PaidChequesModel_ChequesStatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PaidCheques_BankId",
                table: "PaidChequesModel",
                newName: "IX_PaidChequesModel_BankId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDateTime",
                table: "PaidChequesModel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDateTime",
                table: "PaidChequesModel",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "PaidChequesModel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "ChequesNo",
                table: "PaidChequesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaidChequesModel",
                table: "PaidChequesModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaidChequesModel_Banks_BankId",
                table: "PaidChequesModel",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaidChequesModel_ChequesStatusTypes_ChequesStatusTypeId",
                table: "PaidChequesModel",
                column: "ChequesStatusTypeId",
                principalTable: "ChequesStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaidChequesModel_Users_ModUserId",
                table: "PaidChequesModel",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_PaidChequesModel_PaidChequeId",
                table: "StudentCheques",
                column: "PaidChequeId",
                principalTable: "PaidChequesModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
