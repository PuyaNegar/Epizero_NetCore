using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003111902 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cheques");

            migrationBuilder.AddColumn<int>(
                name: "StudentUserId",
                table: "StudentFinancialPayments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrackingNo",
                table: "StudentFinancialPayments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancialPayments_StudentUserId",
                table: "StudentFinancialPayments",
                column: "StudentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFinancialPayments_Users_StudentUserId",
                table: "StudentFinancialPayments",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFinancialPayments_Users_StudentUserId",
                table: "StudentFinancialPayments");

            migrationBuilder.DropIndex(
                name: "IX_StudentFinancialPayments_StudentUserId",
                table: "StudentFinancialPayments");

            migrationBuilder.DropColumn(
                name: "StudentUserId",
                table: "StudentFinancialPayments");

            migrationBuilder.DropColumn(
                name: "TrackingNo",
                table: "StudentFinancialPayments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cheques",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
