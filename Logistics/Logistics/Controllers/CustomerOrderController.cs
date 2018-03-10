using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Logistics.Common;
using Logistics_Model;
using Logistics_Busniess;
using Akmii;
using System.Collections.Generic;
using System.Data;


namespace Logistics.Controllers
{
    /*

         */
    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrder")]
    public class CustomerOrderController : BaseAuthController
    {

        [Route("Export")]
        public void Export()
        {
            var request = new CustomerOrderSelectRequest();
            request.step = "0";
            request.PageIndex = 1;
            request.PageSize = 100000;
            var userID = 0L;
            int totalCount = 0;
            var warehouseAdmin = base.contextInfo.userInfo.Userid;
            var result = CustomerOrderManager.GetItemListByPage(request, userID, warehouseAdmin, ref totalCount);

            //DataTable dt = Logistics.Core.Common.ToDataTable(result);
            DataTable dt = new DataTable();
            dt.Columns.Add("客户订单号");
            dt.Columns.Add("会员编号");
            dt.Columns.Add("快递方式");
            dt.Columns.Add("快递单号");
            dt.Columns.Add("交接单号");
            dt.Columns.Add("客服");
            dt.Columns.Add("仓库");
            dt.Columns.Add("初始长");
            dt.Columns.Add("初始宽");
            dt.Columns.Add("初始高");
            dt.Columns.Add("初始重量(kg)");
            dt.Columns.Add("状态");
            dt.Columns.Add("入库时间");
            dt.Columns.Add("创建人");
            foreach (var o in result)
            {
                var currentStatusStr = "";
                DataRow dr = dt.NewRow();
                dr["客户订单号"] = o.CustomerOrderNo;
                dr["会员编号"] = o.MemeberCode;
                dr["快递方式"] = o.expressTypeName;
                dr["快递单号"] = o.expressNo;
                dr["交接单号"] = o.TransferNo;
                dr["客服"] = o.CustomerServiceName;
                dr["仓库"] = o.WareHouseName;
                dr["初始长"] = o.InLength.ToString();
                dr["初始宽"] = o.InWidth.ToString();
                dr["初始高"] = o.InHeight.ToString();
                dr["初始重量(kg)"] = o.InWeight;
                if (o.currentStatus == "0")
                {
                    currentStatusStr = "未确认";
                }
                else if (o.currentStatus == "1")
                {
                    currentStatusStr = "已入库";
                }
                else if (o.currentStatus == "2")
                {
                    currentStatusStr = "仓库退货";
                }
                dr["状态"] = o.currentStatus = currentStatusStr;
                dr["入库时间"] = o.InWareHouseTime;
                dr["创建人"] = o.CreatedByName;
                dt.Rows.Add(dr);
            }

            Logistics.Core.Common.CreateExcel(dt, "application/ms-excel", "CustomerOrder_" + DateTime.Now.ToString("yyyy-MM-dd-HH-MM-ss"));
        }

        //仓库入库 阶段：0  状态：0 未确认 1 已确认 2 仓库退货  
        //統計待打包個數 阶段 0 状态确认 1
        //客服确认阶段： 1  状态：0 未确认 1 已确认 2客服退货 3 客服拒绝
        //仓库打包阶段：2   状态：0 未确认 1 已确认
        //客服付款阶段：3   状态：0 未确认 1已付款 2付款失败
        //已发货阶段： 4    状态： 0 未发货 1已发货 

        //
        //統計待付款訂單數 阶段

        //統計已發貨訂單數
        [HttpPost]
        [Route("Status")]
        public ResponseMessage<OrderStatusSummaryView> SelectOrderStatusByUserID()
        {
            OrderStatusRequest request = new OrderStatusRequest();
            request.userID = base.contextInfo.userInfo.Userid;

            if (request == null)
            {
                return GetErrorResult<OrderStatusSummaryView>(SystemStatusEnum.InvalidRequest);
            }

            var result = new OrderStatusSummaryView();
            try
            {
                result = OrderStatus.SelectOrderStatusByUserID(request);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }

        [Route("WarehouseInStatus")]
        public ResponseMessage<WarehouseCustomerOrderStatusSummaryView> SelectOrderStatusByWarehouseAdmin()
        {

            var result = new WarehouseCustomerOrderStatusSummaryView();
            try
            {
                result = OrderStatus.logistics_customer_order_select_by_warehouseAdmin_summary(base.contextInfo.userInfo.Userid);

                return GetResult(result);
            }

            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }

        [Route("items/page")]
        public ResponseMessage<List<logistics_customer_order>> GetItemListByPage([FromUri]CustomerOrderSelectRequest request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderController));
            int totalCount = 0;
            var result = new List<logistics_customer_order>();
            var userID = 0L;
            var warehouseAdmin = 0L;
            if (request.step == "1")
            {
                //待打包根据当前会员来查询
                //待打包customerOrderStatus 传值为1
                userID = contextInfo.userInfo.Userid;
                // request.customerOrderStatus = 1;//只显示确认的订单
            }
            else if (request.step == "0")
            {
                /*查询仓库管理员，如果没有传值的情况是当前用户的id*/
                if (request.warehouseAdmin != 0)
                {
                    warehouseAdmin = request.warehouseAdmin;
                }
                else
                {
                    warehouseAdmin = contextInfo.userInfo.Userid;
                }
                //会员查询
                if (request.MemberID != 0)
                {
                    userID = request.MemberID;
                }
            }

