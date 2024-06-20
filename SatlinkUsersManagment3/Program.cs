using SatlinkUsersManagment3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using SatlinkUsersManagment3.Models;
using SatlinkUsersManagment3.Services;
using Microsoft.EntityFrameworkCore.Design;

namespace SatlinkUsersManagment3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Build and run the host
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
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

                    services.AddHostedService<TimedHostedService>();
                });
    }
}
