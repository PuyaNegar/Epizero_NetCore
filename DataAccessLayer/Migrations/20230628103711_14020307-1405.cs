using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140203071405 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_Comments_CommentId",
                table: "CourseComments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "CourseComments",
                newName: "OldStudentCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComments_CommentId",
                table: "CourseComments",
                newName: "IX_CourseComments_OldStudentCommentId");

            migrationBuilder.CreateTable(
                name: "OldStudentComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(3000)", nullable: false),
                    RegDateTimeComment = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    CommentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldStudentComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OldStudentComments_CommentTypes_CommentTypeId",
                        column: x => x.CommentTypeId,
                        principalTable: "CommentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OldStudentComments_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OldStudentComments_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OldStudentComments_CommentTypeId",
                table: "OldStudentComments",
                column: "CommentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OldStudentComments_ModUserId",
                table: "OldStudentComments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OldStudentComments_StudentUserId",
                table: "OldStudentComments",
                column: "StudentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_OldStudentComments_OldStudentCommentId",
                table: "CourseComments",
                column: "OldStudentCommentId",
                principalTable: "OldStudentComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_OldStudentComments_OldStudentCommentId",
                table: "CourseComments");

            migrationBuilder.DropTable(
                name: "OldStudentComments");

            migrationBuilder.RenameColumn(
                name: "OldStudentCommentId",
                table: "CourseComments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComments_OldStudentCommentId",
                table: "CourseComments",
                newName: "IX_CourseComments_CommentId");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(3000)", nullable: false),
                    CommentTypeId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    RegDateTimeComment = table.Column<DateTime>(type: "datetime", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_CommentTypes_CommentTypeId",
                        column: x => x.CommentTypeId,
                        principalTable: "CommentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentTypeId",
                table: "Comments",
                column: "CommentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ModUserId",
                table: "Comments",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StudentUserId",
                table: "Comments",
                column: "StudentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_Comments_CommentId",
                table: "CourseComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
