using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Catteria.Domain.Interfaces;

namespace Catteria.Infraestructure.Services;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _config;

    // Construtor que recebe as configurações da aplicação via injeção de dependência
    public EmailSender(IConfiguration config) => _config = config;

    // Método assíncrono responsável por configurar e enviar o e-mail
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Cria uma nova instância de mensagem de e-mail
        var message = new MimeMessage();
        
        // Define o remetente buscando o endereço nas configurações da aplicação
        message.From.Add(MailboxAddress.Parse(_config["Email:From"]));
        
        // Define o destinatário utilizando o endereço passado por parâmetro
        message.To.Add(MailboxAddress.Parse(email));
        
        // Define o assunto do e-mail com base no parâmetro recebido
        message.Subject = subject;
        
        // Define o corpo do e-mail indicando que o formato do texto é HTML
        message.Body = new TextPart("html") { Text = htmlMessage };

        // Instancia o cliente SMTP e garante que seus recursos sejam liberados ao final do escopo (using)
        using var client = new SmtpClient();
        
        // Conecta ao servidor SMTP usando Host e Porta das configurações, habilitando criptografia TLS
        await client.ConnectAsync(
            _config["Email:Host"],
            int.Parse(_config["Email:Port"]!),
            SecureSocketOptions.StartTls);

        // Autentica no servidor SMTP com o usuário e a senha definidos nas configurações
        await client.AuthenticateAsync(_config["Email:User"], _config["Email:Password"]);
        
        // Envia a mensagem de e-mail montada anteriormente
        await client.SendAsync(message);
        
        // Desconecta e encerra a comunicação com o servidor SMTP de forma limpa
        await client.DisconnectAsync(true);
    }
}