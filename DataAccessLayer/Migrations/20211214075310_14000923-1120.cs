using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009231120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserTypesModel_TeacherUserTypeId",
                table: "TeacherUserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherUserTypesModel",
                table: "TeacherUserTypesModel");

            migrationBuilder.RenameTable(
                name: "TeacherUserTypesModel",
                newName: "TeacherUserTypes");

            migrationBuilder.AlterColumn<string>(
                name: "NameEN",
                table: "TeacherUserTypes",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TeacherUserTypes",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TeacherUserTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherUserTypes",
                table: "TeacherUserTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserTypes_TeacherUserTypeId",
                table: "TeacherUserProfiles",
                column: "TeacherUserTypeId",
                principalTable: "TeacherUserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserTypes_TeacherUserTypeId",
                table: "TeacherUserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherUserTypes",
                table: "TeacherUserTypes");

            migrationBuilder.RenameTable(
                name: "TeacherUserTypes",
                newName: "TeacherUserTypesModel");

            migrationBuilder.AlterColumn<string>(
                name: "NameEN",
                table: "TeacherUserTypesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TeacherUserTypesModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TeacherUserTypesModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherUserTypesModel",
                table: "TeacherUserTypesModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserTypesModel_TeacherUserTypeId",
                table: "TeacherUserProfiles",
                column: "TeacherUserTypeId",
                principalTable: "TeacherUserTypesModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
