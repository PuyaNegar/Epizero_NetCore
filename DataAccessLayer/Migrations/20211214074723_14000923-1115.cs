using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140009231115 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherUserTypeId",
                table: "TeacherUserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeacherUserTypesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NameEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherUserTypesModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUserProfiles_TeacherUserTypeId",
                table: "TeacherUserProfiles",
                column: "TeacherUserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserTypesModel_TeacherUserTypeId",
                table: "TeacherUserProfiles",
                column: "TeacherUserTypeId",
                principalTable: "TeacherUserTypesModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherUserProfiles_TeacherUserTypesModel_TeacherUserTypeId",
                table: "TeacherUserProfiles");

            migrationBuilder.DropTable(
                name: "TeacherUserTypesModel");

            migrationBuilder.DropIndex(
                name: "IX_TeacherUserProfiles_TeacherUserTypeId",
                table: "TeacherUserProfiles");

            migrationBuilder.DropColumn(
                name: "TeacherUserTypeId",
                table: "TeacherUserProfiles");
        }
    }
}
