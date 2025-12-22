using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace PaginaIst.Areas.Identity.Services
    {
    public class SmtpEmailSender : IEmailSender
        {
        private readonly IConfiguration _config;

        public SmtpEmailSender ( IConfiguration config )
            {
            _config = config;
            }

        public async Task SendEmailAsync ( string email , string subject , string htmlMessage )
            {
            var host = _config["Smtp:Host"] ?? "smtp.office365.com";
            var port = int.TryParse(_config["Smtp:Port"], out var p) ? p : 587;

            var user = _config["Smtp:User"];
            var pass = _config["Smtp:Pass"];
            var from = _config["Smtp:From"];
            var fromName = _config["Smtp:FromName"] ?? from;

            if ( string.IsNullOrWhiteSpace ( user ) ||
                string.IsNullOrWhiteSpace ( pass ) ||
                string.IsNullOrWhiteSpace ( from ) )
                {
                throw new InvalidOperationException ( "Faltan datos SMTP en appsettings.json (Smtp:User/Pass/From)." );
                }

            using var msg = new MailMessage
                {
                From = new MailAddress(from, fromName),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
                };
            msg.To.Add ( email );

            using var client = new SmtpClient(host, port);
            client.EnableSsl = true;                 // STARTTLS (Office365)
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential ( user , pass );

            await client.SendMailAsync ( msg );
            }
        }
    }

