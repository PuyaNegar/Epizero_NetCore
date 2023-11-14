using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007011116 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseOrCourseMeetingTypes_CourseOrCourseMeetingTypeId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseOrCourseMeetingTypeId",
                table: "Courses",
                newName: "CourseCategoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CourseOrCourseMeetingTypeId",
                table: "Courses",
                newName: "IX_Courses_CourseCategoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseOrCourseMeetingTypes_CourseCategoryTypeId",
                table: "Courses",
                column: "CourseCategoryTypeId",
                principalTable: "CourseOrCourseMeetingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseOrCourseMeetingTypes_CourseCategoryTypeId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseCategoryTypeId",
                table: "Courses",
                newName: "CourseOrCourseMeetingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CourseCategoryTypeId",
                table: "Courses",
                newName: "IX_Courses_CourseOrCourseMeetingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseOrCourseMeetingTypes_CourseOrCourseMeetingTypeId",
                table: "Courses",
                column: "CourseOrCourseMeetingTypeId",
                principalTable: "CourseOrCourseMeetingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
