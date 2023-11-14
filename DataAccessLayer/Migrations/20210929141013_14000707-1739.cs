using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007071739 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_IndependentExams_IndependentExamsModelId",
                table: "OnlineExams");

            migrationBuilder.DropTable(
                name: "IndependentExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_IndependentExamsModelId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "IndependentExamsModelId",
                table: "OnlineExams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndependentExamsModelId",
                table: "OnlineExams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IndependentExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPrice = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PicPath = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndependentExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndependentExams_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_IndependentExamsModelId",
                table: "OnlineExams",
                column: "IndependentExamsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IndependentExams_ModUserId",
                table: "IndependentExams",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_IndependentExams_IndependentExamsModelId",
                table: "OnlineExams",
                column: "IndependentExamsModelId",
                principalTable: "IndependentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
