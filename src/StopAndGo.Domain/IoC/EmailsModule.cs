using System.Net;
using System.Net.Mail;
using Autofac;
using Nymbus.Domain.Emails.Configuration;
using Microsoft.Extensions.Options;

namespace Nymbus.Domain.IoC
{
    public class EmailsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(
                ctxt =>
                {
                    var options = ctxt.Resolve<IOptions<SmtpOptions>>().Value;

                    var client = new SmtpClient(options.Host, options.Port)
                                 {
                                     DeliveryMethod = SmtpDeliveryMethod.Network,
                                     EnableSsl = options.Secure
                                 };

                    if (!string.IsNullOrEmpty(options.Username) && !string.IsNullOrEmpty(options.Password))
                    {
                        client.Credentials = new NetworkCredential(options.Username, options.Password);
                    }

                    return client;
                });
        }
    }
}
