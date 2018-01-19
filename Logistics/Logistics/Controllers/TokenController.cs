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
    [RoutePrefix(ApiConstants.PrefixApi + "Token")]
    public class TokenController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));

        /// <summary>
        ///  前端定时获取token，每隔30分钟获取一次；
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Item")]
        public ResponseMessage<string> GetToken()
        {
            var encryptTicket = "";

            try
            {
                if (TokenManager.GetTokenByUserID(base.contextInfo.userInfo.Userid))
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, _user, DateTime.Now,
                          DateTime.Now.AddYears(1), true, string.Format("{0}&{1}&{2}", _user, _pwd, _pwd),
                          FormsAuthentication.FormsCookiePath);
                    //token进行加密
                    encryptTicket = FormsAuthentication.Encrypt(ticket);

                    //写入token log
                    InsertTokenLogRequest insertTokenLogRequest = new InsertTokenLogRequest();
                    insertTokenLogRequest.token = encryptTicket;
                    insertTokenLogRequest.userID = base.contextInfo.userInfo.Userid;
                    TokenManager.InsertTokenLog(insertTokenLogRequest);
                }


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
