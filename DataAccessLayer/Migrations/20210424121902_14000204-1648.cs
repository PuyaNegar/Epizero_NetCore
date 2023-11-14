using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002041648 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(Max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMeetings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMeetings_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(nullable: true),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    ModUserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    CoursesId = table.Column<int>(nullable: true),
                    StudentUserId = table.Column<int>(nullable: false),
                    StudentUsersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Users_StudentUsersId",
                        column: x => x.StudentUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeekSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WeekDayId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekSchedules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeekSchedules_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeekSchedules_WeekDays_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    AnswerDescription = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "date", nullable: false),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homeworks_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Homeworks_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    HomeWorkId = table.Column<int>(type: "int", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkAnswers_Homeworks_HomeWorkId",
                        column: x => x.HomeWorkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkAnswers_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkAnswers_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    HomeworkId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkFiles_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkFiles_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkAnswerFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    HomeworkAnswerId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkAnswerFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkAnswerFiles_HomeworkAnswers_HomeworkAnswerId",
                        column: x => x.HomeworkAnswerId,
                        principalTable: "HomeworkAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkAnswerFiles_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetings_CourseId",
                table: "CourseMeetings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeetings_ModUserId",
                table: "CourseMeetings",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_CoursesId",
                table: "CourseStudents",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_ModUserId",
                table: "CourseStudents",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentUsersId",
                table: "CourseStudents",
                column: "StudentUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswerFiles_HomeworkAnswerId",
                table: "HomeworkAnswerFiles",
                column: "HomeworkAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswerFiles_ModUserId",
                table: "HomeworkAnswerFiles",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswers_ModUserId",
                table: "HomeworkAnswers",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswers_StudentUserId",
                table: "HomeworkAnswers",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAnswers_HomeWorkId_StudentUserId",
                table: "HomeworkAnswers",
                columns: new[] { "HomeWorkId", "StudentUserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkFiles_HomeworkId",
                table: "HomeworkFiles",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkFiles_ModUserId",
                table: "HomeworkFiles",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_CourseMeetingId",
                table: "Homeworks",
                column: "CourseMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_ModUserId",
                table: "Homeworks",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekSchedules_CourseId",
                table: "WeekSchedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekSchedules_ModUserId",
                table: "WeekSchedules",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekSchedules_WeekDayId",
                table: "WeekSchedules",
                column: "WeekDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "HomeworkAnswerFiles");

            migrationBuilder.DropTable(
                name: "HomeworkFiles");

            migrationBuilder.DropTable(
                name: "WeekSchedules");

            migrationBuilder.DropTable(
                name: "HomeworkAnswers");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "CourseMeetings");
        }
    }
}
