using aspnet_background_service_demo.DataAccess;
using aspnet_background_service_demo.Models;
using aspnet_background_service_demo.Services;

namespace aspnet_background_service_demo.ServicesImpl
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }


        public async Task SendBatchEmailAsync(Mail mail, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(SendBatchEmailAsync)}: Called at {DateTime.Now}");

            // Send mail if the request not cancelled
            if (!cancellationToken.IsCancellationRequested)
            {
                await SendToSubscribersAsync(GetSubscribersAsync(), mail);
            }
        }


        public async Task SendEmailAsync(Mail mail, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(SendEmailAsync)}: Called at {DateTime.Now}");

            // Send mail if the request not cancelled
            if (!cancellationToken.IsCancellationRequested)
            {
                await SendToSubscriberAsync(GetSubscriberAsync(), mail);
            }
        }


        /// <summary>
        /// Sends email to subscriber
        /// </summary>
        /// <param name="user">The subscriber or receipient</param>
        /// <returns></returns>
        protected virtual Task SendToSubscriberAsync(Subscriber? user, Mail mail)
        {
            _logger.LogInformation("Sending email to subscriber");

            // TOOD: Send email

            _logger.LogInformation("Email sent");

            return Task.CompletedTask;
        }


        /// <summary>
        /// Sends email to subscribers
        /// </summary>
        /// <param name="users">The subscribers or receipients</param>
        /// <returns></returns>
        protected virtual Task SendToSubscribersAsync(List<Subscriber> users, Mail mail)
        {
            _logger.LogInformation("Sending email to subscribers");

            // TODO: Send batch email

            _logger.LogInformation("Email sent");

            return Task.CompletedTask;
        }

        /// <summary>
        /// Find the user to to send the mail to
        /// </summary>
        /// <returns></returns>
        protected virtual Subscriber? GetSubscriberAsync(Func<Subscriber, bool>? predicate = null)
        {
            // Override and implement your own method of getting subscriber.
            // Eg: from Database etc.

            if (predicate != null)
                return Data.GetSubscribers().Where(predicate).FirstOrDefault();

            return Data.GetSubscribers().FirstOrDefault();
        }

        /// <summary>
        /// Find the user to to send the mail to
        /// </summary>
        /// <returns></returns>
        protected virtual List<Subscriber> GetSubscribersAsync(Func<Subscriber, bool>? predicate = null)
        {
            // Override and implement your own method of getting subscribers.
            // Eg: from Database etc.

            if (predicate != null)
                return Data.GetSubscribers().Where(predicate).ToList();

            return Data.GetSubscribers();
        }

        private Task SendSMTPMailAsync(Subscriber subscriber)
        {

        }
    }
}