            try
            {
                result = CustomerOrderManager.GetItemListByPage(request, userID, warehouseAdmin, ref totalCount);

                return GetResult(result, totalCount);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }


        /// <summary>
        /// 新增customerOrder
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Item/Insert")]
        public ResponseMessage<bool> InserCustomerOrder(CustomerOrderInsertReqeust request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderMergeController));

            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }


            var result = false;
            try
            {
                result = CustomerOrderManager.InserCustomerOrder(request, base.contextInfo.userInfo.Userid);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }

        /// <summary>
        ///修改customerOrder
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Item/update")]
        public ResponseMessage<bool> UpdateCustomerOrder(CustomerOrderUpdateReqeust request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderMergeController));

            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }


            var result = false;
            try
            {
                result = CustomerOrderManager.UpdateCustomerOrder(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }


        /// <summary>
        ///删除customerOrder，只有草稿状态的订单才可以删除；
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Item/delete")]
        public ResponseMessage<bool> DeleteCustomerOrder(CustomerOrderDeleteRequest request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderMergeController));

            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }


            var result = false;
            try
            {
                result = CustomerOrderManager.DeleteCustomerOrderByID(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }

        /// <summary>
        ///  索引订单号，订单号中的快递单号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("order/Index")]
        public ResponseMessage<List<logistics_customer_order>> GetCustomerOrderIndex([FromUri] GeIndexRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<List<logistics_customer_order>>(SystemStatusEnum.InvalidRequest);
            }
            var result = new List<logistics_customer_order>();

            try
            {
                result = CustomerOrderManager.GetCustomerOrderIndex(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }
        }

        /// <summary>
        ///  索引订单号，订单号中的快递单号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("order/items")]
        public ResponseMessage<List<logistics_customer_order>> GetCustomerOrderItems([FromUri]string request)
        {
            if (request == null)
            {
                return GetErrorResult<List<logistics_customer_order>>(SystemStatusEnum.InvalidRequest);
            }
            var result = new List<logistics_customer_order>();

            try
            {
                result = CustomerOrderManager.GetCustomerOrderItems(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }
        }


    }


    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrderMerge")]
    public class CustomerOrderMergeController : BaseAuthController
    {
        [HttpPut]
        [Route("Item/Refuse")]
        public ResponseMessage<bool> RefuseCustomerOrderMerge(CustomerOrderMergeRefuseRequest request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderMergeController));

            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }


            var result = false;
            try
            {
                result = CustomerOrderMergeManger.RefuseCustomerOrderMerge(request, contextInfo.userInfo.Userid);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }
        }
        [HttpGet]
        [Route("Item")]
        public ResponseMessage<CustomerOrderMergeItemVW> GetMergeItem([FromUri]CustomerOrderMergeSelectItemRequest request)
        {

            var result = new CustomerOrderMergeItemVW();
            try
            {
                result = CustomerOrderMergeManger.GetItem(request);

                return GetResult(result);
            }

            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }
        }
        /// <summary>
        /// 新增 merge customer Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Item/Insert")]
        public ResponseMessage<bool> InserCustomerOrderMerge(CustomerOrderMergeInsertReqeust request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderMergeController));

            if (request == null || request.customerOrderList == null || request.productList == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }

            var result = false;
            try
            {
                result = CustomerOrderMergeManger.InserCustomerOrderMerge(request, contextInfo.userInfo.Userid);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }


        /// <summary>
        /// 新增 merge customer Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Item/Update")]
        public ResponseMessage<bool> UpdateCustomerOrderMerge(CustomerOrderMergeUpdateReqeust request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderMergeController));

            if (request == null || request.productList == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }

            var result = false;
            try
            {
                result = CustomerOrderMergeManger.UpdateCustomerOrderMerge(request, base.contextInfo.userInfo.Userid);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }

        }

        /// <summary>
        /// 合并订单查询，用户审批页面的查询；客户确认页面，仓库合并打包页面查询，客服付款页面，仓库打包页面查询公用；单个订单查询；
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("items/page")]
        public ResponseMessage<List<CustomerOrderMergeVM>> GetItemListByPage([FromUri]CustomerOrderMergeSelectRequest request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderController));
            int totalCount = 0;
            var result = new List<CustomerOrderMergeVM>();
            var userID = 0L;
            // tpe 为0 的情况用户查询

            if (!request.isAdmin) userID = this.contextInfo.userInfo.Userid;

            try
            {
                result = CustomerOrderMergeManger.GetListByPage(request, userID, ref totalCount);

                return GetResult(result, totalCount);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }

        [Route("WaitForApproveStatus")]
        public ResponseMessage<WarehouseCustomerOrderStatusSummaryView> SelectOrderStatusByWarehouseAdmin()
        {

            var result = new WarehouseCustomerOrderStatusSummaryView();
            try
            {
                result = OrderStatus.logistics_customer_order_select_by_warehouseAdmin_summary(base.contextInfo.userInfo.Userid);

                return GetResult(result);
            }

            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }

        [HttpGet]
        [Route("status/summary")]
        public ResponseMessage<int> GetOrderMergeStatusSummary([FromUri]GetOrderMergeStatusSummaryReqeust request)
        {

            var result = 0;
            try
            {
                result = CustomerOrderMergeManger.GetOrderMergeStatusSummary(request, base.contextInfo.userInfo.Userid);

                return GetResult(result);
            }

            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }
    }


    //仓库打包 状态下拉框
    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrderStatus")]
    public class CustomerOrderStatusController : BaseAuthController
    {

        [HttpGet]
        [Route("items")]
        public ResponseMessage<List<logistics_base_status>> GetItems()
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderStatusController));

            var result = new List<logistics_base_status>();
            var warehouseIn = new logistics_base_status();
            warehouseIn.ID = orderStatusEnum.WarehouseIn.ToString();
            warehouseIn.value = "已入库";
            result.Add(warehouseIn);
            var returnGood = new logistics_base_status();
            returnGood.ID = orderStatusEnum.ReturnGood.ToString();
            returnGood.value = "已退货";
            result.Add(returnGood);

            try
            {
                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }
    }

    /// <summary>
    /// 客服: 待审核，已审核，已拒绝
    /// 仓库打包：待审核，已审核
    /// 仓库发货：待审核，已审核
    /// </summary>
    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrderMergeStatus")]
    public class CustomerOrderMergeStatusController : BaseAuthController
    {
        [HttpGet]
        [Route("orderconfirm")]
        public ResponseMessage<List<logistics_base_status>> GetOrderconfirmStatus()
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderStatusController));
            var result = new List<logistics_base_status>();
            var approved = new logistics_base_status();
            approved.ID = orderMergeStatusEnum.approved.ToString();
            approved.value = "已审核";

            result.Add(approved);
            var refeused = new logistics_base_status();
            refeused.ID = orderMergeStatusEnum.refeused.ToString();
            refeused.value = "已拒绝";

            result.Add(refeused);

            var waitforapprove = new logistics_base_status();
            waitforapprove.ID = orderMergeStatusEnum.waitforapprove.ToString();
            waitforapprove.value = "待审核";
            result.Add(waitforapprove);

            try
            {
                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }

        [HttpGet]
        [Route("warehousepackage")]
        public ResponseMessage<List<logistics_base_status>> GetWarehousepackageStatus()
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderStatusController));
            var result = new List<logistics_base_status>();
            var approved = new logistics_base_status();
            approved.ID = orderMergeStatusEnum.approved.ToString();
            approved.value = "已审核";

            result.Add(approved);
            var refeused = new logistics_base_status();
            refeused.ID = orderMergeStatusEnum.refeused.ToString();
            refeused.value = "已拒绝";

            result.Add(refeused);

            var waitforapprove = new logistics_base_status();
            waitforapprove.ID = orderMergeStatusEnum.waitforapprove.ToString();
            waitforapprove.value = "待审核";
            result.Add(waitforapprove);

            try
            {
                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }


    }


    [RoutePrefix(ApiConstants.PrefixApi + "OrderMergeStep")]
    public class CustomerOrderMergeStepController : BaseAuthController
    {
        [HttpGet]
        [Route("memeberwaitforapprove")]
        public ResponseMessage<List<logistics_base_step>> GetOrderconfirmStatus()
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderMergeStepController));
            var result = new List<logistics_base_step>();
            var CustomerServiceConfirm = new logistics_base_step();
            CustomerServiceConfirm.ID = "2";
            CustomerServiceConfirm.value = "客服确认";
            result.Add(CustomerServiceConfirm);

            var WaitForPackage = new logistics_base_step();
            WaitForPackage.ID = "3";
            WaitForPackage.value = "仓库打包";
            result.Add(WaitForPackage);

            try
            {
                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }

    }




}
