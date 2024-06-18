using SatlinkUsersManagment1.Data;
//using SatlinkUsersManagment1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using SatlinkUsersManagment1.Models;
using SatlinkUsersManagment1.Services;

namespace SatlinkUsersManagment1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var apiService = host.Services.GetRequiredService<ApiService>();
            var userService = host.Services.GetRequiredService<UserService>();

            var users = await apiService.GetUsers();

            if (users != null)
            {
                await userService.SaveUsers(users);
                Console.WriteLine("Data fetched and saved to the database successfully.");
            }
            else
            {
                Console.WriteLine("Failed to fetch users from API.");
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
                    services.AddTransient<ApiService>();
                    services.AddTransient<UserService>();
                });
    }
}
