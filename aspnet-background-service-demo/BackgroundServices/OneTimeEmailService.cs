namespace aspnet_background_service_demo.BackgroundServices;

public class OneTimeEmailService : BackgroundService
{
    private readonly SubscriptionManager _subscriptionManager;
    private readonly ILogger<OneTimeEmailService> _logger;

    public OneTimeEmailService(SubscriptionManager subscriptionManager, ILogger<OneTimeEmailService> logger)
    {
        _subscriptionManager = subscriptionManager;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _subscriptionManager.ScheduleEmailAync(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(10000));
        }
    }
}
