using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002071153 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "WeekSchedules",
                type: "time(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "WeekSchedules",
                type: "time(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "OnlineExamTypeId",
                table: "OnlineExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OnlineExamTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_OnlineExamTypeId",
                table: "OnlineExams",
                column: "OnlineExamTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_OnlineExamTypes_OnlineExamTypeId",
                table: "OnlineExams",
                column: "OnlineExamTypeId",
                principalTable: "OnlineExamTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_OnlineExamTypes_OnlineExamTypeId",
                table: "OnlineExams");

            migrationBuilder.DropTable(
                name: "OnlineExamTypes");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_OnlineExamTypeId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "OnlineExamTypeId",
                table: "OnlineExams");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "WeekSchedules",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(7)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "WeekSchedules",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(7)");
        }
    }
}
