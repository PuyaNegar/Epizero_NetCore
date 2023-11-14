using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004261546 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DiscountCodeId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountCodeAmount",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DiscountCodes_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId",
                principalTable: "DiscountCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DiscountCodes_DiscountCodeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiscountCodeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiscountCodeAmount",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "Orders",
                type: "int",
                nullable: true);
        }
    }
}
