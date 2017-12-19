
namespace Logistics_Model
{

    public class LoginRequest : BaseReqeust
    {
        public string user { get; set; } = "";
        public string pwd { get; set; } = "";

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
}
