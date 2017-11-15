using System.Linq;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Web.Http;


namespace Logistics.Controllers
{
    [RoutePrefix(ApiConstants.PrefixApi + "api/budgetbalance")]
    public class DefaultController : ApiController
    {

        [HttpGet]
        [Route("Items")]
        public bool Items(int index = 0, int pageSize = 5)
        {
            return true;

        }
    }
}