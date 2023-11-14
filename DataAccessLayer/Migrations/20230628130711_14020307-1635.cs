using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140203071635 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseComments");

            migrationBuilder.CreateTable(
                name: "CommentOldStudentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inx = table.Column<int>(nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    OldStudentCommentId = table.Column<int>(type: "int", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentOldStudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentOldStudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentOldStudentCourses_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentOldStudentCourses_OldStudentComments_OldStudentCommentId",
                        column: x => x.OldStudentCommentId,
                        principalTable: "OldStudentComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentOldStudentCourses_CourseId",
                table: "CommentOldStudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentOldStudentCourses_ModUserId",
                table: "CommentOldStudentCourses",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentOldStudentCourses_OldStudentCommentId",
                table: "CommentOldStudentCourses",
                column: "OldStudentCommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentOldStudentCourses");

            migrationBuilder.CreateTable(
                name: "CourseComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    OldStudentCommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseComments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseComments_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseComments_OldStudentComments_OldStudentCommentId",
                        column: x => x.OldStudentCommentId,
                        principalTable: "OldStudentComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_CourseId",
                table: "CourseComments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_ModUserId",
                table: "CourseComments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_OldStudentCommentId",
                table: "CourseComments",
                column: "OldStudentCommentId");
        }
    }
}
