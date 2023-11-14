using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002071316 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TitleEN = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TitleEN = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "OrderStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TitleEN = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGateways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGateways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousBalance = table.Column<int>(type: "int", nullable: false),
                    DepositAmount = table.Column<int>(type: "int", nullable: false),
                    WithdrawalAmount = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPickup = table.Column<bool>(type: "bit", nullable: false),
                    UniqueId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    DeliveryFee = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<int>(type: "int", nullable: false),
                    PrepareDuration = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    IsCalculatedDeliveryFee = table.Column<bool>(type: "bit", nullable: false),
                    OrderAcceptDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderStatueDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderConfirmStatusDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    InnerComment = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: false),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    FinalInvoiceId = table.Column<int>(type: "int", nullable: true),
                    ModUserId = table.Column<int>(type: "int", nullable: true),
                    OrderConfirmStatusTypeId = table.Column<int>(type: "int", nullable: true),
                    OrderStatusTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderConfirmStatusTypes_OrderConfirmStatusTypeId",
                        column: x => x.OrderConfirmStatusTypeId,
                        principalTable: "OrderConfirmStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatusTypes_OrderStatusTypeId",
                        column: x => x.OrderStatusTypeId,
                        principalTable: "OrderStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "varchar(20)", nullable: false),
                    IssuedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatusDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatusTypeId = table.Column<int>(type: "int", nullable: false),
                    RefInvoiceId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceStatusTypes_InvoiceStatusTypeId",
                        column: x => x.InvoiceStatusTypeId,
                        principalTable: "InvoiceStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceTypes_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalTable: "InvoiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Invoices_RefInvoiceId",
                        column: x => x.RefInvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TrackingNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    PaymentDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentGatewayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentGateways_PaymentGatewayId",
                        column: x => x.PaymentGatewayId,
                        principalTable: "PaymentGateways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_InvoiceId",
                table: "FinancialTransactions",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_OrderId",
                table: "FinancialTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceNo",
                table: "Invoices",
                column: "InvoiceNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceStatusTypeId",
                table: "Invoices",
                column: "InvoiceStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceTypeId",
                table: "Invoices",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RefInvoiceId",
                table: "Invoices",
                column: "RefInvoiceId",
                unique: true,
                filter: "[RefInvoiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StudentUserId",
                table: "Invoices",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FinalInvoiceId",
                table: "Orders",
                column: "FinalInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ModUserId",
                table: "Orders",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderConfirmStatusTypeId",
                table: "Orders",
                column: "OrderConfirmStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusTypeId",
                table: "Orders",
                column: "OrderStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StudentUserId",
                table: "Orders",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UniqueId",
                table: "Orders",
                column: "UniqueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentGatewayId",
                table: "Payments",
                column: "PaymentGatewayId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialTransactions_Invoices_InvoiceId",
                table: "FinancialTransactions",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialTransactions_Orders_OrderId",
                table: "FinancialTransactions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Invoices_FinalInvoiceId",
                table: "Orders",
                column: "FinalInvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Invoices_FinalInvoiceId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "FinancialTransactions");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentGateways");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoiceStatusTypes");

            migrationBuilder.DropTable(
                name: "InvoiceTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderConfirmStatusTypes");

            migrationBuilder.DropTable(
                name: "OrderStatusTypes");
        }
    }
}
