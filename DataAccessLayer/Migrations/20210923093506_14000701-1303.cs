using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007011303 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseOrCourseMeetingTypes_CourseCategoryTypeId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseOrCourseMeetingTypes",
                table: "CourseOrCourseMeetingTypes");

            migrationBuilder.RenameTable(
                name: "CourseOrCourseMeetingTypes",
                newName: "CourseCategoryTypes");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "CourseCategoryTypes",
                newName: "NameEN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseCategoryTypes",
                table: "CourseCategoryTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCategoryTypes_CourseCategoryTypeId",
                table: "Courses",
                column: "CourseCategoryTypeId",
                principalTable: "CourseCategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCategoryTypes_CourseCategoryTypeId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseCategoryTypes",
                table: "CourseCategoryTypes");

            migrationBuilder.RenameTable(
                name: "CourseCategoryTypes",
                newName: "CourseOrCourseMeetingTypes");

            migrationBuilder.RenameColumn(
                name: "NameEN",
                table: "CourseOrCourseMeetingTypes",
                newName: "NameEn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseOrCourseMeetingTypes",
                table: "CourseOrCourseMeetingTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseOrCourseMeetingTypes_CourseCategoryTypeId",
                table: "Courses",
                column: "CourseCategoryTypeId",
                principalTable: "CourseOrCourseMeetingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
