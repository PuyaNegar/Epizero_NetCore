using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140008161645 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatinFirstName",
                table: "StudentUserProfiles");

            migrationBuilder.DropColumn(
                name: "LatinLastName",
                table: "StudentUserProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LatinFirstName",
                table: "StudentUserProfiles",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatinLastName",
                table: "StudentUserProfiles",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
