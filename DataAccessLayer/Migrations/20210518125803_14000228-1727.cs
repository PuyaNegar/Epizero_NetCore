using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002281727 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CouponDiscount",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_AcademyProductTypeId",
                table: "OrderDetails",
                column: "AcademyProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_AcademyProductTypes_AcademyProductTypeId",
                table: "OrderDetails",
                column: "AcademyProductTypeId",
                principalTable: "AcademyProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_AcademyProductTypes_AcademyProductTypeId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_AcademyProductTypeId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CouponDiscount",
                table: "Orders");
        }
    }
}
