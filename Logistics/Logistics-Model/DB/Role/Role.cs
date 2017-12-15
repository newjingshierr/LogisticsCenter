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
    public class logistics_base_role_user_binding
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
        /// RoleID
        /// </summary>		
        private long _roleid;
        public long RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
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


    public class logistics_base_role
    {

        /// <summary>
        /// TenantID
        /// </summary>		

        private long _tenantid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long TenantID
        {
            get { return _tenantid; }
            set { _tenantid = value; }
        }
        /// <summary>
        /// RoleID
        /// </summary>		
        private long _roleid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        /// <summary>
        /// roleName
        /// </summary>		
        private string _rolename;
        public string roleName
        {
            get { return _rolename; }
            set { _rolename = value; }
        }
        /// <summary>
        /// Created
        /// </summary>		

        private DateTime _created;
        [JsonConverter(typeof(DateTime2IOSStringConverter))]
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        /// <summary>
        /// on update CURRENT_TIMESTAMP(3)
        /// </summary>		
        private DateTime _modified;
        [JsonConverter(typeof(DateTime2IOSStringConverter))]
        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>		
        private long _createdby;
        [JsonConverter(typeof(Long2StringConverter))]
        public long CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }
        /// <summary>
        /// ModifiedBy
        /// </summary>		
        private long _modifiedby;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ModifiedBy
        {
            get { return _modifiedby; }
            set { _modifiedby = value; }
        }

    }
}
