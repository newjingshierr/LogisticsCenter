
namespace Logistics_Model
{
    public class MessageInsertRequest : BaseRequest
    {
        public messageType type { get; set; }
        public string message { get; set; }
        public long userid { get; set; }
    }
    public class OrderStatusRequest : BaseRequest
    {
        public long userID { get; set; }
    }
    public class InsertTokenLogRequest : BaseRequest
    {
        public string token { get; set; }
        public long userID { get; set; }
    }

    public class TokenRequest : BaseRequest
    {
        public string token { get; set; } = "";

    }

    public class UpdateUserPwdRequest : BaseRequest
    {
        public string mail { get; set; } = "";
        public string tel { get; set; } = "";
        public string pwd { get; set; } = "";
        public string code { get; set; } = "";
    }

    public class LoginRequest : BaseRequest
    {
        public string user { get; set; } = "";
        public string pwd { get; set; } = "";

    }
    public class LogoutRequest : BaseRequest
    {
        public string user { get; set; } = "";

    }

    public class SendSMSRequest : BaseRequest
    {
        public string tel { get; set; } = "";
        public string mail { get; set; } = "";
        public SendTypeEnum type { get; set; }

    }

    public class ValidateRequest : BaseRequest
    {
        public string mail { get; set; } = "";
        public string tel { get; set; } = "";
        public string code { get; set; } = "";

    }


    public class UserValidateRequest : BaseRequest
    {
        public string user { get; set; } = "";

    }

    public class CheckSmsValidateRequest : BaseRequest
    {
        public string tel { get; set; } = "";
        public string code { get; set; } = "";
    }


    public class UserRegisterRequest : BaseRequest
    {
        public string mail { get; set; } = "";
        public string tel { get; set; } = "";

        public string pwd { get; set; } = "";

        public string rePwd { get; set; } = "";

        public string code { get; set; } = "";
    }

    public class UserCheckRequest : BaseRequest
    {
        public long userID { get; set; }
        public string Pwd { get; set; }
    }

    public class GetNavgationListRequest : BaseRequest
    {
        public long userID { get; set; }
    }


    public class GetMemberRequest : BaseRequest
    {
        /// <summary>
        /// 手機號或者郵箱
        /// </summary>
        public string userName { get; set; }
    }


}
