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
using static Logistics_Model.BusinessConstants;

namespace Logistics_Busniess
{
    public class CustomerOrderManager
    {
        public static List<logistics_customer_order> GetItemListByPage(CustomerOrderSelectRequest request, long userID, long warehouseAdmin, ref int totalCount)
        {
            return CustomerOrderDAL.GetItemListByPage(request.TenantID, userID, warehouseAdmin, request.customerOrderNo, request.customerOrderStatus, request.expressNo,
                request.expressTypeID, request.TransferNo, request.warehouseID, request.InWarehouseIimeBegin, request.InWarehouseIimeEnd, request.CustomerServiceID,
                request.PageIndex, request.PageSize, ref totalCount);

        }

        public static bool InserCustomerOrder(CustomerOrderInsertReqeust item, long warehouseadmin)
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
            customerOrder.CreatedBy = warehouseadmin;
            customerOrder.WarehouseAdminRemark = item.WarehouseAdminRemark;

            logistics_customer_order_status customerOrderStatus = new logistics_customer_order_status();
            customerOrderStatus.TenantID = BusinessConstants.Admin.TenantID;
            customerOrderStatus.ID = IdWorker.GetID();
            customerOrderStatus.OrderID = customerOrder.ID;
            customerOrderStatus.currentStep = OrderStepEnum.InWareHouse.ToString();
            customerOrderStatus.currentStatus = item.InWareHouseStatus;
            customerOrderStatus.CreatedBy = BusinessConstants.Admin.TenantID;
            customerOrderStatus.userID = item.userid;

            List<logistics_base_attachment> attachmentList = new List<logistics_base_attachment>();
            if (item.AttachmentIDList != null)
            {
                foreach (var a in item.AttachmentIDList)
                {
                    logistics_base_attachment attachment = new logistics_base_attachment();
                    attachment.ID = long.Parse(a);
                    attachment.customerOrderID = customerOrder.ID;
                    attachment.customerOrderNo = customerOrder.CustomerOrderNo;
                    attachment.ModifiedBy = warehouseadmin;
                    attachmentList.Add(attachment);
                }
            }

            logistics_base_message message = new logistics_base_message();
            message.ID = IdWorker.GetID();
            message.TenantID = BusinessConstants.Admin.TenantID;
            message.type = (int)messageType.WarehouseIn;
            message.message = customerOrder.CustomerOrderNo;
            message.userid = item.userid;
            message.CreatedBy = warehouseadmin;

            //   return MessageDal.Insert(message);


            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = CustomerOrderDAL.Insert(customerOrder, trans) && CustomerOrderStatusDAL.Insert(customerOrderStatus, trans) && AttachmentDAL.UpdateList(attachmentList, trans) && MessageDal.Insert(message, trans);
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
            var customerOrderNo = customerOrderStatus.OrderNo;

            List<logistics_base_attachment> attachmentList = new List<logistics_base_attachment>();
            if (item.AttachmentIDList != null)
            {
                foreach (var a in item.AttachmentIDList)
                {
                    var currentAttachment = AttachmentDAL.GetAttachmentListByID(long.Parse(a));

                    logistics_base_attachment attachment = new logistics_base_attachment();
                    attachment.ID = currentAttachment.ID;
                    attachment.customerOrderID = item.ID;
                    attachment.customerOrderNo = customerOrderNo;
                    attachment.path = currentAttachment.path;
                    attachmentList.Add(attachment);
                }
            }


            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;

