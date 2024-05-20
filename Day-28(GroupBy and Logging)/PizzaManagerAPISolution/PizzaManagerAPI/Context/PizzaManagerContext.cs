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
                new Pizza() { PizzaId=100, PizzaName= "Chicken Pizza", Price=250,Quantity=10,Size="M"},
                new Pizza() { PizzaId = 101, PizzaName = "Cheese Pizza", Price = 150, Quantity = 10, Size = "L" },
                new Pizza() { PizzaId = 102,PizzaName = "Veggie Pizza", Price = 150, Quantity = 10, Size = "S" },
                new Pizza() { PizzaId = 103, PizzaName = "Pepperoni Pizza", Price = 250, Quantity = 10, Size = "M" }



             );
        }

    }
}
