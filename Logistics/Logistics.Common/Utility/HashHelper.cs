using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logistics.Common
{
    public class HashHelper
    {
        public static byte[] ComputeHash(string pwd)
        {
            SHA1 sha = SHA1.Create();
            byte[] bytePassword = sha.ComputeHash(Encoding.Unicode.GetBytes(pwd));
            return bytePassword;
        }


        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }


        public static bool ProcessSqlStr(string Str)
        {
            bool ReturnValue = false;
            try
            {
                if (Str.Trim() != "")
                {
                    string SqlStr = "exec|insert+|select+|delete|update|count|chr|mid|master+|truncate|char|declare|drop+|drop+table|creat+|create|*|iframe|script|";
                    SqlStr += "exec+|insert|delete+|update+|count(|count+|chr+|+mid(|+mid+|+master+|truncate+|char+|+char(|declare+|drop+table|creat+table";
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.ToLower().IndexOf(ss) >= 0)
                        {
                            ReturnValue = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = true;
            }
            return ReturnValue;
        }

    }
}
