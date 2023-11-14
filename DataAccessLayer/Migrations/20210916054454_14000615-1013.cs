using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140006151013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseOrCourseMeetingTypeId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseOrCourseMeetingTypeId",
                table: "CourseMeetings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseOrCourseMeetingTypeId",
                table: "Courses",
                column: "CourseOrCourseMeetingTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseOrCourseMeetingTypes_CourseOrCourseMeetingTypeId",
                table: "Courses",
                column: "CourseOrCourseMeetingTypeId",
                principalTable: "CourseOrCourseMeetingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeetings_CourseOrCourseMeetingTypes_CourseOrCourseMeetingTypeId",
                table: "CourseMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseOrCourseMeetingTypes_CourseOrCourseMeetingTypeId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseOrCourseMeetingTypeId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseMeetings_CourseOrCourseMeetingTypeId",
                table: "CourseMeetings");

            migrationBuilder.DropColumn(
                name: "CourseOrCourseMeetingTypeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseOrCourseMeetingTypeId",
                table: "CourseMeetings");
        }
    }
}
