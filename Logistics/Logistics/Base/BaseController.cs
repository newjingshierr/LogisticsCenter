
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
using System.Web.Http.Controllers;

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

    public class BaseAuthController : BaseController
    {


        protected override void Initialize(HttpControllerContext controllerContext)
        {

            if (controllerContext.Request.Headers.Authorization == null)
            {
                contextInfo = UserManger.GetCurrentInfo(BusinessConstants.Admin.TenantID, ConfigurationManager.AppSettings["CurrentUser"].ToString());
            }
            else
            {
                try
                {
                    string authorization = controllerContext.Request.Headers.Authorization.ToString();
                    var strTicket = FormsAuthentication.Decrypt(authorization).UserData;


                    var ticketArray = strTicket.Split('&');
                    var User = ticketArray[0];
                    _user = ticketArray[0];
                    var Pwd = ticketArray[1];
                    _pwd = ticketArray[1];
                    var TenantID = ticketArray[2];
                    _tenantID = ticketArray[2];
                    var index = strTicket.IndexOf("&");
                    string strUser = strTicket.Substring(0, index);
                    //contextInfo = UserManger.GetCurrentInfoCahced(BusinessConstants.Admin.TenantID, strUser);
                    // var currentInfo = new ContextInfo();
                    contextInfo = UserManger.GetCurrentInfo(long.Parse(TenantID), User);
                    if (contextInfo == null)
                    {
                        throw new LogisticsException(SystemStatusEnum.UserinfoNotFound, $"Userinfo Not Found");
                    }
                }
                catch (Exception ex)
                {
                    throw new LogisticsException(SystemStatusEnum.TokenExpired, $"Token Expired");
                }
            }
            base.Initialize(controllerContext);
        }
        public BaseAuthController()
        {

        }
        protected ContextInfo contextInfo { get; set; }

        protected string _user { get; set; }
        protected string _pwd { get; set; }
        protected string _tenantID { get; set; }

    }
}