using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003231647 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReturnPaymentsModel_Users_ModUserId",
                table: "StudentReturnPaymentsModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentReturnPaymentsModel_ReturnPaymentTypesModel_ReturnPaymentTypeId",
                table: "StudentReturnPaymentsModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentReturnPaymentsModel_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentReturnPaymentsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentReturnPaymentsModel",
                table: "StudentReturnPaymentsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReturnPaymentTypesModel",
                table: "ReturnPaymentTypesModel");

            migrationBuilder.RenameTable(
                name: "StudentReturnPaymentsModel",
                newName: "StudentReturnPayments");

            migrationBuilder.RenameTable(
                name: "ReturnPaymentTypesModel",
                newName: "ReturnPaymentTypes");

            migrationBuilder.RenameIndex(
                name: "IX_StudentReturnPaymentsModel_StudentFinancialPaymentId",
                table: "StudentReturnPayments",
                newName: "IX_StudentReturnPayments_StudentFinancialPaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentReturnPaymentsModel_ReturnPaymentTypeId",
                table: "StudentReturnPayments",
                newName: "IX_StudentReturnPayments_ReturnPaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentReturnPaymentsModel_ModUserId",
                table: "StudentReturnPayments",
                newName: "IX_StudentReturnPayments_ModUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDateTime",
                table: "StudentReturnPayments",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDateTime",
                table: "StudentReturnPayments",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StudentReturnPayments",
                type: "nvarchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameEN",
                table: "ReturnPaymentTypes",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ReturnPaymentTypes",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ReturnPaymentTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentReturnPayments",
                table: "StudentReturnPayments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnPaymentTypes",
                table: "ReturnPaymentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReturnPayments_Users_ModUserId",
                table: "StudentReturnPayments",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReturnPayments_ReturnPaymentTypes_ReturnPaymentTypeId",
                table: "StudentReturnPayments",
                column: "ReturnPaymentTypeId",
                principalTable: "ReturnPaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReturnPayments_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentReturnPayments",
                column: "StudentFinancialPaymentId",
                principalTable: "StudentFinancialPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReturnPayments_Users_ModUserId",
                table: "StudentReturnPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentReturnPayments_ReturnPaymentTypes_ReturnPaymentTypeId",
                table: "StudentReturnPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentReturnPayments_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentReturnPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentReturnPayments",
                table: "StudentReturnPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReturnPaymentTypes",
                table: "ReturnPaymentTypes");

            migrationBuilder.RenameTable(
                name: "StudentReturnPayments",
                newName: "StudentReturnPaymentsModel");

            migrationBuilder.RenameTable(
                name: "ReturnPaymentTypes",
                newName: "ReturnPaymentTypesModel");

            migrationBuilder.RenameIndex(
                name: "IX_StudentReturnPayments_StudentFinancialPaymentId",
                table: "StudentReturnPaymentsModel",
                newName: "IX_StudentReturnPaymentsModel_StudentFinancialPaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentReturnPayments_ReturnPaymentTypeId",
                table: "StudentReturnPaymentsModel",
                newName: "IX_StudentReturnPaymentsModel_ReturnPaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentReturnPayments_ModUserId",
                table: "StudentReturnPaymentsModel",
                newName: "IX_StudentReturnPaymentsModel_ModUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDateTime",
                table: "StudentReturnPaymentsModel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDateTime",
                table: "StudentReturnPaymentsModel",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StudentReturnPaymentsModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameEN",
                table: "ReturnPaymentTypesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ReturnPaymentTypesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ReturnPaymentTypesModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentReturnPaymentsModel",
                table: "StudentReturnPaymentsModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnPaymentTypesModel",
                table: "ReturnPaymentTypesModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReturnPaymentsModel_Users_ModUserId",
                table: "StudentReturnPaymentsModel",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReturnPaymentsModel_ReturnPaymentTypesModel_ReturnPaymentTypeId",
                table: "StudentReturnPaymentsModel",
                column: "ReturnPaymentTypeId",
                principalTable: "ReturnPaymentTypesModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReturnPaymentsModel_StudentFinancialPayments_StudentFinancialPaymentId",
                table: "StudentReturnPaymentsModel",
                column: "StudentFinancialPaymentId",
                principalTable: "StudentFinancialPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
