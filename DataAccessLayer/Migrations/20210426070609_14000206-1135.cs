using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002061135 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseMeetingBooklets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(Max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeetingBooklets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMeetingBooklets_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingBooklets_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseMeetingVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(Max)", nullable: false),
                    BannerPicPath = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeetingVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMeetingVideos_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetingVideos_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingBooklets_CourseMeetingId",
                table: "CourseMeetingBooklets",
                column: "CourseMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingBooklets_ModUserId",
                table: "CourseMeetingBooklets",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingVideos_CourseMeetingId",
                table: "CourseMeetingVideos",
                column: "CourseMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetingVideos_ModUserId",
                table: "CourseMeetingVideos",
                column: "ModUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMeetingBooklets");

            migrationBuilder.DropTable(
                name: "CourseMeetingVideos");
        }
    }
}
