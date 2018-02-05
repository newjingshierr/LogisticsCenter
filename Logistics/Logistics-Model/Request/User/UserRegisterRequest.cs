using Newtonsoft.Json;
using Akmii;
using System.Collections.Generic;

namespace Logistics_Model
{
    public class RecipientsAddressDeleteRequest : BaseRequest
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long id { get; set; }
    }

    public class RecipientsAddressGetAllRequest : BaseRequest
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long userid { get; set; }
    }
    public class RecipientsAddressGetRequest : BaseRequest
    {
        public long id { get; set; }
    }

    public class RecipientsAddressInsertRequest : BaseRequest
    {
        public string country { get; set; }

        public string recipient { get; set; }
        public string City { get; set; }
        public string postalcode { get; set; }

        public string Tel { get; set; }
        public string taxno { get; set; }
        public string companyName { get; set; }
        public string Address { get; set; }

    }

    public class RecipientsAddressUpdateRequest : BaseRequest
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long id { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long userid { get; set; }
        public string country { get; set; }
        public string recipient { get; set; }
        public string City { get; set; }
        public string postalcode { get; set; }
        public string Tel { get; set; }
        public string taxno { get; set; }
        public string companyName { get; set; }
        public string Address { get; set; }
    }



    public class CustomerOrderMergeInsertReqeust : BaseRequest
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long userid { get; set; }
        public string CustomerMark { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long CustomerChooseChannelID { get; set; }
        public string recipient { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string code { get; set; }
        public string tel { get; set; }
        public string company { get; set; }
        public string taxNo { get; set; }
        public List<CustomerOrderRequest> customerOrderList { get; set; }
        public List<InsertProductRequet> productList { get; set; }

    }


    public class CustomerOrderMergeUpdateReqeust : BaseRequest
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long userid { get; set; }
        public string CustomerMark { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long CustomerChooseChannelID { get; set; }
        public string recipient { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string code { get; set; }
        public string tel { get; set; }
        public string company { get; set; }
        public string taxNo { get; set; }
        public List<CustomerOrderRequest> customerOrderList { get; set; }
        public List<InsertProductUpdateRequet> productList { get; set; }
        public List<logistics_customer_order_merge_relation> relationlist { get; set; }

    }


    public class InsertProductRequet
    {
        public string productName { get; set; }
        public string productNameEN { get; set; }
        public string HSCode { get; set; }
        public decimal declareUnitPrice { get; set; }
        public decimal count { get; set; }

    }

    public class InsertProductUpdateRequet
    {
        public long ID { get; set; }
        public string productName { get; set; }
        public string productNameEN { get; set; }
        public string HSCode { get; set; }
        public decimal declareUnitPrice { get; set; }
        public decimal count { get; set; }

    }
    public class CustomerOrderRequest
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long customerOrderID { get; set; }
    }

    public class GetExpressTypeIndexRequest : BaseRequest
    {
        public string name { get; set; }
    }

    public class GetWarehouseIndexRequest : BaseRequest
    {
        public string name { get; set; }
    }

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
        
        public string WarehouseAdminRemark { get; set; }

    }
    public class CustomerOrderSelectRequest : BaseRequestPage
    {
        public int type { get; set; }
        public string customerOrderNo { get; set; } = "";
        public string expressNo { get; set; } = "";
        public long expressTypeID { get; set; } = 0L;

        public string TransferNo { get; set; } = "";
        public long warehouseID { get; set; } = 0L;
        public System.DateTime ? InWarehouseIimeBegin { get; set; } = null;
        public System.DateTime? InWarehouseIimeEnd { get; set; } = null;
        public long CustomerServiceID { get; set; } = 0L;
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
    public class GeItemsRequest : BaseRequest
    {
        /// <summary>
        /// 查询信息
        /// </summary>
        public List<CustomerOrderID> customerOrderIDLists { get; set; }

    }

    public class CustomerOrderID
    {
        public string customerOrderID { get; set; }
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
