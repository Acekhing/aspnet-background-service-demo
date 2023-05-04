namespace aspnet_background_service_demo.BackgroundServices
{
    public class BatchEmailService : BackgroundService
    {

        private readonly SubscriptionManager _subscriptionManager;
        private readonly ILogger<OneTimeEmailService> _logger;

        public BatchEmailService(SubscriptionManager subscriptionManager, ILogger<OneTimeEmailService> logger)
        {
            _subscriptionManager = subscriptionManager;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _subscriptionManager.ScheduleBatchEmailAync(stoppingToken);
                await Task.Delay(5000);
            }
        }
    }
}
