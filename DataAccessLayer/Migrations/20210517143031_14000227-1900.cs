using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002271900 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CourseMeetings");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "CourseMeetings");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "CourseMeetings",
                type: "datetime",
                nullable: false);
                //defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "CourseMeetings");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CourseMeetings",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "CourseMeetings",
                type: "time(7)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
