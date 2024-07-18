using EmployeeManagerApi.BusinessLogic;
using EmployeeManagerApi.Context;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Reepository;
using EmployeeManagerApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;


namespace EmployeeManagerApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            const string secretName = "connectionstring";
            var keyVaultName = "secretsql1";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            

            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine($"Your secret is '{secret.Value.Value}'.");

           
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            });
            //Debug.WriteLine(builder.Configuration["TokenKey:JWT"]);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"])),
                   
                        
                    };

                });

            builder.Services.AddControllers();
            string connectionString = secret.Value.Value;
            Console.WriteLine(builder.Configuration.GetConnectionString("defaultConnection"));
            Console.WriteLine(connectionString);
            #region Context
            builder.Services.AddDbContext<EmployeeContext>(
                options => options.UseSqlServer(connectionString)
            );
            #endregion

            #region Repository
            builder.Services.AddScoped<IReposiroty<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IReposiroty<int,User>,UserRepository>();
            builder.Services.AddScoped<IReposiroty<int, Request>, RequestRepository>();

            #endregion

            #region EmployeeBL
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAdminService, AdminService>();



            #endregion




            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
