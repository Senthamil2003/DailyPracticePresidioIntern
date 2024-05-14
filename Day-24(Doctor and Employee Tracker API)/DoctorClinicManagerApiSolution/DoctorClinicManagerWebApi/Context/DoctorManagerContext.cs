using DoctorClinicManagerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicManagerWebApi.Context
{
    public class DoctorManagerContext:DbContext
    {
        public DoctorManagerContext(DbContextOptions options):base(options) 
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { DoctorId = 101, Name = "tonny", Phone = "9876543321", Experience=15,Speciality="Multispecialist" },
                new Doctor() { DoctorId = 102, Name = "stephen-strange", Phone = "9988776655", Experience=3,Speciality="Neuro" },
                new Doctor() { DoctorId = 103, Name = "Bruce-Banner", Phone = "2133443422", Experience = 5, Speciality = "Neuro" },
                new Doctor() { DoctorId = 104, Name = "peter-parker", Phone = "765790809438", Experience = 1, Speciality = "Webspecialist" }


             );
        }


    }
}
