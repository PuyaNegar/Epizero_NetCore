using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140203131001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DiscountPercent",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,10)");

            migrationBuilder.AlterColumn<double>(
                name: "DiscountPercent",
                table: "Courses",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,10)");

            migrationBuilder.AlterColumn<double>(
                name: "DiscountPercent",
                table: "CourseMeetings",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "OrderDetails",
                type: "decimal(16,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "Courses",
                type: "decimal(16,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "CourseMeetings",
                type: "decimal(16,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
