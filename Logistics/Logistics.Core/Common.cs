using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logistics.Core
{
    public class Common
    {
        /*
    * @author 李效伦
    * 
    * 判断一个字符串是不是合法
    */

        public static bool Islegal(string text)
        {
            Regex regExp = new Regex("[~!@#$%^&*()=+[\\]{}''\";:/?.,><`|！·￥…—（）\\-、；：。，》《]");
            return regExp.IsMatch(text);
        }
    }
}
