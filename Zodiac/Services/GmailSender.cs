using System.Net;
using System.Net.Mail;
using Zodiac.Domain.Services;

namespace Zodiac.Services
{
    internal class GmailSender : IEmailSender
    {
        public void Send(string to, string subject, string body)
        {
            using var client = new SmtpClient();

            var credentials = new NetworkCredential
            {
                UserName = "Zodiacfarzad",

                Password = "Coolcup654321"
            };

            client.Credentials = credentials;

            client.Host = "smtp.gmail.com";

            client.Port = 587;

            client.EnableSsl = true;

            using var mail = new MailMessage
            {
                To = { new MailAddress(to) },

                From = new MailAddress("Zodiacfarzad@gmail.com"),

                Subject = subject,

                Body = body,

                IsBodyHtml = true
            };

            client.Send(mail);
        }
    }
}