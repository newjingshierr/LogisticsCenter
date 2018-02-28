using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Logistics_Model;
using System.Configuration;
using Akmii;
using System.Net.Mail;

namespace Logistics.Common
{
    public class MailHelper
    {
        public static bool Send(string mailTo, string code, MailTemplateEnum templateEnum)
        {
            var result = true;
            var title = "";
            var body = "";
            if (templateEnum == MailTemplateEnum.Register)
            {
                title = BusinessConstants.RegisterMailTemplate.Title;
                body = string.Format(BusinessConstants.RegisterMailTemplate.body, code);
            }

            try
            {
                MailAddress toMail = new MailAddress(mailTo);//接收者邮箱
                MailAddress fromMail = new MailAddress(ConfigurationManager.AppSettings["mailAdmin"].ToString(), "Mainland");//发送者邮箱       
                MailMessage mail = new MailMessage(fromMail, toMail);

                mail.Subject = title;
                mail.IsBodyHtml = true;//是否支持HTML
                mail.Body = body;
                SmtpClient client = new SmtpClient();
                client.Host = ConfigurationManager.AppSettings["mailHost"].ToString();//设置发送者邮箱对应的smtpserver
                client.UseDefaultCredentials = false;
                //  client.Port = 465;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["mailAdmin"].ToString(), ConfigurationManager.AppSettings["mailPass"].ToString());
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                try
                {
                    client.Send(mail);
                }
                catch (SmtpException ex)
                {
                    //Console.Write(ex.Message);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
