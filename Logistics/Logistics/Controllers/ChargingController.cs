using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Logistics.Controllers
{
    [RequestAuthorize]
    public class ChargingController : ApiController
    {
        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns>返回数据</returns>
        [HttpGet]
        public string GetAllChargingData()
        {
            return "Success";
        }

        /// <summary>
        /// 得到当前Id的所有数据
        /// </summary>
        /// <param name="id">参数Id</param>
        /// <returns>返回数据</returns>
        [HttpGet]
        public string GetAllChargingData(string id)
        {
            return "ChargingData" + id;
        }

    }
}
