using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002021314 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FatherMobNo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MotherMobNo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    SchoolTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUserProfiles_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserProfiles_SchoolTypes_SchoolTypeId",
                        column: x => x.SchoolTypeId,
                        principalTable: "SchoolTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserProfiles_CityId",
                table: "StudentUserProfiles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserProfiles_SchoolTypeId",
                table: "StudentUserProfiles",
                column: "SchoolTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserProfiles_UserId",
                table: "StudentUserProfiles",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUserProfiles");

            migrationBuilder.DropTable(
                name: "SchoolTypes");
        }
    }
}
