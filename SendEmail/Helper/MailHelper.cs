using System.Net;
using System.Net.Mail;

namespace SendEmail.Helper
{
    public class MailHelper
    {
        public static bool Send(string fromAddress, string toAddress, string subject, string content)
        {
            try
            {

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                var host = configuration["Gemail:Host"];
                var port = int.Parse(configuration["Gemail:Port"]);
                var username = configuration["Gemail:Username"];
                var password = configuration["Gemail:Password"];
                var enable = bool.Parse(configuration["Gemail:SMTP:stattls:enable"]);
                var smtpClient = new SmtpClient()
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enable,
                    Credentials = new NetworkCredential(username, password)
                };
                var message = new MailMessage(fromAddress, toAddress);
                message.Subject = subject;
                message.Body = content;
                message.IsBodyHtml = true;

                smtpClient.Send(message);
                return true;
            }
            catch
            {
                return false;
            }

        }

        internal static bool Send(string email, object attachments, string v, string subject, string content)
        {
            throw new NotImplementedException();
        }
    }
}
