using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class SendSMSValidateRequest : BaseReqeust
    {
        public string tel { get; set; }

    }

    public class SmsValidateRequest : BaseReqeust
    {
        public string tel { get; set; }
        public string code { get; set; }


    }

    public class CheckSmsValidateRequest : BaseReqeust
    {
        public string tel { get; set; }
        public string code { get; set; }
    }


    public class UserRegisterRequest : BaseReqeust
    {
        public string Email { get; set; } = "";
        public string Tel { get; set; } = "";

        public string Pwd { get; set; } = "";
    }
    public class UserCheckRequest : BaseReqeust
    {
        public long TenantID { get; set; }
        public long userID { get; set; }
        public string Pwd { get; set; }
    }
}
