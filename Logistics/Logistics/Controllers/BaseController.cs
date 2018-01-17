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
                result = MessageManager.GetMessageListByLatest(base.contextInfo.userInfo.Userid);

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
}
