using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002261652 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseMeetingStudents_StudentUserId_CourseMeetingId",
                table: "CourseMeetingStudents");

            migrationBuilder.AlterColumn<int>(
                name: "CourseMeetingId",
                table: "CourseMeetingStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CourseMeetingStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseMeetingStudentTypeId",
                table: "CourseMeetingStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CourseMeetingStudents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CourseMeetingStudentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeetingStudentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingStudents_CourseId",
                table: "CourseMeetingStudents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingStudents_CourseMeetingStudentTypeId",
                table: "CourseMeetingStudents",
                column: "CourseMeetingStudentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingStudents_StudentUserId",
                table: "CourseMeetingStudents",
                column: "StudentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeetingStudents_Courses_CourseId",
                table: "CourseMeetingStudents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeetingStudents_CourseMeetingStudentTypes_CourseMeetingStudentTypeId",
                table: "CourseMeetingStudents",
                column: "CourseMeetingStudentTypeId",
                principalTable: "CourseMeetingStudentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeetingStudents_Courses_CourseId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeetingStudents_CourseMeetingStudentTypes_CourseMeetingStudentTypeId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropTable(
                name: "CourseMeetingStudentTypes");

            migrationBuilder.DropIndex(
                name: "IX_CourseMeetingStudents_CourseId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropIndex(
                name: "IX_CourseMeetingStudents_CourseMeetingStudentTypeId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropIndex(
                name: "IX_CourseMeetingStudents_StudentUserId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropColumn(
                name: "CourseMeetingStudentTypeId",
                table: "CourseMeetingStudents");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CourseMeetingStudents");

            migrationBuilder.AlterColumn<int>(
                name: "CourseMeetingId",
                table: "CourseMeetingStudents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingStudents_StudentUserId_CourseMeetingId",
                table: "CourseMeetingStudents",
                columns: new[] { "StudentUserId", "CourseMeetingId" },
                unique: true);
        }
    }
}
