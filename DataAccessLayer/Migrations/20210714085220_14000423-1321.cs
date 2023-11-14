using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004231321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountCodeId",
                table: "DiscountCodeAcademyProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeAcademyProducts_DiscountCodeId",
                table: "DiscountCodeAcademyProducts",
                column: "DiscountCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountCodeAcademyProducts_DiscountCodes_DiscountCodeId",
                table: "DiscountCodeAcademyProducts",
                column: "DiscountCodeId",
                principalTable: "DiscountCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountCodeAcademyProducts_DiscountCodes_DiscountCodeId",
                table: "DiscountCodeAcademyProducts");

            migrationBuilder.DropIndex(
                name: "IX_DiscountCodeAcademyProducts_DiscountCodeId",
                table: "DiscountCodeAcademyProducts");

            migrationBuilder.DropColumn(
                name: "DiscountCodeId",
                table: "DiscountCodeAcademyProducts");
        }
    }
}
