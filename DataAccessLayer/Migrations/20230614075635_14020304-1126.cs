using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140203041126 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Orders",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Invoices",
                type: "int",
                nullable: true);
        }
    }
}
