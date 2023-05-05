using aspnet_background_service_demo.Models;
using aspnet_background_service_demo.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace aspnet_background_service_demo.ServicesImpl
{
    public class SmtpService : IEmailService
    {
        private readonly ILogger<SmtpService> _logger;
        private SubscriptionManager _subscriptionManager;

        public SmtpService(ILogger<SmtpService> logger)
        {
            _logger = logger;
            _subscriptionManager = new SubscriptionManager();
        }


        public async Task SendBackgroundEmailAsync(Audience audience, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(SendBackgroundEmailAsync)}: Started");

            // Send Email if the request not cancelled
            if (!cancellationToken.IsCancellationRequested)
            {
                // TODO: Send Email
                switch (audience)
                {
                    case Audience.All:
                        _logger.LogInformation($"{nameof(SendBackgroundEmailAsync)}: Broadcasting to All");
                        foreach (var subscriber in _subscriptionManager.GetAllSubscribers())
                        {
                            await SendAsync(subscriber);
                        }
                        break;
                }
            }

            _logger.LogInformation($"{nameof(SendBackgroundEmailAsync)}: Finshed");
        }

        private async Task SendAsync(Subscriber subscriber)
        {
            // Set addresses
            var addressFrom = new MailboxAddress(subscriber.UserName, subscriber.Email);
            var addressTo = new MailboxAddress(subscriber.UserName, subscriber.Email);

            // Create email message
            var email = new MimeMessage();

            // Set email fields
            email.From.Add(addressFrom);
            email.To.Add(addressTo);
            email.Subject = "Test email subject";
            email.Body = new TextPart(TextFormat.Html) { Text = "Test email body" };


            // Configure SMTP server
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("william.ohara94@ethereal.email", "dfuC7eDf5VUUajXCzR");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

        }

    }
}
