using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SatlinkUsersManagment3.Services;

public class TimedHostedService : BackgroundService
{
    private readonly ILogger<TimedHostedService> _logger;
    private readonly ApiService _apiService;
    private readonly UserService _userService;

    public TimedHostedService(ILogger<TimedHostedService> logger, ApiService apiService, UserService userService)
    {
        _logger = logger;
        _apiService = apiService;
        _userService = userService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Timed Hosted Service is working. " + DateTime.Now);

            try
            {
                var users = await _apiService.GetUsers();

                if (users != null)
                {
                    await _userService.SaveUsers(users);
                    Console.WriteLine("Data fetched and saved to the database successfully. " + DateTime.Now);
                }
                else
                {
                    Console.WriteLine("Failed to fetch users from API. " + DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing the background service. " + DateTime.Now);
            }

            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }

        _logger.LogInformation("Timed Hosted Service is stopping. " + DateTime.Now);
    }
}
