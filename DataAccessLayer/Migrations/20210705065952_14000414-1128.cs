using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004141128 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMSOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SMSTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserSMSOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    SMSOptionId = table.Column<int>(nullable: false),
                    StudentUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserSMSOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUserSMSOptions_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserSMSOptions_SMSOptions_SMSOptionId",
                        column: x => x.SMSOptionId,
                        principalTable: "SMSOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserSMSOptions_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserSMSOptions_ModUserId",
                table: "StudentUserSMSOptions",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserSMSOptions_SMSOptionId",
                table: "StudentUserSMSOptions",
                column: "SMSOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserSMSOptions_StudentUserId",
                table: "StudentUserSMSOptions",
                column: "StudentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUserSMSOptions");

            migrationBuilder.DropTable(
                name: "SMSOptions");
        }
    }
}
