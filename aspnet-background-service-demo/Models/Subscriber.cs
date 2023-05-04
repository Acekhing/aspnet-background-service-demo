namespace aspnet_background_service_demo.Models;

public class Subscriber
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string DeviceId { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int Age { get; set; }
}
