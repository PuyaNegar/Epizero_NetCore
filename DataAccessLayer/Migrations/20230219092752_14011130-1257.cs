using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140111301257 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "TeacherUserProfiles",
                type: "nvarchar(3000)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "Courses",
                type: "nvarchar(3000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "TeacherUserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "Courses",
                type: "nvarchar(300)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldNullable: true);
        }
    }
}
