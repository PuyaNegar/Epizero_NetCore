using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140202061259 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "ContactUs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_CourseId",
                table: "ContactUs",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUs_Courses_CourseId",
                table: "ContactUs",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactUs_Courses_CourseId",
                table: "ContactUs");

            migrationBuilder.DropIndex(
                name: "IX_ContactUs_CourseId",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "ContactUs");
        }
    }
}
