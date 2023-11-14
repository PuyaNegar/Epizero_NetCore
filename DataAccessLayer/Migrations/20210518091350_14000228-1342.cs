using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002281342 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherMeetingFees");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_UserGroupId",
                table: "Users",
                columns: new[] { "UserName", "UserGroupId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName_UserGroupId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "TeacherMeetingFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fee = table.Column<int>(type: "int", nullable: false),
                    TeacherPaymentMethodId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherMeetingFees_TeacherPaymentMethodId",
                table: "TeacherMeetingFees",
                column: "TeacherPaymentMethodId",
                unique: true);
        }
    }
}
