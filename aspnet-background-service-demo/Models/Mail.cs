namespace aspnet_background_service_demo.Models;

public class Mail
{
    public Mail()
    {
        CC = new List<string>();
        BCC = new List<string>();
    }

    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public byte[]? Attachments { get; set; }
    public List<string> CC { get; set; }
    public List<string> BCC { get; set; }
}
