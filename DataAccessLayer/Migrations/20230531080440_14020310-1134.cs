using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140203101134 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "Courses",
                type: "decimal(16,10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,14)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "CourseMeetings",
                type: "decimal(16,10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AddColumn<int>(
                name: "DiscountAmount",
                table: "CourseMeetings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "CourseMeetings");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "Courses",
                type: "decimal(16,14)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "CourseMeetings",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,10)");
        }
    }
}
