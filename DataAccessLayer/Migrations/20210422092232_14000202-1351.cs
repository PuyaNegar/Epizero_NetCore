using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002021351 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherUserPrefixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherUserPrefixes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherUserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LessonTeacher = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TeacherUserPrefixId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherUserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherUserProfiles_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherUserProfiles_TeacherUserPrefixes_TeacherUserPrefixId",
                        column: x => x.TeacherUserPrefixId,
                        principalTable: "TeacherUserPrefixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherUserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUserProfiles_CityId",
                table: "TeacherUserProfiles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUserProfiles_TeacherUserPrefixId",
                table: "TeacherUserProfiles",
                column: "TeacherUserPrefixId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUserProfiles_UserId",
                table: "TeacherUserProfiles",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherUserProfiles");

            migrationBuilder.DropTable(
                name: "TeacherUserPrefixes");
        }
    }
}
