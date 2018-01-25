using Newtonsoft.Json;
using Akmii;

namespace Logistics_Model
{
    public class CustomerOrderDeleteRequest : BaseRequest
    {
        public long ID { get; set; }
    }

    public class CustomerOrderUpdateReqeust : BaseRequest
    {

        [JsonConverter(typeof(Long2StringConverter))]
        public long ID { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long userid { get; set; }
        public string expressNo { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public long expressTypeID { get; set; }

        public string expressTypeName { get; set; }

        public string TransferNo { get; set; }

        public decimal InPackageCount { get; set; }

        public decimal InWeight { get; set; }

        public decimal InHeight { get; set; }

        public decimal InVolume { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public decimal InLength { get; set; }

        public decimal InWidth { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long WareHouseID { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public long CustomerServiceID { get; set; }

        public string InWareHouseStatus { get; set; }

    }


    public class CustomerOrderInsertReqeust : BaseRequest
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long userid { get; set; }
        public string expressNo { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public long expressTypeID { get; set; }

        public string expressTypeName { get; set; }

        public string TransferNo { get; set; }

        public decimal InPackageCount { get; set; }

        public decimal InWeight { get; set; }
        public decimal InVolume { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public decimal InLength { get; set; }

        public decimal InWidth { get; set; }

        public decimal InHeight { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long WareHouseID { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public long CustomerServiceID { get; set; }

        public string InWareHouseStatus { get; set; }

    }
    public class CustomerOrderSelectRequest : BaseRequestPage
    {
        public int type { get; set; }
    }

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
    public class GeIndexRequest : BaseRequest
    {
        /// <summary>
        /// 查询信息
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// 查询类型
        /// </summary>
        public IndexRequestEnum type { get; set; }
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
