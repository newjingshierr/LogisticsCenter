using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Logistics.Common;
using Logistics_Model;
using Logistics_Busniess;
using Akmii;


namespace Logistics.Controllers
{
    /// <summary>
    /// 前端每半小时获取一次token；
    /// </summary>
    public class TokenController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));

        /// <summary>
        ///  前端定时获取token，每隔30分钟获取一次；
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public ResponseMessage<string> GetToken([FromUri] TokenRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<string>(SystemStatusEnum.InvalidRequest);
            }

            if (string.IsNullOrEmpty(request.token))
            {
                return GetErrorResult<string>(SystemStatusEnum.InvalidRequest);
            }

            var token = FormsAuthentication.Decrypt(request.token).UserData;
            var ticketArray = token.Split('&');
            var user = ticketArray[0];
            var pwd = ticketArray[1];
            var TenantID = ticketArray[2];

            var encryptTicket = "";
            try
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, user, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}&{2}", user, pwd, TenantID),
                            FormsAuthentication.FormsCookiePath);
                //token进行加密
                encryptTicket = FormsAuthentication.Encrypt(ticket);
                //重新写入token,下次用户登录就用这个token验证
                UserManger.GetTokenCahced(request.TenantID, user, false, encryptTicket);

                return GetResult(encryptTicket);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(encryptTicket, ex.Status.ToString(), (int)ex.Status);
            }

        }
    }
}
