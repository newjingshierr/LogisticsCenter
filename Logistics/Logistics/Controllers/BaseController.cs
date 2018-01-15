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
    [RoutePrefix(ApiConstants.PrefixApi + "Base")]
    public class BaseController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));

        /// <summary>
        /// 獲取用戶的消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("message/items")]
        public ResponseMessage<List<logistics_base_message>> GetItemListByUserID([FromUri]GetItemListByUserIDRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<List<logistics_base_message>>(SystemStatusEnum.InvalidRequest);
            }

            var result = new List<logistics_base_message>();
            try
            {
                result = BaseManager.GetItemListByUserID(request);

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
