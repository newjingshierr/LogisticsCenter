using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Logistics.Common;
using Logistics_Model;
using Logistics_Busniess;
using Akmii;
using System.Web.Security;
using System.Collections.Generic;



namespace Logistics.Controllers
{

    [RoutePrefix(ApiConstants.PrefixApi + "User")]
    public class UserController : BaseController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));

        /// <summary>
        /// 用户名验证；
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userValidate")]
        public ResponseMessage<bool> UserNameValidate([FromUri]UserValidateRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }

            if (string.IsNullOrEmpty(request.user))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidUserExistRequest);
            }

            var result = false;
            try
            {
                result = UserManger.ValidateUser(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }

        }


        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>\
        [HttpGet]
        [Route("codeValidate")]
        public ResponseMessage<bool> CodeValidate([FromUri]ValidateRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }

            if ((string.IsNullOrEmpty(request.tel) && string.IsNullOrEmpty(request.mail)))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidTelOrMailRequest);
            }

            if ((!string.IsNullOrEmpty(request.tel) && !string.IsNullOrEmpty(request.mail)))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidTelOrMailRequest);
            }

            if (string.IsNullOrEmpty(request.code))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidCodeRequest);
            }

            var result = false;
            try
            {
                result = UserManger.ValidateCode(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }

        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Send")]
        public ResponseMessage<bool> SendSMS(SendSMSRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }

            if (string.IsNullOrEmpty(request.type.ToString()))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }
            if (string.IsNullOrEmpty(request.tel) && string.IsNullOrEmpty(request.mail))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }
            if (!string.IsNullOrEmpty(request.tel) && !string.IsNullOrEmpty(request.mail))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }
            var result = false;
            try
            {
                result = UserManger.SendSMS(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }

        /// <summary>
        /// 用户注册接口
        /// </summary>
        /// <param name="strUser"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public ResponseMessage<bool> Register(UserRegisterRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }

            if (request.pwd != request.rePwd)
            {
                return GetErrorResult<bool>(SystemStatusEnum.PwdRepeatRequest);
            }
            if (request.pwd.Length < 6)
            {
                return GetErrorResult<bool>(SystemStatusEnum.PwdLess6Request);
            }
            if ((string.IsNullOrEmpty(request.tel) && string.IsNullOrEmpty(request.mail)))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidTelOrMailRequest);
            }
            if (string.IsNullOrEmpty(request.code))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidCodeRequest);
            }
            if (HashHelper.IsSafeSqlString(request.pwd) || HashHelper.IsSafeSqlString(request.rePwd) || HashHelper.ProcessSqlStr(request.rePwd) || HashHelper.IsSafeSqlString(request.rePwd))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidPwdRequest);
            }

            if ((!string.IsNullOrEmpty(request.tel) && !string.IsNullOrEmpty(request.mail)))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidTelOrMailRequest);
            }


            UserValidateRequest userValidateRequest = new UserValidateRequest();
            userValidateRequest.user = request.mail == "" ? request.tel : request.mail;

            var result = false;
            try
            {
                if (UserManger.ExistUser(userValidateRequest))
                {
                    result = UserManger.InsertUser(request);
                }

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }

        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="strUser"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ResponseMessage<string> Login(LoginRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<string>(SystemStatusEnum.InvalidRequest);
            }

            if (string.IsNullOrEmpty(request.user))
            {
                return GetErrorResult<string>(SystemStatusEnum.InvalidUserNameRequest);
            }

            if (string.IsNullOrEmpty(request.pwd))
            {
                return GetErrorResult<string>(SystemStatusEnum.InvalidPwdRequest);
            }

            var encryptTicket = "";
            var result = false;
            try
            {
                result = UserManger.ValidateUser(request);
                if (result == false)
                {
                    return GetErrorResult<string>(SystemStatusEnum.InvalidUserRequest);
                }


                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, request.user, DateTime.Now,
                            DateTime.Now.AddMinutes(15), true, string.Format("{0}&{1}&{2}", request.user, request.pwd, request.TenantID.ToString()),
                            FormsAuthentication.FormsCookiePath);
                //token进行加密
                encryptTicket = FormsAuthentication.Encrypt(ticket);

                // 用户新增是会员角色；
                //用户token写入缓存；
                UserManger.GetTokenCahced(request.TenantID, request.user, false, encryptTicket);
                var currentInfo = new ContextInfo();
                currentInfo = UserManger.GetCurrentInfo(request.TenantID, request.user);
                //用户信息写入缓存；
                if (currentInfo == null)
                    return GetErrorResult<string>(SystemStatusEnum.InvalidUserRequest);
                UserManger.GetCurrentInfoCahced(request.TenantID, request.user, false, currentInfo);

                return GetResult(encryptTicket);
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(encryptTicket, ex.Status.ToString(), (int)ex.Status);
            }

        }

        [RequestAuthorize]
        [HttpPost]
        [Route("Logout")]
        public ResponseMessage<string> Logout(LogoutRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<string>(SystemStatusEnum.InvalidRequest);
            }

            if (string.IsNullOrEmpty(request.user))
            {
                return GetErrorResult<string>(SystemStatusEnum.InvalidUserNameRequest);
            }


            var result = false;
            try
            {
                result = UserManger.RemoveTokenCached(BusinessConstants.Admin.TenantID, request.user);

                return GetResult(result.ToString());
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result.ToString(), ex.Status.ToString(), (int)ex.Status);
            }

        }
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Forget")]
        public ResponseMessage<bool> UpdatePwd(UpdateUserPwdRequest request)
        {
            var result = false;
            if (string.IsNullOrEmpty(request.pwd))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidPwdRequest);
            }
            if (HashHelper.IsSafeSqlString(request.pwd))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidPwdRequest);
            }
            if ((!string.IsNullOrEmpty(request.tel) && !string.IsNullOrEmpty(request.mail)))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidTelOrMailRequest);
            }

            var user = request.tel == "" ? request.mail : request.tel;
            try
            {
                result = UserManger.UpdateUserPass(request);
                if (result)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, user, DateTime.Now,
                         DateTime.Now.AddMinutes(15), true, string.Format("{0}&{1}&{2}", user, request.pwd, request.TenantID.ToString()),
                         FormsAuthentication.FormsCookiePath);
                    // UserManger.GetTokenCahced(request.TenantID, user, false, FormsAuthentication.Encrypt(ticket));
                }
            }
            catch (LogisticsException ex)
            {
                log.Error(ex.Message);
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);
            }
            return GetResult(result);

        }

    }

    [RoutePrefix(ApiConstants.PrefixApi + "Member")]
    public class MemberController : BaseAuthController
    {
        LogHelper log = LogHelper.GetLogger(typeof(UserController));

        [HttpGet]
        [Route("ContextInfo")]
        public ResponseMessage<ContextInfo> GetCurrentInfo()
        {
            var result = new ContextInfo();

            try
            {
                result = base.currentInfo;
                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }
    }
}
