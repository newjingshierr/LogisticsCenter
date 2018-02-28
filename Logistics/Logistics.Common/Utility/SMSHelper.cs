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
using System.Text.RegularExpressions;

namespace Logistics.Common
{
    public class SMSHelper
    {
        public static string GetRandom()
        {
            Random rd = new Random();
            string str = "";
            while (str.Length < 4)
            {
                int temp = rd.Next(0, 10);
                if (!str.Contains(temp + ""))
                {
                    str += temp;
                }
            }
            return str;
        }
        public static bool Send(string content, SMSTypeEnum smsType, string mobile)
        {
            LogHelper log = LogHelper.GetLogger(typeof(SMSHelper));
            string sendurl = ConfigurationManager.AppSettings["sendurl"].ToString();
            string uid = ConfigurationManager.AppSettings["SMSUser"].ToString();
            string pwd = ConfigurationManager.AppSettings["SMSPass"].ToString();
            var result = false;
            try
            {

                if (smsType == SMSTypeEnum.Register)
                {
                    string template = ConfigurationManager.AppSettings["registerTemplateID"].ToString(); ;
                    var code = "{\"code\":\"" + content + "\"}";
                    string Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd + uid, "MD5");
                    var sendMessage = string.Format("?ac=send&uid={0}&pwd={1}&template={2}&mobile={3}&content={4}", uid, Pass, template, mobile, code);
                    byte[] bTemp = System.Text.Encoding.GetEncoding("GBK").GetBytes(sendMessage);
                    String postReturn = doPostRequest(sendurl, bTemp);
                    result = postReturn.Contains("100") ? true : false;
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat(BusinessConstants.Module.CommonSMSHelpersend + ex.ToString());
            }

            return result;
        }
        private static String doPostRequest(string url, byte[] bData)
        {
            System.Net.HttpWebRequest hwRequest;
            System.Net.HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                hwRequest.Timeout = 5000;
                hwRequest.Method = "POST";
                hwRequest.ContentType = "application/x-www-form-urlencoded";
                hwRequest.ContentLength = bData.Length;

                System.IO.Stream smWrite = hwRequest.GetRequestStream();
                smWrite.Write(bData, 0, bData.Length);
                smWrite.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
                return strResult;
            }

            //get response
            try
            {
                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
            }
            return strResult;
        }
        private static void WriteErrLog(string strErr)
        {
            LogHelper log = LogHelper.GetLogger(typeof(SMSHelper));
            log.ErrorFormat("HolidayBalanceInsert is error!");
        }


        public static bool IsTelephone(string tel)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(tel, @"^(\d{3,4}-)?\d{6,8}$");
        }
        public static bool IsEmail(string mail)
        {
            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            return r.IsMatch(mail);
        }
    }

}
