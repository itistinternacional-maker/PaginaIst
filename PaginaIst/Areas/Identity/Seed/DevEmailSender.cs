using Microsoft.AspNetCore.Identity.UI.Services;

namespace PaginaIst.Areas.Identity.Services
{
    public class DevEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine("=== EMAIL (DEV) ===");
            Console.WriteLine($"To: {email}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine(htmlMessage);
            Console.WriteLine("===================");
            return Task.CompletedTask;
        }
    }
}
