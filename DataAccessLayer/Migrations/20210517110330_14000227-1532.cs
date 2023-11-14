using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002271532 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineClassesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    RecordUrl = table.Column<string>(nullable: true),
                    MeetingId = table.Column<string>(nullable: true),
                    IsIgnoreClass = table.Column<bool>(nullable: false),
                    IsAbleToAccessRecordUrl = table.Column<bool>(nullable: false),
                    CourseMeetingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineClassesModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineClassesModel_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineClassesModel_CourseMeetingId",
                table: "OnlineClassesModel",
                column: "CourseMeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineClassesModel");
        }
    }
}
