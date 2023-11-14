using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004021935 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntranceExamTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceExamTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OlympiadMedalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OlympiadMedalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedStudentInEntranceExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    StudentFullName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    OlympiadMedalTypeId = table.Column<int>(nullable: true),
                    EntranceExamTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedStudentInEntranceExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcceptedStudentInEntranceExams_EntranceExamTypes_EntranceExamTypeId",
                        column: x => x.EntranceExamTypeId,
                        principalTable: "EntranceExamTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcceptedStudentInEntranceExams_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcceptedStudentInEntranceExams_OlympiadMedalTypes_OlympiadMedalTypeId",
                        column: x => x.OlympiadMedalTypeId,
                        principalTable: "OlympiadMedalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedStudentInEntranceExams_EntranceExamTypeId",
                table: "AcceptedStudentInEntranceExams",
                column: "EntranceExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedStudentInEntranceExams_ModUserId",
                table: "AcceptedStudentInEntranceExams",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedStudentInEntranceExams_OlympiadMedalTypeId",
                table: "AcceptedStudentInEntranceExams",
                column: "OlympiadMedalTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedStudentInEntranceExams");

            migrationBuilder.DropTable(
                name: "EntranceExamTypes");

            migrationBuilder.DropTable(
                name: "OlympiadMedalTypes");
        }
    }
}
