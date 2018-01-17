using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Logistics_Busniess;
using Logistics_Model;
namespace Logistics
{
    /// <summary>
    /// 自定义此特性用于接口的身份验证
    /// </summary>
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        //重写基类的验证方式，加入我们自定义的Ticket验证
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;
            if (authorization != null)
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.ToString();
                if (ValidateTicket(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {

            #if !DEBUG
                            var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                            bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                            if (isAnonymous) base.OnAuthorization(actionContext);
                            else HandleUnauthorizedRequest(actionContext);
            #endif

            }
        }

        //
        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

            //从Ticket里面获取用户名和密码

            var ticketArray = strTicket.Split('&');
            var strUser = ticketArray[0];
            var strPwd = ticketArray[1];
            var strTenantID = ticketArray[2];


            var key = CacheConstants.GetToken(strUser, long.Parse(strTenantID));
            //缓存中读取，进行验证token;
            var cachedToken = UserManger.GetTokenCached(key);
            if (encryptTicket == cachedToken)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}