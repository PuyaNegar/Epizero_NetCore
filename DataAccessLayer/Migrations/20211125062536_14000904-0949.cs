using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009040949 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_Banks_BankId",
                table: "StudentCheques");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_ChequesStatusTypes_ChequesStatusTypeId",
                table: "StudentCheques");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_BankId",
                table: "StudentCheques");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_ChequesStatusTypeId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "ChequesNo",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "ChequesStatusTypeId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "StudentCheques");

            migrationBuilder.AddColumn<int>(
                name: "BanksModelId",
                table: "StudentCheques",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChequesStatusTypesModelId",
                table: "StudentCheques",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "StudentCheques",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountPaid",
                table: "PaidCheques",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PaidCheques",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "PaidCheques",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_BanksModelId",
                table: "StudentCheques",
                column: "BanksModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_ChequesStatusTypesModelId",
                table: "StudentCheques",
                column: "ChequesStatusTypesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_Banks_BanksModelId",
                table: "StudentCheques",
                column: "BanksModelId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_ChequesStatusTypes_ChequesStatusTypesModelId",
                table: "StudentCheques",
                column: "ChequesStatusTypesModelId",
                principalTable: "ChequesStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_Banks_BanksModelId",
                table: "StudentCheques");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_ChequesStatusTypes_ChequesStatusTypesModelId",
                table: "StudentCheques");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_BanksModelId",
                table: "StudentCheques");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_ChequesStatusTypesModelId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "BanksModelId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "ChequesStatusTypesModelId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "PaidCheques");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PaidCheques");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "PaidCheques");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "StudentCheques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ChequesNo",
                table: "StudentCheques",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChequesStatusTypeId",
                table: "StudentCheques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "StudentCheques",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_BankId",
                table: "StudentCheques",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_ChequesStatusTypeId",
                table: "StudentCheques",
                column: "ChequesStatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_Banks_BankId",
                table: "StudentCheques",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_ChequesStatusTypes_ChequesStatusTypeId",
                table: "StudentCheques",
                column: "ChequesStatusTypeId",
                principalTable: "ChequesStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
