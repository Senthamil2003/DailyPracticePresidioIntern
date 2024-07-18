using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using ProductApp.Context;
using ProductApp.Models;
using ProductApp.Service;

namespace ProductApp
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Console.WriteLine(builder.Configuration.GetConnectionString("defaultConnection"));
          
            const string secretName = "sql";
            var keyVaultName = "sqlkeywithVm";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());



            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretName);
            
            string connect = secret.Value.Value;
            Console.WriteLine(connect);

            #region Context
            builder.Services.AddDbContext<ProductContext>(
                options => options.UseSqlServer(connect)
            );
            #endregion

            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();

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
