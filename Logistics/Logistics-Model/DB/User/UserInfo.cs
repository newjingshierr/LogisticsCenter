using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Akmii;
using System.Runtime.Serialization;


namespace Logistics_Model
{
    public class UserInfo
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long TenantID { get; set; }
        public string Email { get; set; }

        public string Tel { get; set; }
        public string UserName { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public long Userid { get; set; }

        public byte[] Pwd { get; set; }

        public string WebChatID { get; set; }

        public string Token { get; set; }

        public string MemeberCode { get; set; }

        public string LastLoginTime { get; set; }

        [JsonConverter(typeof(DateTime2IOSStringConverter))]
        public DateTime Created { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public long CreatedBy { get; set; }

        [JsonConverter(typeof(Long2StringConverter))]
        public long ModifiedBy { get; set; }

        public string Ticket { get; set; }



    }

    public class AllUserInfo
    {
        public UserInfo userInfo { get; set; }
        public logistics_base_role role { get; set; }

        public string ticket { get; set; }

    }

}
