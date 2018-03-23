using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Logistics.Common;
using Logistics_Model;
using Logistics_Busniess;
using Akmii;
using System.Collections.Generic;
using System.Linq;

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
        public ResponseMessage<List<logistics_base_message>> GetItemListByLatest([FromUri]GetItemListByPageRequest request)
        {

            var result = new List<logistics_base_message>();
            try
            {
                result = MessageManager.GetMessageListByLatest(contextInfo.userInfo.Userid, request);

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
        public ResponseMessage<List<logistics_base_message>> GetItemListByPage([FromUri]GetItemListByPageRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<List<logistics_base_message>>(SystemStatusEnum.InvalidRequest);
            }
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


        /// <summary>
        ///更新消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Item/update")]
        public ResponseMessage<bool> UpdateMessage(MessageUpdateRequest request)
        {
            LogHelper log = LogHelper.GetLogger(typeof(MessageController));

            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }

            logistics_base_message message = new logistics_base_message();
            message.ID = request.ID;
            message.status = request.status;
            message.title = request.title;
            message.message = request.message;
            message.ModifiedBy = contextInfo.userInfo.Userid;
            message.TenantID = BusinessConstants.Admin.TenantID;

            var result = false;
            try
            {
                result = MessageManager.Update(message);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }

        /// <summary>
        /// 新增消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取消息未读数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("unread")]
        public ResponseMessage<int> UnRead()
        {

            var result = 0;
            try
            {
                result = MessageManager.UnReadMessageCount(contextInfo.userInfo.Userid);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult((int)result, ex.Message);
            }

        }
        
        /// <summary>
        /// 未读信息是否已读进行更新
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("unreadupdate")]
        public ResponseMessage<string> unreadupdate( )
        {

            var result = false;
            try
            {
                result = MessageManager.logistics_base_message_unread_update(contextInfo.userInfo.Userid);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);
            }

        }

        //[HttpGet]
        //[Route("items/unread")]
        //public ResponseMessage<int> GetUnReadMessageCount()
        //{

        //}

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

    [RoutePrefix(ApiConstants.PrefixApi + "Agent")]
    public class AgentController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(AgentController));

        [HttpGet]
        [Route("index")]
        public ResponseMessage<List<logistics_base_agent>> GetIndex([FromUri] GetAgentIndexRequest request)
        {
            var result = new List<logistics_base_agent>();
            try
            {
                result = AgentManager.GetIndex(request);
                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }
        }

        [HttpGet]
        [Route("page")]
        public ResponseMessage<List<logistics_base_agent>> GetListByPage([FromUri] GetAgentPageRequest request)
        {
            int totalCount = 0;
            var result = new List<logistics_base_agent>();
            try
            {
                result = AgentManager.GetListByPage(request, this.contextInfo.userInfo.Userid, ref totalCount);
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
        public ResponseMessage<string> Insert(InsertAgentRequest request)
        {

            var result = false;
            try
            {
                result = AgentManager.Insert(request, contextInfo.userInfo.Userid);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }
        }

        [HttpPut]
        [Route("Item")]
        public ResponseMessage<string> Update(UpdateAgentRequest request)
        {

            var result = false;
            try
            {
                result = AgentManager.update(request, this.contextInfo.userInfo.Userid);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }

        }


        [HttpDelete]
        [Route("Item")]
        public ResponseMessage<string> Delete([FromUri] DeleteAgentRequest request)
        {

            var result = false;
            try
            {
                result = AgentManager.DeleteByID(request);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }


        }

        [HttpGet]
        [Route("Item")]
        public ResponseMessage<logistics_base_agent> GetItem([FromUri] GetAgentModelRequest request)
        {

            var result = new logistics_base_agent();
            try
            {
                result = AgentManager.GetModel(request);
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
                request.userid = this.contextInfo.userInfo.Userid;

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

    [RoutePrefix(ApiConstants.PrefixApi + "File")]
    public class FileController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(FileController));

        [HttpGet]
        [Route("Attachments/items")]
        public ResponseMessage<List<logistics_base_attachment>> SelectAttachmentsByCustomerOrderID([FromUri] GetFileByCustomerOrderIDRequest request)
        {

            if (request == null)
            {
                return GetErrorResult<List<logistics_base_attachment>>(SystemStatusEnum.InvalidRequest);
            }

            var result = new List<logistics_base_attachment>();
            try
            {
                result = FileManager.GetAttachmentListByCustomerOrderID(request.customerOrderID);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }

        [HttpPost]
        [Route("upload")]
        public ResponseMessage<string> upload()
        {
            var result = 0L;
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpPostedFile = HttpContext.Current.Request.Files;
                    if (httpPostedFile != null && httpPostedFile.Count > 0)
                    {
                        var file = httpPostedFile[0];
                        string uploadPath = HttpContext.Current.Server.MapPath("/upload/");
                        string fullPath = uploadPath + file.FileName;
                        file.SaveAs(fullPath);
                        result = FileManager.Insert("/upload/" + file.FileName, base.contextInfo.userInfo.Userid);
                        if (result == 0)
                        {
                            return GetErrorResult<string>(SystemStatusEnum.FileUploadFailedRequest);
                        }
                        //Todo：文件处理操作
                    }
                }

                return GetResult(result.ToString());
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result.ToString(), ex.Status.ToString(), (int)ex.Status);
            }



        }

        [HttpDelete]
        [Route("delete")]
        public ResponseMessage<string> delete(FileDeleteRequest request)
        {
            var result = false;
            try
            {
                result = FileManager.DeleteByID(request.id);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }
        }
    }
}
