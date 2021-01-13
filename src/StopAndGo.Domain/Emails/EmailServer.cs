using System.Net.Mail;
using System.Threading.Tasks;
using Nymbus.Domain.Emails.Interfaces;
using Nymbus.Domain.Features.Interfaces;

namespace Nymbus.Domain.Emails
{
    public class EmailServer : IFeatureService, IEmailServer
    {
        private readonly SmtpClient _smtpClient;

        public EmailServer(SmtpClient smtpClient) => _smtpClient = smtpClient;

        public async Task SendMail(MailMessage message)
        {
            await _smtpClient.SendMailAsync(message);
        }
    }
}
