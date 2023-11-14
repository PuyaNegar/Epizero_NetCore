using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002262220 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherPaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherPaymentMethods_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherPaymentMethods_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherPaymentMethods_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeachercheckoutSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsCheckout = table.Column<bool>(type: "bit", nullable: false),
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
                name: "TeacherMeetingFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fee = table.Column<int>(type: "int", nullable: false),
                    TeacherPaymentMethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherMeetingFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherMeetingFees_TeacherPaymentMethods_TeacherPaymentMethodId",
                        column: x => x.TeacherPaymentMethodId,
                        principalTable: "TeacherPaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherPercentages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TeacherPaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPercentages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherPercentages_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherPercentages_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherPercentages_TeacherPaymentMethods_TeacherPaymentMethodId",
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
                    TeachercheckoutScheduleId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TeacherMeetingFees_TeacherPaymentMethodId",
                table: "TeacherMeetingFees",
                column: "TeacherPaymentMethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPaymentMethods_CourseId",
                table: "TeacherPaymentMethods",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPaymentMethods_ModUserId",
                table: "TeacherPaymentMethods",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPaymentMethods_TeacherId",
                table: "TeacherPaymentMethods",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPercentages_CityId",
                table: "TeacherPercentages",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPercentages_ModUserId",
                table: "TeacherPercentages",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPercentages_TeacherPaymentMethodId",
                table: "TeacherPercentages",
                column: "TeacherPaymentMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachercheckouts");

            migrationBuilder.DropTable(
                name: "TeacherMeetingFees");

            migrationBuilder.DropTable(
                name: "TeacherPercentages");

            migrationBuilder.DropTable(
                name: "TeachercheckoutSchedules");

            migrationBuilder.DropTable(
                name: "TeacherPaymentMethods");
        }
    }
}
