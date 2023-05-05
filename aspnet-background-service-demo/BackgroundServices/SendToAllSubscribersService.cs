using aspnet_background_service_demo.Models;
using aspnet_background_service_demo.Services;

namespace aspnet_background_service_demo.BackgroundServices;

public class SendToAllSubscribersService : BackgroundService
{
    private readonly IEmailService _emailService;

    public SendToAllSubscribersService(IEmailService emailService) => _emailService = emailService;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _emailService.SendBackgroundEmailAsync(Audience.All, stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}
