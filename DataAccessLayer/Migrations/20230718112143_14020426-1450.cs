using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140204261450 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "PaidCheques",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "PaidCheques",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "PaidCheques",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FishingCode",
                table: "PaidCheques",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAccountHolder",
                table: "PaidCheques",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Audience",
                table: "Courses",
                type: "nvarchar(300)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "PaidCheques");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "PaidCheques");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "PaidCheques");

            migrationBuilder.DropColumn(
                name: "FishingCode",
                table: "PaidCheques");

            migrationBuilder.DropColumn(
                name: "NameAccountHolder",
                table: "PaidCheques");

            migrationBuilder.AlterColumn<string>(
                name: "Audience",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldNullable: true);
        }
    }
}
