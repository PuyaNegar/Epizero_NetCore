using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003021114 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherMeetingFeesModel_TeacherPaymentMethods_TeacherPaymentMethodId",
                table: "TeacherMeetingFeesModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherMeetingFeesModel",
                table: "TeacherMeetingFeesModel");

            migrationBuilder.RenameTable(
                name: "TeacherMeetingFeesModel",
                newName: "TeacherMeetingFees");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherMeetingFeesModel_TeacherPaymentMethodId",
                table: "TeacherMeetingFees",
                newName: "IX_TeacherMeetingFees_TeacherPaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherMeetingFees",
                table: "TeacherMeetingFees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherMeetingFees_TeacherPaymentMethods_TeacherPaymentMethodId",
                table: "TeacherMeetingFees",
                column: "TeacherPaymentMethodId",
                principalTable: "TeacherPaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherMeetingFees_TeacherPaymentMethods_TeacherPaymentMethodId",
                table: "TeacherMeetingFees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherMeetingFees",
                table: "TeacherMeetingFees");

            migrationBuilder.RenameTable(
                name: "TeacherMeetingFees",
                newName: "TeacherMeetingFeesModel");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherMeetingFees_TeacherPaymentMethodId",
                table: "TeacherMeetingFeesModel",
                newName: "IX_TeacherMeetingFeesModel_TeacherPaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherMeetingFeesModel",
                table: "TeacherMeetingFeesModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherMeetingFeesModel_TeacherPaymentMethods_TeacherPaymentMethodId",
                table: "TeacherMeetingFeesModel",
                column: "TeacherPaymentMethodId",
                principalTable: "TeacherPaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
