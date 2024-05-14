using EmployeeManagerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerApi.Context
{
    public class EmployeeContext:DbContext
    {

        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 101, Name = "Ramu", Phone = "9876543321", Image = "" },
                new Employee() { EmployeeId = 102, Name = "Somu", Phone = "9988776655", Image = "" }
             );
        }
    }
}
