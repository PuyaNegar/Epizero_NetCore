using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002291630 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LatinLastName",
                table: "StudentUserProfiles",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "StudentUserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntroductionWithAcademyTypeId",
                table: "StudentUserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCardPicPath",
                table: "StudentUserProfiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IntroductionWithAcademyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroductionWithAcademyType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserProfiles_FieldId",
                table: "StudentUserProfiles",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserProfiles_IntroductionWithAcademyTypeId",
                table: "StudentUserProfiles",
                column: "IntroductionWithAcademyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserProfiles_Fields_FieldId",
                table: "StudentUserProfiles",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentUserProfiles_IntroductionWithAcademyType_IntroductionWithAcademyTypeId",
                table: "StudentUserProfiles",
                column: "IntroductionWithAcademyTypeId",
                principalTable: "IntroductionWithAcademyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserProfiles_Fields_FieldId",
                table: "StudentUserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentUserProfiles_IntroductionWithAcademyType_IntroductionWithAcademyTypeId",
                table: "StudentUserProfiles");

            migrationBuilder.DropTable(
                name: "IntroductionWithAcademyType");

            migrationBuilder.DropIndex(
                name: "IX_StudentUserProfiles_FieldId",
                table: "StudentUserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_StudentUserProfiles_IntroductionWithAcademyTypeId",
                table: "StudentUserProfiles");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "StudentUserProfiles");

            migrationBuilder.DropColumn(
                name: "IntroductionWithAcademyTypeId",
                table: "StudentUserProfiles");

            migrationBuilder.DropColumn(
                name: "NationalCardPicPath",
                table: "StudentUserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "LatinLastName",
                table: "StudentUserProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }
    }
}
