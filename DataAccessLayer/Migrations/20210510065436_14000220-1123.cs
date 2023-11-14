﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002201123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBooklet",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasExam",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasHomework",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CourseSampleVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSampleVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSampleVideos_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSampleVideos_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSampleVideos_CourseId",
                table: "CourseSampleVideos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSampleVideos_ModUserId",
                table: "CourseSampleVideos",
                column: "ModUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSampleVideos");

            migrationBuilder.DropColumn(
                name: "HasBooklet",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HasExam",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HasHomework",
                table: "Courses");
        }
    }
}
