using aspnet_background_service_demo.Services;

namespace aspnet_background_service_demo
{
    public class SubscriptionManager
    {
        private readonly ILogger<SubscriptionManager> _logger;
        private readonly IEmailService _emailService;

        public SubscriptionManager(ILogger<SubscriptionManager> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task ScheduleEmailAync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ScheduleEmailAync)}: Called at {DateTime.Now}");

            await _emailService.SendEmailAsync(cancellationToken);

            _logger.LogInformation($"{nameof(ScheduleEmailAync)}: Email sent");
        }

        public async Task ScheduleBatchEmailAync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ScheduleBatchEmailAync)}: Called at {DateTime.Now}");

            await _emailService.SendBatchEmailAsync(cancellationToken);

            _logger.LogInformation($"{nameof(ScheduleBatchEmailAync)}: Email sent");
        }
    }
}
