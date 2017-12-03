using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logistics.Common
{
    /// <summary>
    /// 文件日志记录
    /// </summary>
    public class FileLogHelper
    {
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="fname">txt文件路径</param>
        public static void DeleteLog(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
            catch { }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="filePath">txt文件路径</param>
        /// <param name="fileName">txt文件名</param>
        /// <param name="message">日志信息</param>
        public static void WriteLog(string filePath, string fileName, string message)
        {
            string fileFullPath = filePath + fileName;
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                if (!File.Exists(fileFullPath))
                {
                    File.Create(fileFullPath).Close();
                }
                using (StreamWriter sw = new StreamWriter(fileFullPath, true))
                {
                    sw.WriteLine(message);
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (Exception e) { }

        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="fileName">txt文件名</param>
        /// <param name="message">日志信息</param>
        public static void WriteLog(string fileName, string message)
        {
            string fileFullPath = ConfigHelper.GetConfig("ApiLog");
            try
            {
                if (!Directory.Exists(fileFullPath))
                {
                    Directory.CreateDirectory(fileFullPath);
                }
                using (StreamWriter sw = new StreamWriter(fileFullPath, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "~" + message);
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (Exception e) { }

        }



        /// <summary>
        /// 记日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fname"></param>
        public static void WritTxtLog(string message, string fname)
        {
            if (string.IsNullOrEmpty(fname)) return;
            string baseFilePath = ConfigHelper.GetConfig("ApiLog");
            if (!Directory.Exists(baseFilePath))
            {
                Directory.CreateDirectory(baseFilePath);
            }
            try
            {
                FileStream f = new FileStream(fname, FileMode.Append);
                StreamWriter w = new StreamWriter(f, System.Text.Encoding.UTF8);
                w.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "~" + message);
                w.Flush();
                w.Close();
            }
            catch
            {
            }
        }
    }
}
