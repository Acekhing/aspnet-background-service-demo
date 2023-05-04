namespace aspnet_background_service_demo.Services;

public interface IEmailService
{
    public Task SendEmailAsync(CancellationToken cancellationToken);
    public Task SendBatchEmailAsync(CancellationToken cancellationToken);
}
