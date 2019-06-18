using System;
using System.Threading.Tasks;
using Portfolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Utils
{
    public class MailHelper
    {
        public static async Task<bool> Send(Mailer email)
        {
            var (from, mail, message) = email;
            var subject = "Message from the portfolio";
            string text = message;

            var msg = new SendGridMessage
            {
                From = mail,
                Subject = subject,
                PlainTextContent = text
            };

            msg.AddTo(new EmailAddress("Julien.luccioni@outlook.fr"));

            try
            {
                string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
                var client = new SendGridClient(apiKey);
                await client.SendEmailAsync(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}