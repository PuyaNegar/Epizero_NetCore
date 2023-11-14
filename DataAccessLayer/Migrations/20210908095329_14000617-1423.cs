using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006171423 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountCodes_SalesPartnerShareTypes_SalesPartnerShareTypeId",
                table: "DiscountCodes");

            migrationBuilder.DropIndex(
                name: "IX_DiscountCodes_SalesPartnerShareTypeId",
                table: "DiscountCodes");

            migrationBuilder.DropColumn(
                name: "SalePartnerAmountOrPercent",
                table: "DiscountCodes");

            migrationBuilder.DropColumn(
                name: "SalePartnerIsPrePayment",
                table: "DiscountCodes");

            migrationBuilder.DropColumn(
                name: "SalesPartnerShareTypeId",
                table: "DiscountCodes");

            migrationBuilder.AddColumn<int>(
                name: "SalePartnerAmountOrPercent",
                table: "DiscountCodeAcademyProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SalePartnerIsPrePayment",
                table: "DiscountCodeAcademyProducts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesPartnerShareTypeId",
                table: "DiscountCodeAcademyProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeAcademyProducts_SalesPartnerShareTypeId",
                table: "DiscountCodeAcademyProducts",
                column: "SalesPartnerShareTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountCodeAcademyProducts_SalesPartnerShareTypes_SalesPartnerShareTypeId",
                table: "DiscountCodeAcademyProducts",
                column: "SalesPartnerShareTypeId",
                principalTable: "SalesPartnerShareTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountCodeAcademyProducts_SalesPartnerShareTypes_SalesPartnerShareTypeId",
                table: "DiscountCodeAcademyProducts");

            migrationBuilder.DropIndex(
                name: "IX_DiscountCodeAcademyProducts_SalesPartnerShareTypeId",
                table: "DiscountCodeAcademyProducts");

            migrationBuilder.DropColumn(
                name: "SalePartnerAmountOrPercent",
                table: "DiscountCodeAcademyProducts");

            migrationBuilder.DropColumn(
                name: "SalePartnerIsPrePayment",
                table: "DiscountCodeAcademyProducts");

            migrationBuilder.DropColumn(
                name: "SalesPartnerShareTypeId",
                table: "DiscountCodeAcademyProducts");

            migrationBuilder.AddColumn<int>(
                name: "SalePartnerAmountOrPercent",
                table: "DiscountCodes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SalePartnerIsPrePayment",
                table: "DiscountCodes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesPartnerShareTypeId",
                table: "DiscountCodes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodes_SalesPartnerShareTypeId",
                table: "DiscountCodes",
                column: "SalesPartnerShareTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountCodes_SalesPartnerShareTypes_SalesPartnerShareTypeId",
                table: "DiscountCodes",
                column: "SalesPartnerShareTypeId",
                principalTable: "SalesPartnerShareTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
