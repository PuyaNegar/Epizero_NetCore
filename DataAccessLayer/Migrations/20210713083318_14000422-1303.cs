using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004221303 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalePartnerAmountOrPercent",
                table: "DiscountCodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SalePartnerIsPrePayment",
                table: "DiscountCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SalesPartnerShareTypeId",
                table: "DiscountCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SalesPartnerShareTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPartnerShareTypes", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountCodes_SalesPartnerShareTypes_SalesPartnerShareTypeId",
                table: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "SalesPartnerShareTypes");

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
        }
    }
}
