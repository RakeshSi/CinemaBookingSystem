using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Helper
{
    public class CommonMail
    {
        /*Method For Sending An Email*/

        /*Please Filled User Email Address*/
        public string SenderEmailAddress = "UserMailAddress";

        /*Please Filled User Email Password*/
        public string SenderEmailPassword = "Password";

        /*Please Change SMTP Port if requried and get an error*/
        public int SenderSMTPPort = Convert.ToInt32(587);

        public void SendMail(string Recipient, string MsgBody, string SubjectBody)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(SenderEmailAddress);
            mail.To.Add(Recipient);

            mail.Subject = SubjectBody;
            mail.Body = MsgBody;
            mail.IsBodyHtml = true;

            SmtpServer.Port = SenderSMTPPort;
            SmtpServer.Credentials = new System.Net.NetworkCredential(SenderEmailAddress, SenderEmailPassword);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
