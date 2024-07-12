using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtmApplicationApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_UserId",
                        column: x => x.UserId,
                        principalTable: "Customers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIN = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardNumber);
                    table.ForeignKey(
                        name: "FK_Cards_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "UserId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 101, "hogn@gmail.com", "John", "1234567890" },
                    { 102, "ram@gmail.com", "Ram", "1234567890" },
                    { 103, "bimu@gmail.com", "Bimu", "1234567890" },
                    { 104, "himu@gmail.com", "Himu", "1234567890" },
                    { 105, "somu@gmail.com", "Somu", "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "Balance", "UserId" },
                values: new object[,]
                {
                    { 9876543210L, 98000.0, 102 },
                    { 12345678901L, 52000.0, 101 },
                    { 23456987623L, 91000.0, 104 },
                    { 76575687653L, 88000.0, 105 },
                    { 98765432198L, 78000.0, 103 }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardNumber", "AccountNumber", "PIN" },
                values: new object[,]
                {
                    { 1234569791882001L, 76575687653L, 7319 },
                    { 1234569791882006L, 12345678901L, 4466 },
                    { 1234569791882007L, 9876543210L, 5782 },
                    { 1234569791882008L, 98765432198L, 1289 },
                    { 1234569791882009L, 23456987623L, 2522 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountNumber",
                table: "Cards",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNumber",
                table: "Transactions",
                column: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
