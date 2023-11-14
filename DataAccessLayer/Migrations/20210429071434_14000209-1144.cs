using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002091144 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountPrecent",
                table: "Courses",
                newName: "DiscountPrice");

            migrationBuilder.RenameColumn(
                name: "DiscountPercent",
                table: "CourseMeetings",
                newName: "DiscountPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountPrice",
                table: "Courses",
                newName: "DiscountPrecent");

            migrationBuilder.RenameColumn(
                name: "DiscountPrice",
                table: "CourseMeetings",
                newName: "DiscountPercent");
        }
    }
}
