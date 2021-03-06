using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmailService
    {
        public static void SendMail(string email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("arunj9816@gmail.com", "sratexxttkhgspxy");


                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(email);
                msgObj.From = new MailAddress("arunj9816@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = $"http://localhost:4200/resetpassword{token}";
                client.Send(msgObj);
            }
        }
    }
}

