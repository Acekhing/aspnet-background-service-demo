using aspnet_background_service_demo.Models;

namespace aspnet_background_service_demo.Services;

public interface IEmailService
{
    public Task SendBackgroundEmailAsync(Audience audience, CancellationToken cancellationToken);
}
