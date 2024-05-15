using EmployeeManagerApi.BusinessLogic;
using EmployeeManagerApi.Context;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Reepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerApi
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
            builder.Services.AddDbContext<EmployeeContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            );
            #endregion

            #region Repository
            builder.Services.AddScoped<IReposiroty<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IReposiroty<int,User>,UserRepository>();
            #endregion

            #region EmployeeBL
            builder.Services.AddScoped<EmployeeService, EmployeeBL>();
            builder.Services.AddScoped<IUserService, UserBL>();
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
