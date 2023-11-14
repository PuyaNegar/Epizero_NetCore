using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140203071350 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "OldStudentComments");

            migrationBuilder.AddColumn<string>(
                name: "CommentAudio",
                table: "OldStudentComments",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentText",
                table: "OldStudentComments",
                type: "nvarchar(3000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentVideo",
                table: "OldStudentComments",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentAudio",
                table: "OldStudentComments");

            migrationBuilder.DropColumn(
                name: "CommentText",
                table: "OldStudentComments");

            migrationBuilder.DropColumn(
                name: "CommentVideo",
                table: "OldStudentComments");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "OldStudentComments",
                type: "nvarchar(3000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
