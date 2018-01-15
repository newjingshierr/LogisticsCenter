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
    /*

         */
    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrder")]
    public class CustomerOrderController : BaseAuthController
    {
        //統計待打包個數
        //統計待付款訂單數
        //統計已發貨訂單數
    }


    [RoutePrefix(ApiConstants.PrefixApi + "CustomerOrderMerge")]
    public class CustomerOrderMergeController : BaseAuthController
    {

    }



}
