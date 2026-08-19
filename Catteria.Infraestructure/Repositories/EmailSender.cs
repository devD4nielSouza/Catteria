using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Catteria.Domain.Interfaces;

namespace Catteria.Infraestructure.Services;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _config;

    public EmailSender(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(
        string email,
        string subject,
        string htmlMessage)
    {
        var from = _config["Email:From"];
        var host = _config["Email:Host"];
        var port = _config["Email:Port"];
        var user = _config["Email:User"];
        var password = _config["Email:Password"];

        //if (string.IsNullOrWhiteSpace(email))
        //    throw new Exception("Email do destinatário está vazio.");

        //if (string.IsNullOrWhiteSpace(subject))
        //    throw new Exception("Assunto do e-mail está vazio.");

        //if (string.IsNullOrWhiteSpace(htmlMessage))
        //    throw new Exception("Conteúdo HTML do e-mail está vazio.");

        //if (string.IsNullOrWhiteSpace(from))
        //    throw new Exception("Email:From não está configurado.");

        //if (string.IsNullOrWhiteSpace(host))
        //    throw new Exception("Email:Host não está configurado.");

        //if (string.IsNullOrWhiteSpace(port))
        //    throw new Exception("Email:Port não está configurado.");

        //if (string.IsNullOrWhiteSpace(user))
        //    throw new Exception("Email:User não está configurado.");

        //if (string.IsNullOrWhiteSpace(password))
        //    throw new Exception("Email:Password não está configurado.");

        var message = new MimeMessage();

        message.From.Add(
            MailboxAddress.Parse(from)
        );

        message.To.Add(
            MailboxAddress.Parse(email)
        );

        message.Subject = subject;

        message.Body = new TextPart("html")
        {
            Text = htmlMessage
        };

        using var client = new SmtpClient();

        await client.ConnectAsync(
            host,
            int.Parse(port),
            SecureSocketOptions.StartTls
        );

        await client.AuthenticateAsync(
            user,
            password
        );

        await client.SendAsync(message);

        await client.DisconnectAsync(true);
    }
}