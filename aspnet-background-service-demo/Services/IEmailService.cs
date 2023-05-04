using aspnet_background_service_demo.Models;

namespace aspnet_background_service_demo.Services;

public interface IEmailService
{
    public Task SendEmailAsync(Mail mail, CancellationToken cancellationToken);
    public Task SendBatchEmailAsync(Mail mail, CancellationToken cancellationToken);
}
