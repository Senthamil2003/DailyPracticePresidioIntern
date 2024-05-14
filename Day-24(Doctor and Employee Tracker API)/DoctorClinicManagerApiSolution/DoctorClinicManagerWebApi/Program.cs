using DoctorClinicManagerWebApi.Context;
using DoctorClinicManagerWebApi.DoctorBusinessLogic;
using DoctorClinicManagerWebApi.Interface;
using DoctorClinicManagerWebApi.Models;
using DoctorClinicManagerWebApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicManagerWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DoctorManagerContext>(
              options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
          );
            builder.Services.AddScoped<IReposiroty<int,Doctor>, DoctorRepository>();

            builder.Services.AddScoped<IDoctorService, DoctorBL>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
