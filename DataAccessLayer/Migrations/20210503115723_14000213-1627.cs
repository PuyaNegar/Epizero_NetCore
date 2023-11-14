using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002131627 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndependentExamId",
                table: "OnlineExams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IndependentExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DiscountPrice = table.Column<int>(type: "int", nullable: false),
                    PicPath = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_OnlineExams_IndependentExamId",
                table: "OnlineExams",
                column: "IndependentExamId");

            migrationBuilder.CreateIndex(
                name: "IX_IndependentExams_ModUserId",
                table: "IndependentExams",
                column: "ModUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_IndependentExams_IndependentExamId",
                table: "OnlineExams",
                column: "IndependentExamId",
                principalTable: "IndependentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_IndependentExams_IndependentExamId",
                table: "OnlineExams");

            migrationBuilder.DropTable(
                name: "IndependentExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_IndependentExamId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "IndependentExamId",
                table: "OnlineExams");
        }
    }
}
