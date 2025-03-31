namespace In12BClockService;

public class Worker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("ok");
            await Task.Delay(1000, stoppingToken);
        }
    }
}