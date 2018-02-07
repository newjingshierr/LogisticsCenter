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
            return CustomerOrderDAL.GetItemListByPage(request.TenantID, userID, request.customerOrderNo, request.expressNo,
                request.expressTypeID, request.TransferNo, request.warehouseID, request.InWarehouseIimeBegin, request.InWarehouseIimeEnd, request.CustomerServiceID,
                request.PageIndex, request.PageSize, ref totalCount);

        }

        public static bool InserCustomerOrder(CustomerOrderInsertReqeust item)
        {
            logistics_customer_order customerOrder = new logistics_customer_order();
            customerOrder.TenantID = BusinessConstants.Admin.TenantID;
            customerOrder.ID = IdWorker.GetID();
            customerOrder.userid = item.userid;
            customerOrder.CustomerOrderNo = RuleManger.SetCurrentNo(BusinessConstants.Defkey.customerorder);
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
            customerOrder.WarehouseAdminRemark = item.WarehouseAdminRemark;

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
                    result = CustomerOrderDAL.Delete(BusinessConstants.Admin.TenantID, item.ID, trans) && CustomerOrderStatusDAL.Delete(BusinessConstants.Admin.TenantID, customerOrderStatus.ID, trans);
                    return result;
                });
            }

            return dbResult;
        }


        public static List<logistics_customer_order> GetCustomerOrderExpressIndex(string userName)
        {
            return CustomerOrderDAL.SelectCustomerOrderExpressIndex(userName);
        }


        public static List<logistics_customer_order> GetCustomerOrderIndex(GeIndexRequest request)
        {
            List<logistics_customer_order> userInfoList = new List<logistics_customer_order>();

            if (request.type == IndexRequestEnum.CustomerOrder)
            {
                userInfoList = CustomerOrderDAL.SelectCustomerOrderIndex(request.name);
            }
            else if (request.type == IndexRequestEnum.ExpressNo)
            {
                userInfoList = CustomerOrderDAL.SelectCustomerOrderExpressIndex(request.name);
            }

            return userInfoList;
        }

        public static List<logistics_customer_order> GetCustomerOrderItems(string request)
        {
            List<logistics_customer_order> customerOrderList = new List<logistics_customer_order>();
            logistics_customer_order customerOrder;
            String[] orderIDArrary = request.Split(',');

            for (int i = 0; i < orderIDArrary.Length; i++)
            {
                customerOrder = CustomerOrderDAL.GetCustomerOrderByID(long.Parse(orderIDArrary[i]));
                customerOrderList.Add(customerOrder);
            }

            return customerOrderList;
        }
    }

    public class CustomerOrderMergeManger
    {
        public static List<CustomerOrderMergeVM> GetListByPage(CustomerOrderMergeSelectRequest request, long userID, ref int totalCount)
        {
            return MergeCustomerOrderDAL.GetListByPage(userID,
                  request.customerOrderMergeNo,
                  request.CustomerChooseChannelID,
                  request.recipient,
                  request.country,
                  request.ChannelID,
                  request.deliverTimeBegin,
                  request.deliverTimeEnd,
                  request.AgentID,
                  request.orderMergeTimeBegin,
                  request.orderMergeTimeEnd,
                  request.expressNo,
                  request.currentStep,
                  request.currentStatus, request.PageIndex, request.PageSize, ref totalCount);

        }

        public static bool InserCustomerOrderMerge(CustomerOrderMergeInsertReqeust item)
        {
            logistics_customer_order customerOrder;
            List<logistics_customer_order> customerOrderList = new List<logistics_customer_order>();
            foreach (var c in item.customerOrderList)
            {
                customerOrder = CustomerOrderDAL.GetCustomerOrderByID(c.customerOrderID);
                customerOrderList.Add(customerOrder);
            }
            //主订单信息
            logistics_customer_order_merge customerOrderMerge = new logistics_customer_order_merge();
            customerOrderMerge.TenantID = BusinessConstants.Admin.TenantID;
            customerOrderMerge.ID = IdWorker.GetID();
            customerOrderMerge.UserID = item.userid;
            customerOrderMerge.MergeOrderNo = RuleManger.SetCurrentNo(BusinessConstants.Defkey.mergeorder);
            customerOrderMerge.CustomerMark = item.CustomerMark;
            customerOrderMerge.CustomerChooseChannelID = item.CustomerChooseChannelID;
            customerOrderMerge.InWeightTotal = customerOrderList.Sum(o => o.InWeight);
            customerOrderMerge.InVolumeTotal = customerOrderList.Sum(o => o.InVolume);
            customerOrderMerge.InPackageCountTotal = customerOrderList.Sum(o => o.InPackageCount);
            customerOrderMerge.CreatedBy = BusinessConstants.Admin.TenantID;
            customerOrderMerge.deliverTime = null;

            //订单状态
            logistics_customer_order_merge_status status = new logistics_customer_order_merge_status();
            status.currentStatus = item.currentStatus;
            status.currentStep =item.currentStep;
            status.ID = IdWorker.GetID();
            status.mergeOrderID = customerOrderMerge.ID;
            status.mergeOrderNo = customerOrderMerge.MergeOrderNo;
            status.TenantID = BusinessConstants.Admin.TenantID;
            status.CreatedBy  = BusinessConstants.Admin.TenantID;

            //合并订单和订单的关系
            logistics_customer_order_merge_relation relation;
            List<logistics_customer_order_merge_relation> relationList = new List<logistics_customer_order_merge_relation>();
            foreach (var c in item.customerOrderList)
            {
                relation = new logistics_customer_order_merge_relation();
                relation.ID = IdWorker.GetID();
                relation.TenantID = BusinessConstants.Admin.TenantID;
                relation.mergeOrderID = customerOrderMerge.ID;
                relation.orderID = c.customerOrderID;
                relation.CreatedBy = BusinessConstants.Admin.TenantID;
                relationList.Add(relation);
            }

            //产品明细
            logistics_customer_order_merge_detail detail;
            List<logistics_customer_order_merge_detail> detailList = new List<logistics_customer_order_merge_detail>();

            foreach (var p in item.productList)
            {
                detail = new logistics_customer_order_merge_detail();
                detail.TenantID = BusinessConstants.Admin.TenantID;
                detail.ID = IdWorker.GetID();
                detail.mergeOrderID = customerOrderMerge.ID;
                detail.productName = p.productName;
                detail.productNameEN = p.productNameEN;
                detail.HSCode = p.HSCode;
                detail.declareUnitPrice = p.declareUnitPrice;
                detail.count = p.count;
                detail.declareTotal = p.declareUnitPrice * p.count;
                detail.CreatedBy = BusinessConstants.Admin.TenantID;
                detailList.Add(detail);
            }

            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = MergeCustomerOrderDAL.Insert(customerOrderMerge, trans) &&
                    MergeCustomerOrderRelationDAL.InsertList(relationList, trans) && MergeCustomerOrderDetailDAL.InsertList(detailList, trans)&& MergeCustomerOrderStatusDAL.Insert(status,trans);
                    return result;
                });
            }

            return dbResult;
        }

        public static bool UpdateCustomerOrderMerge(CustomerOrderMergeUpdateReqeust item)
        {
            logistics_customer_order customerOrder;
            List<logistics_customer_order> customerOrderList = new List<logistics_customer_order>();
            foreach (var c in item.customerOrderList)
            {
                customerOrder = CustomerOrderDAL.GetCustomerOrderByID(c.customerOrderID);
                customerOrderList.Add(customerOrder);
            }
            //主订单信息
            logistics_customer_order_merge customerOrderMerge = new logistics_customer_order_merge();
            customerOrderMerge.TenantID = BusinessConstants.Admin.TenantID;
            customerOrderMerge.ID = item.ID;
            customerOrderMerge.UserID = item.userid;
            customerOrderMerge.CustomerMark = item.CustomerMark;
            customerOrderMerge.CustomerChooseChannelID = item.CustomerChooseChannelID;
            customerOrderMerge.InWeightTotal = customerOrderList.Sum(o => o.InWeight);
            customerOrderMerge.InVolumeTotal = customerOrderList.Sum(o => o.InVolume);
            customerOrderMerge.InPackageCountTotal = customerOrderList.Sum(o => o.InPackageCount);
            customerOrderMerge.ModifiedBy = BusinessConstants.Admin.TenantID;
            //产品明细
            logistics_customer_order_merge_detail detail;
            List<logistics_customer_order_merge_detail> detailList = new List<logistics_customer_order_merge_detail>();

            foreach (var p in item.productList)
            {
                detail = new logistics_customer_order_merge_detail();
                detail.TenantID = BusinessConstants.Admin.TenantID;
                detail.ID = p.ID;
                detail.mergeOrderID = customerOrderMerge.ID;
                detail.productName = p.productName;
                detail.productNameEN = p.productNameEN;
                detail.HSCode = p.HSCode;
                detail.declareUnitPrice = p.declareUnitPrice;
                detail.count = p.count;
                detail.declareTotal = p.declareUnitPrice * p.count;
                detail.ModifiedBy = BusinessConstants.Admin.TenantID;
                detailList.Add(detail);
            }

            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = MergeCustomerOrderDAL.Update(customerOrderMerge, trans) &&
                    MergeCustomerOrderRelationDAL.UpdateList(item.relationlist, trans) && MergeCustomerOrderDetailDAL.UpdateList(detailList, trans);
                    return result;
                });
            }

            return dbResult;
        }
    }
}
