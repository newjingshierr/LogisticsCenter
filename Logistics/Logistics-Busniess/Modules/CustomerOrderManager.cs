using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;
using Logistics.Core;
using Akmii.Cache.Client;
using Logistics_DAL;
using Logistics.Common;

namespace Logistics_Busniess
{
    public class CustomerOrderManager
    {
        public static List<logistics_customer_order> GetItemListByPage(CustomerOrderSelectRequest request, long userID, ref int totalCount)
        {
            return CustomerOrderDAL.GetItemListByPage(request.TenantID, userID, request.PageIndex, request.PageSize, ref totalCount);

        }

        public static bool InserCustomerOrder(CustomerOrderInsertReqeust item)
        {
            logistics_customer_order customerOrder = new logistics_customer_order();
            customerOrder.TenantID = BusinessConstants.Admin.TenantID;
            customerOrder.ID = IdWorker.GetID();
            customerOrder.userid = item.userid;
            customerOrder.CustomerOrderNo=  RuleManger.SetCurrentNo(BusinessConstants.Defkey.customerorder);
            customerOrder.expressNo = item.expressNo;
            customerOrder.expressTypeID = item.expressTypeID;
            customerOrder.expressTypeName = item.expressTypeName;
            customerOrder.TransferNo = item.TransferNo;
            customerOrder.InPackageCount = item.InPackageCount;
            customerOrder.InWeight = item.InWeight;
            customerOrder.InVolume = item.InVolume;
            customerOrder.InLength = item.InLength;
            customerOrder.InWidth = item.InWidth;
            customerOrder.InHeight = item.InHeight;
            customerOrder.WareHouseID = item.WareHouseID;
            customerOrder.CustomerServiceID = item.CustomerServiceID;
            customerOrder.CreatedBy = BusinessConstants.Admin.TenantID;

            logistics_customer_order_status customerOrderStatus = new logistics_customer_order_status();
            customerOrderStatus.TenantID = BusinessConstants.Admin.TenantID;
            customerOrderStatus.ID = IdWorker.GetID();
            customerOrderStatus.OrderID = customerOrder.ID;
            customerOrderStatus.currentStep = OrderStepEnum.InWareHouse.ToString();
            customerOrderStatus.currentStatus = item.InWareHouseStatus;
            customerOrderStatus.CreatedBy = BusinessConstants.Admin.TenantID;
            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = CustomerOrderDAL.Insert(customerOrder, trans) && CustomerOrderStatusDAL.Insert(customerOrderStatus, trans);
                    return result;
                });
            }

            return dbResult;
        }
        public static bool UpdateCustomerOrder(CustomerOrderUpdateReqeust item)
        {
            logistics_customer_order customerOrder = new logistics_customer_order();
            customerOrder.TenantID = BusinessConstants.Admin.TenantID;
            customerOrder.ID = item.ID;
            customerOrder.userid = item.userid;
            customerOrder.expressNo = item.expressNo;
            customerOrder.expressTypeID = item.expressTypeID;
            customerOrder.expressTypeName = item.expressTypeName;
            customerOrder.TransferNo = item.TransferNo;
            customerOrder.InPackageCount = item.InPackageCount;
            customerOrder.InWeight = item.InWeight;
            customerOrder.InVolume = item.InVolume;
            customerOrder.InLength = item.InLength;
            customerOrder.InWidth = item.InWidth;
            customerOrder.InHeight = item.InHeight;
            customerOrder.WareHouseID = item.WareHouseID;
            customerOrder.CustomerServiceID = item.CustomerServiceID;
            customerOrder.ModifiedBy = BusinessConstants.Admin.TenantID;



            var customerOrderStatus = CustomerOrderStatusDAL.SelectOrderStatusByOrderID(item.ID);
            if (customerOrderStatus == null)
            {
                throw new LogisticsException(SystemStatusEnum.OrderStatusNotFound, $"Order Status Not Found");
            }
            customerOrderStatus.currentStatus = item.InWareHouseStatus;
            customerOrderStatus.ModifiedBy = BusinessConstants.Admin.TenantID;

            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = CustomerOrderDAL.Update(customerOrder, trans) && CustomerOrderStatusDAL.Update(customerOrderStatus, trans);
                    return result;
                });
            }

            return dbResult;
        }



        public static bool DeleteCustomerOrderByID(CustomerOrderDeleteRequest item)
        {
            logistics_customer_order customerOrder = new logistics_customer_order();
            customerOrder.ModifiedBy = BusinessConstants.Admin.TenantID;

            var customerOrderStatus = CustomerOrderStatusDAL.SelectOrderStatusByOrderID(item.ID);
            if (customerOrderStatus == null)
            {
                throw new LogisticsException(SystemStatusEnum.OrderStatusNotFound, $"Order Status Not Found");
            }


            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = CustomerOrderDAL.Delete(BusinessConstants.Admin.TenantID,item.ID, trans) && CustomerOrderStatusDAL.Delete(BusinessConstants.Admin.TenantID, customerOrderStatus.ID, trans);
                    return result;
                });
            }

            return dbResult;
        }



    }
}
