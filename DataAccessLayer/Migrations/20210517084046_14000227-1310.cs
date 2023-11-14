using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002271310 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TeacherPaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "TeacherPaymentMethodTypeId",
                table: "TeacherPaymentMethods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TeacherPaymentMethodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPaymentMethodTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPaymentMethods_TeacherPaymentMethodTypeId",
                table: "TeacherPaymentMethods",
                column: "TeacherPaymentMethodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPaymentMethods_TeacherPaymentMethodTypes_TeacherPaymentMethodTypeId",
                table: "TeacherPaymentMethods",
                column: "TeacherPaymentMethodTypeId",
                principalTable: "TeacherPaymentMethodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPaymentMethods_TeacherPaymentMethodTypes_TeacherPaymentMethodTypeId",
                table: "TeacherPaymentMethods");

            migrationBuilder.DropTable(
                name: "TeacherPaymentMethodTypes");

            migrationBuilder.DropIndex(
                name: "IX_TeacherPaymentMethods_TeacherPaymentMethodTypeId",
                table: "TeacherPaymentMethods");

            migrationBuilder.DropColumn(
                name: "TeacherPaymentMethodTypeId",
                table: "TeacherPaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "TeacherPaymentMethods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
