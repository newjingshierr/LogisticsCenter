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
        /// 或用獲取的消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("message/items")]
        public ResponseMessage<bool> GetItemListByUserID([FromUri]UserValidateRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }

            if (string.IsNullOrEmpty(request.user))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidUserExistRequest);
            }

            var result = false;
            try
            {
                result = UserManger.ValidateUser(request);

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
