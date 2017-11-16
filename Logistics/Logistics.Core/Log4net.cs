using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Core
{
    public class Log4net
    {
        /// <summary>
        /// 配置文件log4net.config是否加载
        /// </summary>
        public static readonly bool IsConfigLoaded = false;
        public static string ConfigFileName = "log4net.config";
        private static log4net.ILog logger = LogManager.GetLogger(typeof(Log4net));

          static Log4net()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(ConfigFileName);
            if (File.Exists(path))
            {
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
                IsConfigLoaded = true;
            }
        }

        public static void Error(string message)
        {
            if (IsConfigLoaded)
            {
                logger.ErrorFormat(message);
            }
        }

        public static void Error(Type type, string message)
        {
            if (IsConfigLoaded)
            {
                log4net.ILog logger = LogManager.GetLogger(type);
                logger.ErrorFormat(message);
            }
        }
    }
}
