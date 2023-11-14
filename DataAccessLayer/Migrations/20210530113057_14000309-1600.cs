using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003091600 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherPercentages_TeacherPaymentMethodId",
                table: "TeacherPercentages");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "TeacherPercentages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPercentages_TeacherPaymentMethodId",
                table: "TeacherPercentages",
                column: "TeacherPaymentMethodId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherPercentages_TeacherPaymentMethodId",
                table: "TeacherPercentages");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "TeacherPercentages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPercentages_TeacherPaymentMethodId",
                table: "TeacherPercentages",
                column: "TeacherPaymentMethodId");
        }
    }
}
