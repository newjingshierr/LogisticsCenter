
namespace Logistics_Model
{
    public class OrderStatusRequest : BaseReqeust
    {
        public long userID { get; set; }
    }

    public class TokenRequest : BaseReqeust
    {
        public string token { get; set; } = "";

    }

    public class UpdateUserPwdRequest : BaseReqeust
    {
        public string mail { get; set; } = "";
        public string tel { get; set; } = "";
        public string pwd { get; set; } = "";
        public string code { get; set; } = "";
    }

    public class LoginRequest : BaseReqeust
    {
        public string user { get; set; } = "";
        public string pwd { get; set; } = "";
        public bool remember { get; set; } = true;

    }
    public class LogoutRequest : BaseReqeust
    {
        public string user { get; set; } = "";

    }

    public class SendSMSRequest : BaseReqeust
    {
        public string tel { get; set; } = "";
        public string mail { get; set; } = "";
        public SendTypeEnum type { get; set; }

    }

    public class ValidateRequest : BaseReqeust
    {
        public string mail { get; set; } = "";
        public string tel { get; set; } = "";
        public string code { get; set; } = "";

    }


    public class UserValidateRequest : BaseReqeust
    {
        public string user { get; set; } = "";

    }

    public class CheckSmsValidateRequest : BaseReqeust
    {
        public string tel { get; set; } = "";
        public string code { get; set; } = "";
    }


    public class UserRegisterRequest : BaseReqeust
    {
        public string mail { get; set; } = "";
        public string tel { get; set; } = "";

        public string pwd { get; set; } = "";

        public string rePwd { get; set; } = "";

        public string code { get; set; } = "";
    }

    public class UserCheckRequest : BaseReqeust
    {
        public long userID { get; set; }
        public string Pwd { get; set; }
    }

    public class GetNavgationListRequest : BaseReqeust
    {
        public long userID { get; set; }
    }


    public class GetMemberRequest : BaseReqeust
    {
        /// <summary>
        /// 手機號或者郵箱
        /// </summary>
        public string userName { get; set; }
    }


}
