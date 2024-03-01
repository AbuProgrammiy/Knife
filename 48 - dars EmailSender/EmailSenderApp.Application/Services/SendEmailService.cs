using EmailSenderApp.Domen.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderApp.Application.Services
{
    public class SendEmailService : ISendEmailService
    {
        private IConfiguration _config;

        public SendEmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(EmailModel emailModel)
        {
            IConfigurationSection? emailSettings = _config.GetSection("EmailSettings");
            MailMessage? mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"]!, emailSettings["SenderName"]),
                Subject = emailModel.Subject,
                Body = emailModel.Body,
                IsBodyHtml = true,

            };
            mailMessage.To.Add(emailModel.To!);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]!))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };


            //smtpClient.UseDefaultCredentials = true;
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
