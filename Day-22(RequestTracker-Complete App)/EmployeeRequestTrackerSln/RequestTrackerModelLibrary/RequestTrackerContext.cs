using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class RequestTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=75RBBX3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=EmployeeTracker");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RaisedByEmployee)
               .WithMany(e => e.RaisedRequests)
               .HasForeignKey(r => r.RequestRaisedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<Request>()
               .HasOne(r => r.ClosedByEmployee)
               .WithMany(e =>e.ClosedRequest)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Solution>()
                .HasOne(s => s.RaisedRequest)
                .WithMany(r => r.solutions)
                .HasForeignKey(s => s.RaisedRequestId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Solution>()
                .HasOne(s => s.AnsweredEmployee)
                .WithMany(e => e.GivenSolutions)
                .HasForeignKey(s => s.AnsweredEmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Solution)
                .WithMany(s => s.Feedbacks)
                .HasForeignKey(f => f.SolutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Employee)
                .WithMany(e => e.GivenFeedbacks)
                .HasForeignKey(f => f.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
          
           

        }
    }
}
