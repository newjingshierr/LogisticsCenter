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
    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrder")]
    public class CustomerOrderController : BaseAuthController
    {

    }
}
