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
    [RoutePrefix(ApiConstants.PrefixApi + "SystemBase")]
    public class SystemBaseController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));

        /// <summary>
        /// 獲取用戶的消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("message/latest")]
        public ResponseMessage<List<logistics_base_message>> GetItemListByLatest()
        {

            var result = new List<logistics_base_message>();
            try
            {
                result = BaseManager.GetItemListByLatest(base.currentInfo.userInfo.Userid);

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
        [Route("message/page")]
        public ResponseMessage<List<logistics_base_message>> GetItemListByPage(GetItemListByPageRequest request)
        {
            var result = new List<logistics_base_message>();
            int totalCount = 0;
            try
            {
                result = BaseManager.GetItemListByPage(request, base.currentInfo.userInfo.Userid, ref totalCount);

                return GetResult(result, totalCount);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }

        }




    }
}
