
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using Akmii.Core;
using Logistics.Common;
using Logistics_Model;
using Akmii;
using System.Web.Security;
using System.Configuration;

using Logistics_Busniess;

namespace Logistics
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {

        public BaseController()
        {
        }
        protected ResponseMessage<T> GetErrorResult<T>(SystemStatusEnum statusCode)
        {
            return new ResponseMessage<T>
            {
                Message = statusCode.GetEnumDescription(),
                Status = (int)statusCode
            };
        }

        protected ResponseMessage<T> GetErrorResult<T>(T data, string message = "", int status = -1)
        {
            return new ResponseMessage<T>
            {
                Data = data,
                Status = status,
                Message = message
            };
        }

        protected ResponseMessage<T> GetResult<T>(T data, int totalCount)
        {
            return new ResponseMessage<T>
            {
                Data = data,
                TotalCount = totalCount,
                Status = 0,
                Message = "success"
            };
        }
        protected ResponseMessage<T> GetResult<T>(T data)
        {
            return new ResponseMessage<T>
            {
                Data = data,
                Status = 0,
                Message = "success"
            };
        }


    }

    [RequestAuthorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseAuthController : BaseController
    {
        public BaseAuthController()
        {
            if (base.Request == null)
            {
                currentInfo  = UserManger.GetCurrentInfo(BusinessConstants.Admin.TenantID, ConfigurationManager.AppSettings["CurrentUser"].ToString()); 
            }
            else
            {
                string authorization = base.Request.Headers.Authorization.ToString();
                var strTicket = FormsAuthentication.Decrypt(authorization).UserData;
                var index = strTicket.IndexOf("&");
                string strUser = strTicket.Substring(0, index);
                currentInfo = UserManger.GetCurrentInfoCahced(BusinessConstants.Admin.TenantID, strUser);
                if (currentInfo == null)
                {
                    throw new LogisticsException(SystemStatusEnum.UserinfoNotFound, $"Userinfo Not Found");
                }
            }


        }
        public CurrentInfo currentInfo { get; set; }

    }
}