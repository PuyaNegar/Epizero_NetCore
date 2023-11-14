﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _1400070661030 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserOptions_CourseId_SalesPartnerUserId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserOptions_CourseId",
                table: "SalesPartnerUserOptions",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPartnerUserOptions_CourseId",
                table: "SalesPartnerUserOptions");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPartnerUserOptions_CourseId_SalesPartnerUserId",
                table: "SalesPartnerUserOptions",
                columns: new[] { "CourseId", "SalesPartnerUserId" },
                unique: true);
        }
    }
}
