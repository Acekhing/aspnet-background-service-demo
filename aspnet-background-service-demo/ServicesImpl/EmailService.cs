using aspnet_background_service_demo.Models;
using aspnet_background_service_demo.Services;

namespace aspnet_background_service_demo.ServicesImpl
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        protected User? User;

        protected List<User> Users;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
            User = null;
            Users = new List<User>();
        }


        public async Task SendBatchEmailAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(SendBatchEmailAsync)}: Called at {DateTime.Now}");

            // Send mail if the request not cancelled
            if (!cancellationToken.IsCancellationRequested)
            {
                await SendToUsersAsync(Users);
            }
        }


        public async Task SendEmailAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(SendEmailAsync)}: Called at {DateTime.Now}");

            // Send mail if the request not cancelled
            if (!cancellationToken.IsCancellationRequested)
            {
                await SendToUserAsync(User);
            }
        }


        /// <summary>
        /// Sends email to subscriber
        /// </summary>
        /// <param name="user">The subscriber or receipient</param>
        /// <returns></returns>
        protected virtual Task SendToUserAsync(User? user)
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
        protected virtual Task SendToUsersAsync(List<User> users)
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
        protected virtual User? GetUserAsync()
        {
            // Logic to get User
            return User;
        }

        /// <summary>
        /// Find the user to to send the mail to
        /// </summary>
        /// <returns></returns>
        protected virtual List<User> GetUsersAsync()
        {
            // Logic to get users
            return Users;
        }
    }
}
