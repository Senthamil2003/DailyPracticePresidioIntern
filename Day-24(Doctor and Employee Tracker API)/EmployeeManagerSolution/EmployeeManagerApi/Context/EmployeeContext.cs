using EmployeeManagerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerApi.Context
{
    public class EmployeeContext :DbContext
    {
       
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 101, Name = "Ramu", Phone = "9876543321", Image = "" ,Role="User"},
                new Employee() { EmployeeId = 102, Name = "Somu", Phone = "9988776655", Image = "",Role="Admin" }
             );
        }
    }
}
