using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140008191709 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AcceptedStudentInEntranceExams",
                type: "nvarchar(2000)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherUserId",
                table: "AcceptedStudentInEntranceExams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OnlineExamAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OnlineExamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamAnalysis_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamAnalysis_OnlineExams_OnlineExamsId",
                        column: x => x.OnlineExamsId,
                        principalTable: "OnlineExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedStudentInEntranceExams_TeacherUserId",
                table: "AcceptedStudentInEntranceExams",
                column: "TeacherUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamAnalysis_ModUserId",
                table: "OnlineExamAnalysis",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamAnalysis_OnlineExamsId",
                table: "OnlineExamAnalysis",
                column: "OnlineExamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcceptedStudentInEntranceExams_Users_TeacherUserId",
                table: "AcceptedStudentInEntranceExams",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcceptedStudentInEntranceExams_Users_TeacherUserId",
                table: "AcceptedStudentInEntranceExams");

            migrationBuilder.DropTable(
                name: "OnlineExamAnalysis");

            migrationBuilder.DropIndex(
                name: "IX_AcceptedStudentInEntranceExams_TeacherUserId",
                table: "AcceptedStudentInEntranceExams");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AcceptedStudentInEntranceExams");

            migrationBuilder.DropColumn(
                name: "TeacherUserId",
                table: "AcceptedStudentInEntranceExams");
        }
    }
}
