using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTestApp
{
    public class StudentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=75RBBX3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=sample");
        }
        public DbSet<Student> Students { get; set; }

    }
}
