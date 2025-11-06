using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit; 

namespace GuestHouseBooking.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config) {
            _config = config;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body) {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailSettings:SenderEmail"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["EmailSettings:SmtpServer"],
                _config.GetValue<int>("EmailSettings:SmtpPort"),
                SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(_config["EmailSettings:SenderEmail"],
                    _config["EmailSettings:SenderPassword"]);

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true); 
        }
    }
}
