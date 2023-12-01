using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalService.Models
{
    public class MailHelper
    {
        public string MailServer { get; set; }
        /// <summary>
        /// username
        /// </summary>
        public string MailUserName { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string MailPassword { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string MailName { get; set; }

        public int MailPort { get; set; }
        public bool Sendgrievance(string to, string cc, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            try
            {

                MailMessage message = new MailMessage();
                // Receiver Mailbox Address 
                message.To.Add(new MailAddress(to));
                message.CC.Add(new MailAddress(cc));
                message.From = new MailAddress("Your name", "Your user name");
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = body;
                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient smtpclient = new SmtpClient(MailServer, MailPort);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword);
                //SSLConnect
                smtpclient.EnableSsl = enableSsl;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
