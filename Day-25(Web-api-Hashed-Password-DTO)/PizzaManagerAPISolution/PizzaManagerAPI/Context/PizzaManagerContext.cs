using Microsoft.EntityFrameworkCore;
using PizzaManagerAPI.Model;

namespace PizzaManagerAPI.Context
{
    public class PizzaManagerContext:DbContext
    {
        public PizzaManagerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers {  get; set; }    
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() {  PizzaName= "Chicken Pizza", Price=250,Quantity=10,Size="M"},
                new Pizza() { PizzaName = "Cheese Pizza", Price = 150, Quantity = 10, Size = "L" },
                new Pizza() { PizzaName = "Veggie Pizza", Price = 150, Quantity = 10, Size = "S" },
                new Pizza() { PizzaName = "Pepperoni Pizza", Price = 250, Quantity = 10, Size = "M" }



             );
        }

    }
}
