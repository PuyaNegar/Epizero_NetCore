using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009041042 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheques_Banks_BanksModelId",
                table: "StudentCheques");

            migrationBuilder.DropIndex(
                name: "IX_StudentCheques_BanksModelId",
                table: "StudentCheques");

            migrationBuilder.DropColumn(
                name: "BanksModelId",
                table: "StudentCheques");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BanksModelId",
                table: "StudentCheques",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheques_BanksModelId",
                table: "StudentCheques",
                column: "BanksModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheques_Banks_BanksModelId",
                table: "StudentCheques",
                column: "BanksModelId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
