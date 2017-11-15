using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logistics_Busniess;
using Logistics_Model;
using Logistics;
using Logistics_Busniess;

namespace Logistics.Controllers
{
    [RoutePrefix(ApiConstants.PrefixApi + "api/demo")]
    public class DemoController : BaseController
    {
        /// <summary>
        /// 根据Name 查找Demo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public ResponseMessage<List<demo>> DemoGetAll([FromUri] DemoGetByNameRequest request)
        {
            int totalCount = 0;
            if (request.PageIndex < 1)
                request.PageIndex = 1;
            if (request.PageSize < 1)
                request.PageSize = 20;
            var result = new List<demo>();

            try
            {
                result = DemoManger.GetAllByName(request, ref totalCount);

                return GetResult(result, totalCount);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);
            }

        }
    }
}
