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
    [RoutePrefix(ApiConstants.PrefixApi + "Message")]
    public class MessageController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));

        /// <summary>
        /// 獲取用戶的消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("latest")]
        public ResponseMessage<List<logistics_base_message>> GetItemListByLatest()
        {

            var result = new List<logistics_base_message>();
            try
            {
                result = MessageManager.GetMessageListByLatest(contextInfo.userInfo.Userid);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }

        }

        /// <summary>
        /// 獲取用戶的消息分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("items/page")]
        public ResponseMessage<List<logistics_base_message>> GetItemListByPage(GetItemListByPageRequest request)
        {
            var result = new List<logistics_base_message>();
            int totalCount = 0;
            try
            {
                result = MessageManager.GetMessageListByPage(request, base.contextInfo.userInfo.Userid, ref totalCount);

                return GetResult(result, totalCount);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }

        }

        [HttpPost]
        [Route("item")]
        public ResponseMessage<string> Insert(MessageInsertRequest request)
        {

            var result = false;
            try
            {
                result = MessageManager.InsertMessage(request);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);
            }

        }


    }

    [RoutePrefix(ApiConstants.PrefixApi + "ExpressType")]
    public class ExpressController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));

        [HttpGet]
        [Route("all")]
        public ResponseMessage<List<logistics_base_express_type>> GetAll()
        {

            var result = new List<logistics_base_express_type>();
            try
            {
                result = ExpressTypeManger.GetAll();

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }
        }

        [HttpGet]
        [Route("index")]
        public ResponseMessage<List<logistics_base_express_type>> GetIndex([FromUri] GetExpressTypeIndexRequest request)
        {

            var result = new List<logistics_base_express_type>();
            try
            {
                result = ExpressTypeManger.GetIndex(request);
                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }
        }


    }



    [RoutePrefix(ApiConstants.PrefixApi + "Warehouse")]
    public class WarehouseController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(WarehouseController));

        [HttpGet]
        [Route("all")]
        public ResponseMessage<List<logistics_base_warehouse>> GetAll()
        {

            var result = new List<logistics_base_warehouse>();
            try
            {
                result = WarehouseManger.GetAll();
                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }
        }


        [HttpGet]
        [Route("index")]
        public ResponseMessage<List<logistics_base_warehouse>> GetIndex([FromUri] GetWarehouseIndexRequest request)
        {

            var result = new List<logistics_base_warehouse>();
            try
            {
                result = WarehouseManger.GetIndex(request);
                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }
        }

    }

    [RoutePrefix(ApiConstants.PrefixApi + "RecipientsAddress")]
    public class RecipientsAddressController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(RecipientsAddressController));

        [HttpGet]
        [Route("all")]
        public ResponseMessage<List<logistics_base_recipients_address>> GetAll([FromUri] RecipientsAddressGetAllRequest request)
        {

            var result = new List<logistics_base_recipients_address>();
            try
            {
                request.userid = this.contextInfo.userInfo.Userid;
                result = RecipientsAddressManager.GetAll(request);
                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }
        }


        [HttpPost]
        [Route("Item")]
        public ResponseMessage<string> Insert(RecipientsAddressInsertRequest request)
        {

            var result = false;
            try
            {
                result = RecipientsAddressManager.Insert(request, contextInfo.userInfo.Userid);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }
        }

        [HttpPut]
        [Route("Item")]
        public ResponseMessage<string> Update(RecipientsAddressUpdateRequest request)
        {

            var result = false;
            try
            {
                result = RecipientsAddressManager.update(request);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }

        }


        [HttpDelete]
        [Route("Item")]
        public ResponseMessage<string> Delete([FromUri] RecipientsAddressDeleteRequest request)
        {

            var result = false;
            try
            {
                result = RecipientsAddressManager.DeleteByID(request);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }


        }
        [HttpGet]
        [Route("Item")]
        public ResponseMessage<logistics_base_recipients_address> GetItem([FromUri] RecipientsAddressGetRequest request)
        {

            var result = new logistics_base_recipients_address();
            try
            {
                result = RecipientsAddressManager.GetItem(request);
                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }
        }



    }


}
