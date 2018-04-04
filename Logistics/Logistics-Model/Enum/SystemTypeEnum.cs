﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public enum IndexRequestEnum
    {
        CustomerOrder =1,
        Member = 2,
        WarehouseAdmin =3,
        CustomerService = 4,
        ExpressNo =5
    }

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

    public enum orderMergeStepEnum
    {
        //待打包中
        WaitForPackage = 1,
        //客服確認中
        CustomerServiceConfirm = 2,
        //倉庫打包中
        WarehousePackege = 3,
        //待付款
        WaitForPay = 4,
        //待發貨中
        WaitForDelivery = 5
    }

    public enum orderMergeStatusEnum
    {
        refeused = -1,
        waitforapprove = 0,
        approved =1
    }

    public enum orderStepEnum
    {
        //仓库打包
        WarehousePackage = 0
    }
    public enum orderStatusEnum
    {
        
        //仓库入库
        WarehouseIn = 1,
        //退货
        ReturnGood = 2
    }
    public enum WaitForPackageStatusEnum
    {
        unConfirm =0,
        confirmed = 1

    }

    public enum OrderStepEnum
    {
        //入库
        InWareHouse = 0
    }

    public enum InWareHouseStatusEum
    {
        unConfirm = 0,
        confirmed = 1,
        returnBack = 2
    }

    public enum messageType
    {
        all = -1,
        WarehouseIn =0,//仓库已入库or 客户待打包；
        CustomerServiceConfirm = 1,
        WarehousePackge =2,
        WaitForPay =3,
        Delivered = 4,
        SystemMessage = 100
    }

    public enum CustomerOrderReqeustTypeEnum
    {
        warehouse = 0,
        waitForPackage = 1
    }

    public enum BalanceLogDirection
    {
        Positive =1,
        Reverse = 0
    }
}
