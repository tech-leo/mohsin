using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class HourlyJobService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private int minutes = 60;
    public HourlyJobService(IServiceScopeFactory _serviceScopeFactory, IConfiguration configuration)
    {
        this._serviceScopeFactory = _serviceScopeFactory;
        var minutestr = configuration["Interval_Minutes"]?.ToString() ?? string.Empty;
        if (int.TryParse(minutestr, out int minuteint))
        {
            minutes = minuteint;
        }

    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            
            // Your job logic here
            await RunJobAsync();
            
            await Task.Delay(TimeSpan.FromMinutes(minutes), stoppingToken);
        }
    }

    private async Task RunJobAsync()
    {
        new Task(async () =>
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                // Resolve the scoped service
                var scopedService = scope.ServiceProvider.GetRequiredService<IQuickBooksSyncService>();
                await scopedService.SyncEntities();
            }

        }).Start();
    }
}
