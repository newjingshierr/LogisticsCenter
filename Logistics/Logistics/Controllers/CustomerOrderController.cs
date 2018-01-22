using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Logistics.Common;
using Logistics_Model;
using Logistics_Busniess;
using Akmii;
using System.Collections.Generic;

namespace Logistics.Controllers
{
    /*

         */
    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrder")]
    public class CustomerOrderController : BaseAuthController
    {
        //仓库入库 阶段：0  状态：0 未确认 1 已确认 2 仓库退货  
        //統計待打包個數 阶段 0 状态确认 1
        //客服确认阶段： 1  状态：0 未确认 1 已确认 2客服退货 3 客服拒绝
        //仓库打包阶段：2   状态：0 未确认 1 已确认
        //客服付款阶段：3   状态：0 未确认 1已付款 2付款失败
        //已发货阶段： 4    状态： 0 未发货 1已发货 

        //
        //統計待付款訂單數 阶段

        //統計已發貨訂單數
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

        [Route("items/page")]
        public ResponseMessage<List<logistics_customer_order>> GetItemListByPage([FromUri]CustomerOrderSelectRequest request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(CustomerOrderMergeController));
            int totalCount = 0;
            var result = new List<logistics_customer_order>();
            var userID = 0L;
            if (request.type == (int)CustomerOrderReqeustTypeEnum.waitForPackage)
            {
                userID = contextInfo.userInfo.Userid;
            }

            try
            {
                result = CustomerOrderManager.GetItemListByPage(request, userID, ref totalCount);

                return GetResult(result, totalCount);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }
        }

    }


    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrderMerge")]
    public class CustomerOrderMergeController : BaseAuthController
    {

    }


    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrder")]
    public class CustomerOrderStatusController : BaseAuthController
    {
       


    }



}
