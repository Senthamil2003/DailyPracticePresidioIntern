using Microsoft.EntityFrameworkCore;
using PizzaManagerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaManagerApp.Contexts
{
    public class PizzaAppContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=75RBBX3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Pizza;");
        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
