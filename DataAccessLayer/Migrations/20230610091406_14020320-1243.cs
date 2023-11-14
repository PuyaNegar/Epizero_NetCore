using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140203201243 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(nullable: true),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    ModUserId = table.Column<int>(nullable: false),
                    EpizeroCoinPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseInfos_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseInfos_ModUserId",
                table: "BaseInfos",
                column: "ModUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseInfos");
        }
    }
}
