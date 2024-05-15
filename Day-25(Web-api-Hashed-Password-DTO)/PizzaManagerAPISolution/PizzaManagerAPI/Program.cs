using Microsoft.EntityFrameworkCore;
using PizzaManagerAPI.Context;
using PizzaManagerAPI.Interface;
using PizzaManagerAPI.Model;
using PizzaManagerAPI.Repository;
using PizzaManagerAPI.Services;

namespace PizzaManagerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region Context
            builder.Services.AddDbContext<PizzaManagerContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            );
            #endregion

            #region Repository
            builder.Services.AddScoped<IReposiroty<int, Customer>, CustomerRepository>();
            builder.Services.AddScoped<IReposiroty<int, UserCredential>, UserCredentialRepository>();
            #endregion

            #region EmployeeBL
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            #endregion

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
