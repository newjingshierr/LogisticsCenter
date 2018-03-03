using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Logistics.Common;
using Logistics_Model;
using Logistics_Busniess;
using Akmii;
using System.Collections.Generic;
using System.Data;


namespace Logistics.Controllers
{
    [RoutePrefix(ApiConstants.PrefixApi + "Finance")]
    public class FinanceManagerController : BaseAuthController
    {

    }

}
