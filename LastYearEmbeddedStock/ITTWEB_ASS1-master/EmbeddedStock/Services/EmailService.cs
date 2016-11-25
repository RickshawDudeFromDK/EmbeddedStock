using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace EmbeddedStock.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmails(List<string> recipients)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("ittwebass1@gmail.com", "insecurepass");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("ittwebass1@gmail.com");

            foreach (var recipient in recipients)
            {
                msg.To.Add(new MailAddress(recipient));
            }

            msg.Subject = "Overdue component loan";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body><b>You have exceeded the return date on a component that you have loaned.</b></body>");

            client.Send(msg);

        }
    }
}