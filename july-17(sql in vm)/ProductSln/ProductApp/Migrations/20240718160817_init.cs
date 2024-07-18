using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ImageUrls", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { 1, "https://example.com/laptop.jpg", "Laptop", 999.99m },
                    { 2, "https://example.com/smartphone.jpg", "Smartphone", 599.99m },
                    { 3, "https://example.com/headphones.jpg", "Headphones", 149.99m },
                    { 4, "https://example.com/tablet.jpg", "Tablet", 399.99m },
                    { 5, "https://example.com/smartwatch.jpg", "Smartwatch", 249.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
