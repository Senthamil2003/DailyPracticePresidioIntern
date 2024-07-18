using Microsoft.EntityFrameworkCore;
using ProductApp.Models;

namespace ProductApp.Context
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    ProductPrice = 999.99m,
                    ImageUrls = "https://example.com/laptop.jpg"
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Smartphone",
                    ProductPrice = 599.99m,
                    ImageUrls = "https://example.com/smartphone.jpg"
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Headphones",
                    ProductPrice = 149.99m,
                    ImageUrls = "https://example.com/headphones.jpg"
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Tablet",
                    ProductPrice = 399.99m,
                    ImageUrls = "https://example.com/tablet.jpg"
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Smartwatch",
                    ProductPrice = 249.99m,
                    ImageUrls = "https://example.com/smartwatch.jpg"
                }
            );
        }


    }
}
