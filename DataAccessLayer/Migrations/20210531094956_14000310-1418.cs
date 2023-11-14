﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140003101418 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "HomeworkAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "HomeworkAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
