using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140104040945 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModUserId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ModUserId",
                table: "Invoices",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_ModUserId",
                table: "Invoices",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_ModUserId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ModUserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ModUserId",
                table: "Invoices");
        }
    }
}
