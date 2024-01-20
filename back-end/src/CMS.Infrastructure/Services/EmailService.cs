using System.Net;
using System.Net.Mail;
using CMS.Application.Abstractions.Services;

namespace CMS.Infrastructure.Services;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(string receiverEmail, string subject, string body)
    {
        const string adminEmail = "innovative.first.user@gmail.com";
        const string password = "vmwp drfd luhw caub";

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(adminEmail, password)
        };

        return client.SendMailAsync(new MailMessage(from: adminEmail, to: receiverEmail, subject, body));
    }
}