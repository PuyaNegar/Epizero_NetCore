using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004291224 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPartnerShares_Users_PartnerUserId",
                table: "SalesPartnerShares");

            migrationBuilder.DropColumn(
                name: "SMSTemplate",
                table: "SmsOptions");

            migrationBuilder.RenameColumn(
                name: "PartnerUserId",
                table: "SalesPartnerShares",
                newName: "SalePartnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPartnerShares_PartnerUserId",
                table: "SalesPartnerShares",
                newName: "IX_SalesPartnerShares_SalePartnerUserId");

            migrationBuilder.AddColumn<string>(
                name: "SmsContext",
                table: "SmsOptions",
                type: "nvarchar(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPartnerShares_Users_SalePartnerUserId",
                table: "SalesPartnerShares",
                column: "SalePartnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPartnerShares_Users_SalePartnerUserId",
                table: "SalesPartnerShares");

            migrationBuilder.DropColumn(
                name: "SmsContext",
                table: "SmsOptions");

            migrationBuilder.RenameColumn(
                name: "SalePartnerUserId",
                table: "SalesPartnerShares",
                newName: "PartnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesPartnerShares_SalePartnerUserId",
                table: "SalesPartnerShares",
                newName: "IX_SalesPartnerShares_PartnerUserId");

            migrationBuilder.AddColumn<string>(
                name: "SMSTemplate",
                table: "SmsOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPartnerShares_Users_PartnerUserId",
                table: "SalesPartnerShares",
                column: "PartnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
