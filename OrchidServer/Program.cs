
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using OrchidServer.Models;
using OrchidServer.Controllers;
using System.Runtime.CompilerServices;

namespace OrchidServer
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            #region Add Database context to Dependency Injection
            //Read connection string from app settings.json
            string connectionString = builder.Configuration
                .GetSection("ConnectionStrings")
                .GetSection("OrchidDB").Value;

            //Add Database to dependency injection
            builder.Services.AddDbContext<OrchidDbContext>(
                    options => options.UseSqlServer(connectionString));

            #endregion 

            #region Add Session
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
            });
            #endregion

            #region for debugginh UI
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            var app = builder.Build();

            #region for debugginh UI
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #endregion


            #region Add Session
            app.UseSession(); //In order to enable session management
            #endregion 

            app.UseHttpsRedirection();
            app.UseStaticFiles(); //Support static files delivery from wwwroot folder
            app.MapControllers(); //Map all controllers classes

            // Configure the application to listen on all network interfaces
            // Also note the changes in launchSettings.json
            // And you should press "allow" when windows firewall prompte a message after running the server for the first time!
            //app.Urls.Add("http://*:5110");
            //app.Urls.Add("https://*:7012");
            DotNetEnv.Env.Load();
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            app.Run();
        }
    }
}
