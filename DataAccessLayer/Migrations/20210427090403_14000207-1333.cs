using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002071333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderConfirmStatusTypes_OrderConfirmStatusTypeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderConfirmStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderConfirmStatusTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryFee",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InnerComment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsCalculatedDeliveryFee",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsPickup",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderAcceptDateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderConfirmStatusDateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderConfirmStatusTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PrepareDuration",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Orders",
                type: "nvarchar(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                type: "nvarchar(2000)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryFee",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InnerComment",
                table: "Orders",
                type: "nvarchar(2000)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCalculatedDeliveryFee",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPickup",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Orders",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Orders",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderAcceptDateTime",
                table: "Orders",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderConfirmStatusDateTime",
                table: "Orders",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderConfirmStatusTypeId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrepareDuration",
                table: "Orders",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderConfirmStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TitleEN = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderConfirmStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderConfirmStatusTypeId",
                table: "Orders",
                column: "OrderConfirmStatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderConfirmStatusTypes_OrderConfirmStatusTypeId",
                table: "Orders",
                column: "OrderConfirmStatusTypeId",
                principalTable: "OrderConfirmStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
