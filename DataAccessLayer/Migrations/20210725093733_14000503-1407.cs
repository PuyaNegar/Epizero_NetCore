using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140005031407 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesPartnerShares");

            migrationBuilder.CreateTable(
                name: "SalesPartnerUserShares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    SalePartnerUserId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPartnerUserShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPartnerUserShares_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPartnerUserShares_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPartnerUserShares_Users_SalePartnerUserId",
                        column: x => x.SalePartnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserShares_ModUserId",
                table: "SalesPartnerUserShares",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserShares_OrderDetailId",
                table: "SalesPartnerUserShares",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserShares_SalePartnerUserId",
                table: "SalesPartnerUserShares",
                column: "SalePartnerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesPartnerUserShares");

            migrationBuilder.CreateTable(
                name: "SalesPartnerShares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalePartnerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPartnerShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPartnerShares_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPartnerShares_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPartnerShares_Users_SalePartnerUserId",
                        column: x => x.SalePartnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerShares_ModUserId",
                table: "SalesPartnerShares",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerShares_OrderDetailId",
                table: "SalesPartnerShares",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerShares_SalePartnerUserId",
                table: "SalesPartnerShares",
                column: "SalePartnerUserId");
        }
    }
}
