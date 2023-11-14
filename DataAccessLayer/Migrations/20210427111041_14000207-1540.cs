using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002071540 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineExamPromoSectionGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamPromoSectionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamPromoSectionGroups_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineExamPromoSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    OnlineExamPromoSectionGroupId = table.Column<int>(type: "int", nullable: false),
                    OnlineExamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamPromoSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamPromoSections_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamPromoSections_OnlineExams_OnlineExamId",
                        column: x => x.OnlineExamId,
                        principalTable: "OnlineExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamPromoSections_OnlineExamPromoSectionGroups_OnlineExamPromoSectionGroupId",
                        column: x => x.OnlineExamPromoSectionGroupId,
                        principalTable: "OnlineExamPromoSectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamPromoSectionGroups_ModUserId",
                table: "OnlineExamPromoSectionGroups",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamPromoSections_ModUserId",
                table: "OnlineExamPromoSections",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamPromoSections_OnlineExamId",
                table: "OnlineExamPromoSections",
                column: "OnlineExamId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamPromoSections_OnlineExamPromoSectionGroupId",
                table: "OnlineExamPromoSections",
                column: "OnlineExamPromoSectionGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineExamPromoSections");

            migrationBuilder.DropTable(
                name: "OnlineExamPromoSectionGroups");
        }
    }
}
