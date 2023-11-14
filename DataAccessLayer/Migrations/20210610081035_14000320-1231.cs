using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003201231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bank",
                table: "Cheques",
                newName: "BankName");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Cheques",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_BankId",
                table: "Cheques",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_ModUserId",
                table: "Banks",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheques_Banks_BankId",
                table: "Cheques",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheques_Banks_BankId",
                table: "Cheques");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Cheques_BankId",
                table: "Cheques");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Cheques");

            migrationBuilder.RenameColumn(
                name: "BankName",
                table: "Cheques",
                newName: "Bank");
        }
    }
}
