using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140111301450 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(3000)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerPicPath = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AltBannerPicPath = table.Column<string>(type: "nvarchar(3000)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(3000)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(3000)", nullable: true),
                    CanonicalHref = table.Column<string>(type: "nvarchar(3000)", nullable: true),
                    KeyWordsMetaTag = table.Column<string>(type: "nvarchar(3000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutUs_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUs_ModUserId",
                table: "AboutUs",
                column: "ModUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");
        }
    }
}
