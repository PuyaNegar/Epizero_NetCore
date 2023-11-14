using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002040933 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HighSchoolGraduationDate = table.Column<DateTime>(type: "date", nullable: true),
                    HighSchoolName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HighSchoolStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NewSystemAverage = table.Column<double>(type: "float", nullable: true),
                    OldSystemAverage = table.Column<double>(type: "float", nullable: true),
                    PassPortNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    RegisterFormPath = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    RegisterFormUploadDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    StudentNo = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TurkeyAddress = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_StudentNo",
                table: "UserProfiles",
                column: "StudentNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);
        }
    }
}
