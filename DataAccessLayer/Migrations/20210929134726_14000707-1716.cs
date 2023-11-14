using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140007071716 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_IndependentExams_IndependentExamId",
                table: "OnlineExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_IndependentExamId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "IndependentExamId",
                table: "OnlineExams");

            migrationBuilder.AddColumn<int>(
                name: "IndependentExamsModelId",
                table: "OnlineExams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_IndependentExamsModelId",
                table: "OnlineExams",
                column: "IndependentExamsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_IndependentExams_IndependentExamsModelId",
                table: "OnlineExams",
                column: "IndependentExamsModelId",
                principalTable: "IndependentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExams_IndependentExams_IndependentExamsModelId",
                table: "OnlineExams");

            migrationBuilder.DropIndex(
                name: "IX_OnlineExams_IndependentExamsModelId",
                table: "OnlineExams");

            migrationBuilder.DropColumn(
                name: "IndependentExamsModelId",
                table: "OnlineExams");

            migrationBuilder.AddColumn<int>(
                name: "IndependentExamId",
                table: "OnlineExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_IndependentExamId",
                table: "OnlineExams",
                column: "IndependentExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExams_IndependentExams_IndependentExamId",
                table: "OnlineExams",
                column: "IndependentExamId",
                principalTable: "IndependentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
