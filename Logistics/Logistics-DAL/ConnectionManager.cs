using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akmii.Core.DataAccess;
using System.Configuration;

namespace Logistics_DAL
{
    public class ConnectionManager
    {
        public static string connectionStr = ConfigurationManager.ConnectionStrings["Logistics"].ConnectionString;
        /// <summary>
        /// 写库
        /// </summary>
        /// <returns></returns>
        public static AkmiiMySqlConnection GetWriteDB()
        {
            return new AkmiiMySqlConnection(connectionStr);
        }

        /// <summary>
        /// 读库
        /// </summary>
        /// <returns></returns>
        public static AkmiiMySqlConnection GetReadDB()
        {
            return new AkmiiMySqlConnection(connectionStr);
        }

        /// <summary>
        /// 获取读库或者写库  
        /// </summary>
        /// <param name="isRead">默认读库 true</param>
        /// <returns></returns>
        public static AkmiiMySqlConnection GetReadOrWrite(bool isRead = true)
        {
            return new AkmiiMySqlConnection(connectionStr);
        }

        /// <summary>
        /// 获取事物
        /// </summary>
        /// <returns></returns>
        public static AkmiiMySqlTransaction GetSqlTrans()
        {
            return new AkmiiMySqlTransaction(connectionStr);
        }


        public static Akmii.Core.DataAccess.AkmiiMySqlConnection GetWriteConn()
        {
            return new Akmii.Core.DataAccess.AkmiiMySqlConnection(connectionStr);
        }

        public static Akmii.Core.DataAccess.AkmiiMySqlConnection GetReadConn( bool isWrite = false)
        {
            return new Akmii.Core.DataAccess.AkmiiMySqlConnection(connectionStr);
        }

    }
}
