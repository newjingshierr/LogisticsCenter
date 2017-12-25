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

    public class logistics_base_userinfo_log
    {
        /// <summary>
        /// TenantID
        /// </summary>		
        private long _tenantid;
        public long TenantID
        {
            get { return _tenantid; }
            set { _tenantid = value; }
        }
        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Userid
        /// </summary>		
        private long _userid;
        public long Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// userIP
        /// </summary>		
        private string _userip;
        public string userIP
        {
            get { return _userip; }
            set { _userip = value; }
        }
        /// <summary>
        /// logDatetime
        /// </summary>		
        private DateTime _logdatetime;
        public DateTime logDatetime
        {
            get { return _logdatetime; }
            set { _logdatetime = value; }
        }
        /// <summary>
        /// type
        /// </summary>		
        private int _type;
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// Created
        /// </summary>		
        private DateTime _created;
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        /// <summary>
        /// on update CURRENT_TIMESTAMP(3)
        /// </summary>		
        private DateTime _modified;
        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>		
        private long _createdby;
        public long CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }
        /// <summary>
        /// ModifiedBy
        /// </summary>		
        private long _modifiedby;
        public long ModifiedBy
        {
            get { return _modifiedby; }
            set { _modifiedby = value; }
        }

    }

}
