using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Logistics.Common;
using Logistics_Model;
using Logistics_Busniess;


namespace Logistics.Controllers
{

    [RoutePrefix(ApiConstants.PrefixApi + "User")]
    public class UserController : BaseController
    {
        /// <summary>
        /// 用户名验证；
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userValidate")]
        public ResponseMessage<bool> UserValidate(UserValidateRequest request)
        {
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
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);
            }

        }


        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>\
        [HttpGet]
        [Route("codeValidate")]
        public ResponseMessage<bool> CodeValidate(ValidateRequest request)
        {
            if ((string.IsNullOrEmpty(request.tel) && string.IsNullOrEmpty(request.mail)))
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
                result = UserManger.CodeValidate(request);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);
            }

        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Send")]
        public ResponseMessage<bool> SendSMS([FromUri] SendSMSRequest request)
        {
            if (string.IsNullOrEmpty(request.tel))
            {
                return GetErrorResult<bool>(SystemStatusEnum.InvalidRequest);
            }
            var result = false;
            try
            {
                result = UserManger.SendSMS(request);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

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
        public ResponseMessage<bool> Register([FromUri] UserRegisterRequest request)
        {
            if (request.pwd == request.rePwd)
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


            var result = false;
            try
            {
                result = UserManger.InsertUser(request);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

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
        public ResponseMessage<AllUserInfo> Login([FromUri] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.user))
            {
                return GetErrorResult<AllUserInfo>(SystemStatusEnum.InvalidUserNameRequest);
            }

            if (string.IsNullOrEmpty(request.pwd))
            {
                return GetErrorResult<AllUserInfo>(SystemStatusEnum.InvalidPwdRequest);
            }

            var encryptTicket = "";
            AllUserInfo allUserInfo = null;
            try
            {
                var userInfo = UserManger.ValidateUser(request);
                if (userInfo == null)
                {
                    return GetErrorResult<AllUserInfo>(SystemStatusEnum.InvalidUserRequest);
                }
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, request.user, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}&{2}", request.user, request.pwd, request.TenantID.ToString()),
                            FormsAuthentication.FormsCookiePath);
                //token进行加密
                encryptTicket = FormsAuthentication.Encrypt(ticket);
                // 用户新增是会员角色；

                //将身份信息保存在session中
                allUserInfo = new AllUserInfo();
                allUserInfo.ticket = encryptTicket;
                allUserInfo.userInfo = userInfo;
                allUserInfo.role = null;

                UserManger.GetAllUserInfoCahced(request.TenantID, request.user, false);
                return GetResult(allUserInfo);
            }
            catch (Exception ex)
            {
                return GetErrorResult(allUserInfo, ex.Message);

            }

        }

    }
}
