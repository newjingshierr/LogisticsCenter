using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class logistics_base_sms_validate
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
        /// tel
        /// </summary>		
        private string _tel;
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// code
        /// </summary>		
        private string _code;
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// startTime
        /// </summary>		
        private DateTime _starttime;
        public DateTime startTime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }
        /// <summary>
        /// endTime
        /// </summary>		
        private DateTime _endtime;
        public DateTime endTime
        {
            get { return _endtime; }
            set { _endtime = value; }
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
        /// Modified
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

        public string mail { get; set; }
    }
}
