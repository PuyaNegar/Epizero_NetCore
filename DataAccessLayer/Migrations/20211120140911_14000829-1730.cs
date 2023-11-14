using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140008291730 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineExamFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    OnlineExamId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamFields_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamFields_OnlineExams_OnlineExamId",
                        column: x => x.OnlineExamId,
                        principalTable: "OnlineExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamFields_ModUserId",
                table: "OnlineExamFields",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamFields_OnlineExamId",
                table: "OnlineExamFields",
                column: "OnlineExamId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamFields_FieldId_OnlineExamId",
                table: "OnlineExamFields",
                columns: new[] { "FieldId", "OnlineExamId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineExamFields");
        }
    }
}
