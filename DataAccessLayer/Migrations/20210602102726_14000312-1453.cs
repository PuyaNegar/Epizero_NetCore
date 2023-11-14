using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003121453 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_Users_UsersModelId",
                table: "OnlineExams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestionAnswers_Users_AnswerUserId",
                table: "StudentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_Users_StudetUserId",
                table: "StudentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_UsersModelId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "UsersModelId",
                table: "OnlineExams");

            migrationBuilder.RenameColumn(
                name: "StudetUserId",
                table: "StudentQuestions",
                newName: "StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestions_StudetUserId",
                table: "StudentQuestions",
                newName: "IX_StudentQuestions_StudentUserId");

            migrationBuilder.RenameColumn(
                name: "AnswerUserId",
                table: "StudentQuestionAnswers",
                newName: "AnsweredUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestionAnswers_AnswerUserId",
                table: "StudentQuestionAnswers",
                newName: "IX_StudentQuestionAnswers_AnsweredUserId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "StudentQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_CourseId",
                table: "StudentQuestions",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestionAnswers_Users_AnsweredUserId",
                table: "StudentQuestionAnswers",
                column: "AnsweredUserId",
                principalTable: "Users",
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
                name: "FK_StudentQuestions_Users_StudentUserId",
                table: "StudentQuestions",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestionAnswers_Users_AnsweredUserId",
                table: "StudentQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_Courses_CourseId",
                table: "StudentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_Users_StudentUserId",
                table: "StudentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestions_CourseId",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentQuestions");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "StudentQuestions",
                newName: "StudetUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestions_StudentUserId",
                table: "StudentQuestions",
                newName: "IX_StudentQuestions_StudetUserId");

            migrationBuilder.RenameColumn(
                name: "AnsweredUserId",
                table: "StudentQuestionAnswers",
                newName: "AnswerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestionAnswers_AnsweredUserId",
                table: "StudentQuestionAnswers",
                newName: "IX_StudentQuestionAnswers_AnswerUserId");

            migrationBuilder.AddColumn<int>(
                name: "UsersModelId",
                table: "OnlineExams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_UsersModelId",
                table: "OnlineExams",
                column: "UsersModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_Users_UsersModelId",
                table: "OnlineExams",
                column: "UsersModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestionAnswers_Users_AnswerUserId",
                table: "StudentQuestionAnswers",
                column: "AnswerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestions_Users_StudetUserId",
                table: "StudentQuestions",
                column: "StudetUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
