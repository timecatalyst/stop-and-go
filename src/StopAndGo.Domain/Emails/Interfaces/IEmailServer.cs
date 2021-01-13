using System.Net.Mail;
using System.Threading.Tasks;

namespace Nymbus.Domain.Emails.Interfaces
{
    public interface IEmailServer
    {
        Task SendMail(MailMessage message);
    }
}
