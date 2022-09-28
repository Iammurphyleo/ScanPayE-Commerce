using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EmailServices
{
    public class MailService : IMailServices
    {
        public void SendingMail(string MessageSending, string MessageBody, string MessageTitle)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Scanpay", "dadamufasa@gmail.com"));
            message.To.Add(MailboxAddress.Parse(MessageSending));
            message.Subject = MessageTitle;
            message.Body = new TextPart("html")
            {
                Text = MessageBody,
            };

            string email = "scanpay84@gmail.com";
            string password = "myscanpayproject";
            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(email, password);
                client.Send(message);

            }
            finally 
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
