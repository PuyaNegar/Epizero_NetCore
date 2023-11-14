using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003021052 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPaymentMethods_Users_TeacherId",
                table: "TeacherPaymentMethods");

            migrationBuilder.DropTable(
                name: "Teachercheckouts");

            migrationBuilder.DropTable(
                name: "TeachercheckoutSchedules");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "TeacherPaymentMethods",
                newName: "TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherPaymentMethods_TeacherId",
                table: "TeacherPaymentMethods",
                newName: "IX_TeacherPaymentMethods_TeacherUserId");

            migrationBuilder.CreateTable(
                name: "TeacherMeetingFeesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fee = table.Column<int>(nullable: false),
                    TeacherPaymentMethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherMeetingFeesModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherMeetingFeesModel_TeacherPaymentMethods_TeacherPaymentMethodId",
                        column: x => x.TeacherPaymentMethodId,
                        principalTable: "TeacherPaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSattlementSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsSettled = table.Column<bool>(type: "bit", nullable: false),
                    TeacherPaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSattlementSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSattlementSchedules_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherSattlementSchedules_TeacherPaymentMethods_TeacherPaymentMethodId",
                        column: x => x.TeacherPaymentMethodId,
                        principalTable: "TeacherPaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSattlements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    SettledAmount = table.Column<int>(type: "int", nullable: false),
                    TeacherSattlementScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSattlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSattlements_TeacherSattlementSchedules_TeacherSattlementScheduleId",
                        column: x => x.TeacherSattlementScheduleId,
                        principalTable: "TeacherSattlementSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherMeetingFeesModel_TeacherPaymentMethodId",
                table: "TeacherMeetingFeesModel",
                column: "TeacherPaymentMethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSattlements_TeacherSattlementScheduleId",
                table: "TeacherSattlements",
                column: "TeacherSattlementScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSattlementSchedules_ModUserId",
                table: "TeacherSattlementSchedules",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSattlementSchedules_TeacherPaymentMethodId",
                table: "TeacherSattlementSchedules",
                column: "TeacherPaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPaymentMethods_Users_TeacherUserId",
                table: "TeacherPaymentMethods",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPaymentMethods_Users_TeacherUserId",
                table: "TeacherPaymentMethods");

            migrationBuilder.DropTable(
                name: "TeacherMeetingFeesModel");

            migrationBuilder.DropTable(
                name: "TeacherSattlements");

            migrationBuilder.DropTable(
                name: "TeacherSattlementSchedules");

            migrationBuilder.RenameColumn(
                name: "TeacherUserId",
                table: "TeacherPaymentMethods",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherPaymentMethods_TeacherUserId",
                table: "TeacherPaymentMethods",
                newName: "IX_TeacherPaymentMethods_TeacherId");

            migrationBuilder.CreateTable(
                name: "TeachercheckoutSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsCheckout = table.Column<bool>(type: "bit", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TeacherPaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachercheckoutSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachercheckoutSchedules_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachercheckoutSchedules_TeacherPaymentMethods_TeacherPaymentMethodId",
                        column: x => x.TeacherPaymentMethodId,
                        principalTable: "TeacherPaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachercheckouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    TeachercheckoutScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachercheckouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachercheckouts_TeachercheckoutSchedules_TeachercheckoutScheduleId",
                        column: x => x.TeachercheckoutScheduleId,
                        principalTable: "TeachercheckoutSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachercheckouts_TeachercheckoutScheduleId",
                table: "Teachercheckouts",
                column: "TeachercheckoutScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeachercheckoutSchedules_ModUserId",
                table: "TeachercheckoutSchedules",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachercheckoutSchedules_TeacherPaymentMethodId",
                table: "TeachercheckoutSchedules",
                column: "TeacherPaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPaymentMethods_Users_TeacherId",
                table: "TeacherPaymentMethods",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
