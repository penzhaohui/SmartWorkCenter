using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.smartwork.Util
{
    public class EmailUtil
    {
        public static bool SendEmail(string from, string to, string cc, string subject, string content)
        {
            string host = "smtp.exmail.qq.com"; // from database table
            int port = 25;
            string user = ConfigurationManager.AppSettings["email_user"];
            string password = ConfigurationManager.AppSettings["email_password"];
            bool auth = true;

            /*** Below code is copied from http://www.cnblogs.com/youring2/archive/2008/11/29/1343911.html ***/
            SmtpClient client = new SmtpClient(host, port);

            //MailAddress fromAddress = new MailAddress(from, "Accela Support Team", Encoding.UTF8);
            //MailAddress toAddress = new MailAddress(to, "", Encoding.UTF8);
            //MailAddressCollection ccAddressCollection = new MailAddressCollection();
            
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from, "Accela Support Team", Encoding.UTF8);
            string[] toEmailAddresses = to.Split(';');
            foreach (string emailAddress in toEmailAddresses)
            {
                if (String.IsNullOrEmpty(emailAddress)) continue;

                message.To.Add(emailAddress);
            }        

            string[] ccEmailAddresses = cc.Split(';');
            foreach (string emailAddress in ccEmailAddresses)
            {
                if (String.IsNullOrEmpty(emailAddress)) continue;
                
                message.CC.Add(emailAddress);
            }

            message.Subject = subject;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = content;
            message.BodyEncoding = Encoding.UTF8;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.EnableSsl = auth;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(user, password);
            client.Send(message);

            return true;
        }

        public static bool UpdateEmailServerSetting(string host, string port, bool auth, string user, string password)
        {
            return true;
        }
    }
}
