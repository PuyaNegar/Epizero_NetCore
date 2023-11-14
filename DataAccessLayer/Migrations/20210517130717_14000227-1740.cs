using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002271740 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnlineRegistrated",
                table: "CourseMeetingStudents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CourseMeetingStudents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingStudents_OrderId",
                table: "CourseMeetingStudents",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeetingStudents_Orders_OrderId",
                table: "CourseMeetingStudents",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeetingStudents_Orders_OrderId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropIndex(
                name: "IX_CourseMeetingStudents_OrderId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropColumn(
                name: "IsOnlineRegistrated",
                table: "CourseMeetingStudents");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CourseMeetingStudents");
        }
    }
}
