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
    public enum SendTypeEnum
    {
        Tel = 0,
        Mail = 1
    }
    public enum MailTemplateEnum
    {
        Register = 0,
    }
    public enum UserInfoLogEnum
    {
        LognIn = 0,
        LognOut = 1
    }

    public enum orderMergeStep
    {
        //待打包中
        WaitForPackage = 0,
        //客服確認中
        CustomerConfirm = 1,
        //倉庫打包中
        WarehousePackege = 2,
        //待付款
        WaitForPay = 3,
        //待發貨中
        WaitForDelivery = 4
    }

    public enum WaitForPackageStatus
    {

    }

    public enum messageType
    {
        WarehouseIn =0,
        CustomerServiceConfirm = 1,
        WarehousePackge =2,
        WaitForPay =3,
        Delivered = 4
    }
}
