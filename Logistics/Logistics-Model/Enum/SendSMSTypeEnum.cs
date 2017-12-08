using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public enum SMSTypeEnum
    {
        /// <summary>
        /// 注册手机验证
        /// </summary>
        Register = 0,
        /// <summary>
        /// 发货通知
        /// </summary>
        SendPackage = 1,
        /// <summary>
        /// 退货通知
        /// </summary>
        ReturnPackage = 2,
    }
}
