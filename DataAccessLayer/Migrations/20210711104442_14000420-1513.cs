using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140004201513 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountCodeAcademyProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(nullable: true),
                    RegDateTime = table.Column<DateTime>(nullable: false),
                    ModUserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    CourseMeetingId = table.Column<int>(type: "int", nullable: true),
                    OnlineExamId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    AcademyProductTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodeAcademyProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCodeAcademyProducts_AcademyProductTypes_AcademyProductTypeId",
                        column: x => x.AcademyProductTypeId,
                        principalTable: "AcademyProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCodeAcademyProducts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCodeAcademyProducts_CourseMeetings_CourseMeetingId",
                        column: x => x.CourseMeetingId,
                        principalTable: "CourseMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCodeAcademyProducts_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountCodeAcademyProducts_OnlineExams_OnlineExamId",
                        column: x => x.OnlineExamId,
                        principalTable: "OnlineExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCodeAcademyProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCodeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmountOrPercent = table.Column<int>(nullable: false),
                    IsUseableForDiscountAcademyProduct = table.Column<bool>(nullable: false),
                    MaxDiscountAmount = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    DiscountCodeTypeId = table.Column<int>(nullable: false),
                    SalePartnerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCodes_DiscountCodeTypes_DiscountCodeTypeId",
                        column: x => x.DiscountCodeTypeId,
                        principalTable: "DiscountCodeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountCodes_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCodes_Users_SalePartnerUserId",
                        column: x => x.SalePartnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeAcademyProducts_AcademyProductTypeId",
                table: "DiscountCodeAcademyProducts",
                column: "AcademyProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeAcademyProducts_CourseId",
                table: "DiscountCodeAcademyProducts",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeAcademyProducts_CourseMeetingId",
                table: "DiscountCodeAcademyProducts",
                column: "CourseMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeAcademyProducts_ModUserId",
                table: "DiscountCodeAcademyProducts",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeAcademyProducts_OnlineExamId",
                table: "DiscountCodeAcademyProducts",
                column: "OnlineExamId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeAcademyProducts_ProductId",
                table: "DiscountCodeAcademyProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodes_DiscountCodeTypeId",
                table: "DiscountCodes",
                column: "DiscountCodeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodes_ModUserId",
                table: "DiscountCodes",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodes_SalePartnerUserId",
                table: "DiscountCodes",
                column: "SalePartnerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountCodeAcademyProducts");

            migrationBuilder.DropTable(
                name: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "DiscountCodeTypes");
        }
    }
}
