using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading;
using TaxdoAssignment.Application.Shared;
using TaxdoAssignment.Domain;

namespace TaxdoAssignment.Infrastructure;

public class EmailSender(EmailSettings settings) : IEmailSender
{
    public async Task SendWelcomeEmailAsync(
        string userName,
        string receiver,
        CancellationToken cancellationToken = default)
    {
        var subject = "Welcome";
        var body = $@"
            Dear {userName}
            Welcome to our sites!!!
        ";

        using var client = new SmtpClient(settings.SmtpServer, settings.Port)
        {
            EnableSsl = settings.UseSsl,
            Credentials = new NetworkCredential(settings.Username, settings.Password)
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(settings.FromEmail, settings.FromName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(receiver);

        await client.SendMailAsync(mailMessage, cancellationToken);
    }
}
