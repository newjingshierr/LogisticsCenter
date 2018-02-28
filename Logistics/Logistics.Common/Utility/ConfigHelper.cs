using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Logistics.Common
{
    public class ConfigHelper
    {
        /// <summary>
        /// 获取配置节点值
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">获取失败后的默认值 默认为空字符串</param>
        /// <returns>节点值</returns>
        public static string GetConfig(string key, string defaultValue = "")
        {
            string val = System.Configuration.ConfigurationManager.AppSettings[key];
            return val == null ? defaultValue : val;
        }
    }
}
