using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002271941 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CourseMeetings",
                type: "nvarchar(Max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(Max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CourseMeetings",
                type: "nvarchar(Max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(Max)",
                oldNullable: true);
        }
    }
}
