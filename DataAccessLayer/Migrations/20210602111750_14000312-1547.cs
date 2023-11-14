using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003121547 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestionAnswers_Users_AnsweredUserId",
                table: "StudentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestionAnswers_Users_ModUserId",
                table: "StudentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestionAnswers_StudentQuestions_StudentQuestionId",
                table: "StudentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_Courses_CourseId",
                table: "StudentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_Users_ModUserId",
                table: "StudentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_Users_StudentUserId",
                table: "StudentQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentQuestionAnswers",
                table: "StudentQuestionAnswers");

            migrationBuilder.RenameTable(
                name: "StudentQuestions",
                newName: "CourseStudentQuestions");

            migrationBuilder.RenameTable(
                name: "StudentQuestionAnswers",
                newName: "CourseStudentQuestionAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestions_StudentUserId",
                table: "CourseStudentQuestions",
                newName: "IX_CourseStudentQuestions_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestions_ModUserId",
                table: "CourseStudentQuestions",
                newName: "IX_CourseStudentQuestions_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestions_CourseId",
                table: "CourseStudentQuestions",
                newName: "IX_CourseStudentQuestions_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestionAnswers_StudentQuestionId",
                table: "CourseStudentQuestionAnswers",
                newName: "IX_CourseStudentQuestionAnswers_StudentQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestionAnswers_ModUserId",
                table: "CourseStudentQuestionAnswers",
                newName: "IX_CourseStudentQuestionAnswers_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestionAnswers_AnsweredUserId",
                table: "CourseStudentQuestionAnswers",
                newName: "IX_CourseStudentQuestionAnswers_AnsweredUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudentQuestions",
                table: "CourseStudentQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudentQuestionAnswers",
                table: "CourseStudentQuestionAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentQuestionAnswers_Users_AnsweredUserId",
                table: "CourseStudentQuestionAnswers",
                column: "AnsweredUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentQuestionAnswers_Users_ModUserId",
                table: "CourseStudentQuestionAnswers",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentQuestionAnswers_CourseStudentQuestions_StudentQuestionId",
                table: "CourseStudentQuestionAnswers",
                column: "StudentQuestionId",
                principalTable: "CourseStudentQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentQuestions_Courses_CourseId",
                table: "CourseStudentQuestions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentQuestions_Users_ModUserId",
                table: "CourseStudentQuestions",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentQuestions_Users_StudentUserId",
                table: "CourseStudentQuestions",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentQuestionAnswers_Users_AnsweredUserId",
                table: "CourseStudentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentQuestionAnswers_Users_ModUserId",
                table: "CourseStudentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentQuestionAnswers_CourseStudentQuestions_StudentQuestionId",
                table: "CourseStudentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentQuestions_Courses_CourseId",
                table: "CourseStudentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentQuestions_Users_ModUserId",
                table: "CourseStudentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentQuestions_Users_StudentUserId",
                table: "CourseStudentQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudentQuestions",
                table: "CourseStudentQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudentQuestionAnswers",
                table: "CourseStudentQuestionAnswers");

            migrationBuilder.RenameTable(
                name: "CourseStudentQuestions",
                newName: "StudentQuestions");

            migrationBuilder.RenameTable(
                name: "CourseStudentQuestionAnswers",
                newName: "StudentQuestionAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentQuestions_StudentUserId",
                table: "StudentQuestions",
                newName: "IX_StudentQuestions_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentQuestions_ModUserId",
                table: "StudentQuestions",
                newName: "IX_StudentQuestions_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentQuestions_CourseId",
                table: "StudentQuestions",
                newName: "IX_StudentQuestions_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentQuestionAnswers_StudentQuestionId",
                table: "StudentQuestionAnswers",
                newName: "IX_StudentQuestionAnswers_StudentQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentQuestionAnswers_ModUserId",
                table: "StudentQuestionAnswers",
                newName: "IX_StudentQuestionAnswers_ModUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentQuestionAnswers_AnsweredUserId",
                table: "StudentQuestionAnswers",
                newName: "IX_StudentQuestionAnswers_AnsweredUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentQuestionAnswers",
                table: "StudentQuestionAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestionAnswers_Users_AnsweredUserId",
                table: "StudentQuestionAnswers",
                column: "AnsweredUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestionAnswers_Users_ModUserId",
                table: "StudentQuestionAnswers",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestionAnswers_StudentQuestions_StudentQuestionId",
                table: "StudentQuestionAnswers",
                column: "StudentQuestionId",
                principalTable: "StudentQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestions_Courses_CourseId",
                table: "StudentQuestions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestions_Users_ModUserId",
                table: "StudentQuestions",
                column: "ModUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestions_Users_StudentUserId",
                table: "StudentQuestions",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
