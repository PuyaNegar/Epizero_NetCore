using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007011101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeetings_CourseOrCourseMeetingTypes_CourseOrCourseMeetingTypeId",
                table: "CourseMeetings");

            migrationBuilder.DropIndex(
                name: "IX_CourseMeetings_CourseOrCourseMeetingTypeId",
                table: "CourseMeetings");

            migrationBuilder.DropColumn(
                name: "CourseOrCourseMeetingTypeId",
                table: "CourseMeetings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseOrCourseMeetingTypeId",
                table: "CourseMeetings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetings_CourseOrCourseMeetingTypeId",
                table: "CourseMeetings",
                column: "CourseOrCourseMeetingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeetings_CourseOrCourseMeetingTypes_CourseOrCourseMeetingTypeId",
                table: "CourseMeetings",
                column: "CourseOrCourseMeetingTypeId",
                principalTable: "CourseOrCourseMeetingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