                    result = CustomerOrderDAL.Update(customerOrder, trans) && CustomerOrderStatusDAL.Update(customerOrderStatus, trans) && AttachmentDAL.DeleteByCustomerOrderID(item.ID, trans) && AttachmentDAL.InsertList(attachmentList, trans);
                    return result;
                });
            }

            if (dbResult == false)
            {
                throw new LogisticsException(SystemStatusEnum.CustomerOrdeUpdateFailed, $"CustomerOrdeUpdateFailed");
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
            //已确认
            if (customerOrderStatus.currentStatus == "1")
            {
                throw new LogisticsException(SystemStatusEnum.OrderIsApprovedCanNotBeDeleted, $"Order Is Approved Can Not BeDeleted");
            }

            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = CustomerOrderDAL.Delete(BusinessConstants.Admin.TenantID, item.ID, trans) && CustomerOrderStatusDAL.Delete(BusinessConstants.Admin.TenantID, customerOrderStatus.ID, trans) && AttachmentDAL.DeleteByCustomerOrderID(item.ID, trans);
                    return result;
                });
            }
            if (dbResult == false)
            {
                throw new LogisticsException(SystemStatusEnum.CustomerOrderDeleteFailed, $"Customer Order Delete Failed");
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
        public static bool RefuseCustomerOrderMerge(CustomerOrderMergeRefuseRequest request, long currentUserID)
        {
            //删除合并订单
            //删除合并订单状态
            //删除合并订单明细
            //更新关联订单的状态为 1
            var customerOrderMerge = MergeCustomerOrderDAL.GetItem(request.CustomerOrderMergeID);
            if (customerOrderMerge == null)
            {
                throw new LogisticsException(SystemStatusEnum.CustomerOrderMergeNotFound, $"Customer Order Merge Not Found");
            }
            var customerOrderMergeStatus = MergeCustomerOrderStatusDAL.GetItem(customerOrderMerge.ID);
            if (customerOrderMergeStatus == null)
            {
                throw new LogisticsException(SystemStatusEnum.CustomerOrderMergeStatusNotFound, $"Customer Order Merge Status Not Found");
            }
            var relationList = MergeCustomerOrderRelationDAL.GetItems(customerOrderMerge.ID);
            if (relationList == null)
            {
                throw new LogisticsException(SystemStatusEnum.CustomerOrderMergeRelationNotFound, $"Customer Order Merge Relation Not Found");
            }
            List<logistics_customer_order_status> customerOrderStatusList = new List<logistics_customer_order_status>();

            foreach (var o in relationList)
            {
                var customerOrderStatus = CustomerOrderStatusDAL.SelectOrderStatusByOrderID(o.orderID);
                if (customerOrderStatus == null)
                {
                    throw new LogisticsException(SystemStatusEnum.OrderStatusNotFound, $"Order Status Not Found");
                }

                customerOrderStatus.currentStatus = "1";//拒绝审批，状态更改为1；仓库打包确认
                customerOrderStatus.ModifiedBy = currentUserID;
                customerOrderStatusList.Add(customerOrderStatus);
            }

            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = MergeCustomerOrderDAL.Delete(BusinessConstants.Admin.TenantID, request.CustomerOrderMergeID, trans)
                    && MergeCustomerOrderStatusDAL.DeleteByMergeID(customerOrderMerge.ID, trans) &&
                    MergeCustomerOrderDetailDAL.DeleteByMergeCustomerOrderID(customerOrderMerge.ID, trans) &&
                     MergeCustomerOrderRelationDAL.DeleteByMergeID(customerOrderMerge.ID, trans) &&
                    CustomerOrderStatusDAL.UpdateList(customerOrderStatusList, trans);
                    return result;
                });
            }

            return dbResult;


        }

        public static int GetOrderMergeStatusSummary(GetOrderMergeStatusSummaryReqeust request, long userid)
        {
            if (request.isAdmin)
            {
                return MergeCustomerOrderDAL.GetOrderMergeStatusAdminSummary(request.currentStep);
            }
            else
            {
                return MergeCustomerOrderDAL.GetOrderMergeStatusSummary(userid, request.currentStep);
            }

        }
        public static CustomerOrderMergeItemVW GetItem(CustomerOrderMergeSelectItemRequest reqeust)
        {
            CustomerOrderMergeItemVW vm = new CustomerOrderMergeItemVW();
            vm.mergeOrder = MergeCustomerOrderDAL.GetItem(reqeust.CustomerOrderMergeID);
            vm.mergeDetailList = MergeCustomerOrderDetailDAL.GetList(reqeust.CustomerOrderMergeID);
            vm.mergeStatus = MergeCustomerOrderStatusDAL.GetItem(reqeust.CustomerOrderMergeID);
            List<logistics_customer_order> customerOrderList = new List<logistics_customer_order>();
            foreach (var o in MergeCustomerOrderRelationDAL.GetItems(reqeust.CustomerOrderMergeID))
            {
                var customerOrder = CustomerOrderDAL.GetCustomerOrderByID(o.orderID);
                customerOrderList.Add(customerOrder);
            }
            vm.customerOrderList = customerOrderList;
            return vm;
        }

        public static List<CustomerOrderMergeVM> GetListByPage(CustomerOrderMergeSelectRequest request, long userID, ref int totalCount)
        {
            if (request.currentStep == BusinessConstants.CustomerOrderMergeStep.waitforapprove)
            {
                return MergeCustomerOrderDAL.GetListForWaitForApproveByPage(userID,
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
            else
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



        }

        public static bool InserCustomerOrderMerge(CustomerOrderMergeInsertReqeust item, long currentUserID)
        {
            logistics_customer_order customerOrder;
            List<logistics_customer_order> customerOrderList = new List<logistics_customer_order>();
            foreach (var c in item.customerOrderList)
            {
                customerOrder = CustomerOrderDAL.GetCustomerOrderByID(c.customerOrderID);
                customerOrderList.Add(customerOrder);
            }

            //获取渠道名称；
            logistics_quotation_channel customerChooseChannel = ChannelDAL.GetItem(item.CustomerChooseChannelID, BusinessConstants.Admin.TenantID);
            if (customerChooseChannel == null)
            {
                throw new LogisticsException(SystemStatusEnum.ChannelNotFound, $"Channel Not Found");
            }

            //主订单信息

            logistics_customer_order_merge customerOrderMerge = new logistics_customer_order_merge();
            customerOrderMerge.TenantID = BusinessConstants.Admin.TenantID;
            customerOrderMerge.ID = IdWorker.GetID();
            customerOrderMerge.UserID = item.userid;
            customerOrderMerge.MergeOrderNo = RuleManger.SetCurrentNo(BusinessConstants.Defkey.mergeorder);
            customerOrderMerge.CustomerMark = item.CustomerMark;
            customerOrderMerge.CustomerChooseChannelID = item.CustomerChooseChannelID;
            customerOrderMerge.CustomerChooseChannelName = customerChooseChannel.Name;
            customerOrderMerge.recipient = item.recipient;
            customerOrderMerge.country = item.country;
            customerOrderMerge.address = item.address;
            customerOrderMerge.city = item.city;
            customerOrderMerge.address = item.city;
            customerOrderMerge.code = item.code;
            customerOrderMerge.tel = item.tel;
            customerOrderMerge.company = item.company;
            customerOrderMerge.taxNo = item.taxNo;
            customerOrderMerge.InWeightTotal = customerOrderList.Sum(o => o.InWeight);
            customerOrderMerge.InVolumeTotal = customerOrderList.Sum(o => o.InVolume);
            customerOrderMerge.InPackageCountTotal = customerOrderList.Sum(o => o.InPackageCount);
            customerOrderMerge.CreatedBy = currentUserID;
            customerOrderMerge.deliverTime = null;

            //合并订单状态
            logistics_customer_order_merge_status status = new logistics_customer_order_merge_status();
            status.currentStatus = item.currentStatus;
            status.currentStep = item.currentStep;
            status.ID = IdWorker.GetID();
            status.mergeOrderID = customerOrderMerge.ID;
            status.mergeOrderNo = customerOrderMerge.MergeOrderNo;
            status.TenantID = BusinessConstants.Admin.TenantID;
            status.CreatedBy = BusinessConstants.Admin.TenantID;

            //订单的状态更新（更新为3）
            List<logistics_customer_order_status> customerOrderStatusList = new List<logistics_customer_order_status>();
            foreach (var c in item.customerOrderList)
            {
                var customerOrderStatus = CustomerOrderStatusDAL.SelectOrderStatusByOrderID(c.customerOrderID);
                if (customerOrderStatus == null)
                {
                    throw new LogisticsException(SystemStatusEnum.OrderStatusNotFound, $"Order Status Not Found");
                }

                customerOrderStatus.currentStatus = "3";//合并打包
                customerOrderStatus.ModifiedBy = currentUserID;
                customerOrderStatusList.Add(customerOrderStatus);
            }

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
                detail.productCount = p.productCount;
                detail.declareTotal = p.declareUnitPrice * p.productCount;
                detail.CreatedBy = BusinessConstants.Admin.TenantID;
                detailList.Add(detail);
            }

            //消息
            logistics_base_message message = new logistics_base_message();
            message.ID = IdWorker.GetID();
            message.TenantID = BusinessConstants.Admin.TenantID;
            message.type = (int)messageType.CustomerServiceConfirm;
            message.message = customerOrderMerge.MergeOrderNo;
            message.userid = item.userid;
            message.CreatedBy = currentUserID;

            //  return MessageDal.Insert(message);

            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = MergeCustomerOrderDAL.Insert(customerOrderMerge, trans) &&
                    MergeCustomerOrderRelationDAL.InsertList(relationList, trans) &&
                    MergeCustomerOrderDetailDAL.InsertList(detailList, trans) &&
                    MergeCustomerOrderStatusDAL.Insert(status, trans) &&
                    CustomerOrderStatusDAL.UpdateList(customerOrderStatusList, trans) && MessageDal.Insert(message, trans);
                    return result;
                });
            }

            return dbResult;
        }

        public static bool UpdateCustomerOrderMerge(CustomerOrderMergeUpdateReqeust item, long currentUserID)
        {

            //主订单信息
            var customerOrderMergeModel = MergeCustomerOrderDAL.GetItem(item.ID);
            if (customerOrderMergeModel == null)
            {
                throw new LogisticsException(SystemStatusEnum.CustomerOrderMergeNotFound, $"Customer Order Merge Not Found");
            }

            logistics_customer_order_merge customerOrderMerge = new logistics_customer_order_merge();
            customerOrderMerge.ID = item.ID;
            customerOrderMerge.ModifiedBy = currentUserID;

            if (item.currentStep == CustomerOrderMergeStep.CustomerServiceConfirm && item.currentStatus == CustomerOrderMergeStatus.confirmed)
            {
                customerOrderMerge.recipient = item.recipient;
                customerOrderMerge.country = item.country;
                customerOrderMerge.address = item.address;
                customerOrderMerge.city = item.city;
                customerOrderMerge.code = item.code;
                customerOrderMerge.tel = item.tel;
                customerOrderMerge.company = item.company;
                customerOrderMerge.taxNo = item.taxNo;
                customerOrderMerge.CustomerChooseChannelID = item.CustomerChooseChannelID;
                customerOrderMerge.serviceFee = item.serviceFee;
                customerOrderMerge.remoteFee = item.remoteFee;
                customerOrderMerge.magneticinspectionFee = item.magneticinspectionFee;
                customerOrderMerge.customerServiceMark = item.customerServiceMark;
                customerOrderMerge.packageMark = item.packageMark;     
            }

            if (item.currentStep == CustomerOrderMergeStep.WarehousePackege && item.currentStatus == CustomerOrderMergeStatus.confirmed)
            {
                customerOrderMerge.packageWeight = item.packageWeight;
                customerOrderMerge.packageVolume = item.packageVolume;
                customerOrderMerge.packageLength = item.packageLength;
                customerOrderMerge.packageHeight = item.packageHeight;
                customerOrderMerge.packageWidth = item.packageWidth;
                customerOrderMerge.settlementWeight = item.settlementWeight;
                GetQuotationPriceByCountryRequest priceRequest = new GetQuotationPriceByCountryRequest();
                priceRequest.country = customerOrderMergeModel.country;
                priceRequest.weight = item.packageWeight;
                priceRequest.length = item.packageLength;
                priceRequest.width = item.packageWidth;
                priceRequest.height = item.packageHeight;

                customerOrderMerge.freightFee = QuotationManager.GetPriceByChannelID(priceRequest, customerOrderMergeModel.CustomerChooseChannelID);
                customerOrderMerge.serviceFee = Convert.ToDecimal(Convert.ToDouble(customerOrderMerge.freightFee)*0.05);
                customerOrderMerge.tax =Convert.ToDecimal(Convert.ToDouble( customerOrderMerge.freightFee + customerOrderMergeModel.serviceFee + customerOrderMergeModel.remoteFee + customerOrderMergeModel.magneticinspectionFee)*0.03);
                customerOrderMerge.totalFee = customerOrderMerge.freightFee + customerOrderMerge.serviceFee + customerOrderMerge.tax + customerOrderMergeModel.remoteFee + customerOrderMergeModel.magneticinspectionFee;
            }
            if (item.currentStep == CustomerOrderMergeStep.WaitForDelivery && item.currentStatus == CustomerOrderMergeStatus.confirmed)
            {
                customerOrderMerge.ChannelID = item.ChannelID;
                customerOrderMerge.ChannelName = item.ChannelName;
                customerOrderMerge.channelNo = item.channelNo;
                customerOrderMerge.deliverTime = item.deliverTime;
                customerOrderMerge.AgentID = item.AgentID;
                customerOrderMerge.AgentName = item.AgentName;
            }

            //合并订单状态
            var mergeOrderStatus = MergeCustomerOrderStatusDAL.GetItem(item.ID);
            if (mergeOrderStatus == null)
            {
                throw new LogisticsException(SystemStatusEnum.CustomerOrderMergeStatusNotFound, $"Customer Order Merge Status Not Found");
            }
        
            mergeOrderStatus.ModifiedBy = currentUserID;

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
                detail.productCount = p.productCount;
                detail.declareTotal = p.declareUnitPrice * p.productCount;
                detail.ModifiedBy = currentUserID;
                detailList.Add(detail);
            }

            var type = -1;
            if (item.currentStep == CustomerOrderMergeStep.CustomerServiceConfirm)
            {
                type = (int)messageType.CustomerServiceConfirm;
            }
            else if (item.currentStep == CustomerOrderMergeStep.WarehousePackege)
            {
                type = (int)messageType.WarehousePackge;
            }
            else if (item.currentStep == CustomerOrderMergeStep.WaitForPay)
            {
                type = (int)messageType.WaitForPay;
            }
            else if (item.currentStep == CustomerOrderMergeStep.WaitForDelivery )
            {
                type = (int)messageType.Delivered;
            }



            logistics_base_message message = new logistics_base_message();
            message.ID = IdWorker.GetID();
            message.TenantID = BusinessConstants.Admin.TenantID;
            message.type = (int)messageType.WarehouseIn;
            message.message = customerOrderMergeModel.MergeOrderNo;
            message.userid = customerOrderMergeModel.UserID;
            message.CreatedBy = currentUserID;

            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    var result = true;
                    result = MergeCustomerOrderDAL.Update(customerOrderMerge, trans) && MergeCustomerOrderDetailDAL.UpdateList(detailList, trans);
                    // 当前阶段是仓库打包，并且状态是已确认,产生客户应收订单
                    if (item.currentStep == CustomerOrderMergeStep.CustomerServiceConfirm && item.currentStatus == CustomerOrderMergeStatus.confirmed)
                    {
                        mergeOrderStatus.currentStep = CustomerOrderMergeStep.WarehousePackege;
                        mergeOrderStatus.currentStatus = CustomerOrderMergeStatus.waitapprove;
                    }
                   else if (item.currentStep == CustomerOrderMergeStep.WarehousePackege && item.currentStatus == CustomerOrderMergeStatus.confirmed)
                    {
                        logistics_customer_order_merge_balance balance = new logistics_customer_order_merge_balance();
                        balance.TenantID = BusinessConstants.Admin.TenantID;
                        balance.BalanceID = IdWorker.GetID();
                        balance.CustomerOrderMergeID = item.ID;
                        balance.UserID = currentUserID;
                   
                        balance.Amount = customerOrderMerge.totalFee;
                        balance.RemainAmount = customerOrderMerge.totalFee;
                        balance.type = CustomerOrderMergeBalanceType.customerReceivable;
                        balance.CreatedBy = currentUserID;
                        balance.ModifiedBy = currentUserID;
                        //logistics_customer_order_merge_balance_log balanceLog = new logistics_customer_order_merge_balance_log();
                        //balanceLog.TransationID = BusinessConstants.Admin.TenantID;
                        //balanceLog.ID = IdWorker.GetID();
                        //balanceLog.BalanceID = balance.BalanceID;
                        //balanceLog.CustomerOrderMergeID = item.ID;
                        //balanceLog.DataSource = BalanceLogDataSource.CustomerPayable;
                        mergeOrderStatus.currentStep = CustomerOrderMergeStep.WaitForPay;
                        mergeOrderStatus.currentStatus = CustomerOrderMergeStatus.waitapprove;



                        result = result && CustomerOrderMergeBalanceDAL.Insert(balance, trans);
                    }
                    else if (item.currentStep == CustomerOrderMergeStep.WaitForPay && item.currentStatus == CustomerOrderMergeStatus.confirmed)
                    {
                        //当前阶段是客户付款阶段，并且状态是已确认;产生交易记录 ,产生交易Log,  更新balance,  冲正客户应付订单

                        mergeOrderStatus.currentStep = CustomerOrderMergeStep.WaitForDelivery;
                        mergeOrderStatus.currentStatus = CustomerOrderMergeStatus.waitapprove;


                        var transaction = new logistics_customer_order_merge_transaction();
                        transaction.TenantID = BusinessConstants.Admin.TenantID;
                        transaction.TransationID = IdWorker.GetID();
                        transaction.CustomerOrderMergeID = item.ID;
                        transaction.Amount = customerOrderMerge.totalFee;
                        transaction.DataSource = TransactionDataSource.customerConsume;
                        transaction.Comment = TransactionComment.customerConsume;
                        transaction.CreatedBy = currentUserID;

                        var transactionLog = new logistics_customer_order_merge_transaction_log();
                        transactionLog.TenantID = BusinessConstants.Admin.TenantID;
                        transactionLog.ID = IdWorker.GetID();
                        transactionLog.TransationID = transaction.TransationID;
                        transactionLog.CustomerOrderMergeID = item.ID;
                        transactionLog.Amount = customerOrderMerge.totalFee;
                        transactionLog.DataSource = TransactionDataSource.customerConsume;
                        transactionLog.Comment = TransactionComment.customerConsume;
                        transactionLog.CreatedBy = currentUserID;

                        var model = CustomerOrderMergeBalanceDAL.GetMergeBalanceModelByOrderMergeID(item.ID);
                        if (model == null)
                        {
                            throw new LogisticsException(SystemStatusEnum.CustomerOrderMergeBalanceNotFound, $"Customer OrderMerge Balance Not Found");
                        }
                        model.RemainAmount = 0;
                        model.ModifiedBy = currentUserID;


                        logistics_customer_order_merge_balance_log balanceLog = new logistics_customer_order_merge_balance_log();
                        balanceLog.TransationID = BusinessConstants.Admin.TenantID;
                        balanceLog.ID = IdWorker.GetID();
                        balanceLog.BalanceID = model.BalanceID;
                        balanceLog.CustomerOrderMergeID = item.ID;
                        balanceLog.DataSource = BalanceLogDataSource.CustomerPayableWriteOff;
                        balanceLog.TransationID = transaction.TransationID;
                        balanceLog.Type = BalanceLogType.consume;
                        balanceLog.Direction = Convert.ToBoolean(BalanceLogDirection.Reverse);
                        balanceLog.Amount = customerOrderMerge.totalFee;
                        balanceLog.Orignal = customerOrderMerge.totalFee;
                        balanceLog.AfterBalance = 0;
                        balanceLog.Comment = TransactionComment.customerConsume;
                        balanceLog.BalanceDate = System.DateTime.Now;
                        balanceLog.CreatedBy = currentUserID;

                        result = result && CustomerOrderMergeTransactionDAL.Insert(transaction, trans) && CustomerOrderMergeTransactionLogDAL.Insert(transactionLog,trans) &&
                           CustomerOrderMergeBalanceDAL.Update(model, trans) && CustomerOrderMergeBalanceLogDAL.Insert(balanceLog,trans);

                    }
                    else if (item.currentStep == CustomerOrderMergeStep.WaitForDelivery && item.currentStatus == CustomerOrderMergeStatus.confirmed)
                    {
                        //当前阶段是仓库发货阶段，并且状态是已确认，产生代理商应付定单
                        logistics_customer_order_merge_balance balance = new logistics_customer_order_merge_balance();
                        balance.TenantID = BusinessConstants.Admin.TenantID;
                        balance.BalanceID = IdWorker.GetID();
                        balance.CustomerOrderMergeID = item.ID;
                        balance.UserID = currentUserID;
                        balance.UserID = item.AgentID;
                        balance.Amount = customerOrderMerge.totalFee;
                        balance.RemainAmount = customerOrderMerge.totalFee;
                        balance.type = CustomerOrderMergeBalanceType.agentPayable;
                        balance.CreatedBy = currentUserID;
                        balance.ModifiedBy = currentUserID;
                        result = result && CustomerOrderMergeBalanceDAL.Insert(balance, trans);
                    }
                    //状态更新 删除明细，更新明细；
                    result = result && MergeCustomerOrderStatusDAL.Update(mergeOrderStatus, trans) &&
                    MergeCustomerOrderDetailDAL.DeleteByMergeCustomerOrderID(item.ID, trans) &&
                    MergeCustomerOrderDetailDAL.InsertList(detailList, trans)&& MessageDal.Insert(message, trans);

                    return result;
                });
            }

            return dbResult;
        }

        //  public static 
    }
}
