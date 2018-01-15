using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logistics_Busniess;
using Logistics_Model;
using Logistics.Core;
using Akmii;
using Logistics.Common;

namespace Logistics.Controllers
{
    [RoutePrefix(ApiConstants.PrefixApi + "Navigation")]
    public class NavigationController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));
        /// <summary>
        /// 获取用户导航列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>\
        [HttpGet]
        [Route("Item")]
        public ResponseMessage<List<logistics_base_navigation>> GetNavgationListByUserID([FromUri]GetNavgationListRequest request)
        {
            if (request == null || request.userID == null)
            {
                return GetErrorResult<List<logistics_base_navigation>>(SystemStatusEnum.InvalidRequest);
            }
            var result = new List<logistics_base_navigation>();
            try
            {
                result = NavigationManager.GetNavgationListByUserID(request);
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
