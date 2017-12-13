using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class logistics_quotation_channel
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
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        /// Prescription
        /// </summary>		
        private string _prescription;
        public string Prescription
        {
            get { return _prescription; }
            set { _prescription = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// Clause
        /// </summary>		
        private string _clause;
        public string Clause
        {
            get { return _clause; }
            set { _clause = value; }
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

    }

    public class logistics_quotation_partition_price
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
        /// firstHeavyPrice
        /// </summary>		
        private decimal _firstheavyprice;
        public decimal firstHeavyPrice
        {
            get { return _firstheavyprice; }
            set { _firstheavyprice = value; }
        }
        /// <summary>
        /// continuedHeavyPrice
        /// </summary>		
        private decimal _continuedheavyprice;
        public decimal continuedHeavyPrice
        {
            get { return _continuedheavyprice; }
            set { _continuedheavyprice = value; }
        }
        /// <summary>
        /// channelID
        /// </summary>		
        private long _channelid;
        public long channelID
        {
            get { return _channelid; }
            set { _channelid = value; }
        }
        /// <summary>
        /// partitionID
        /// </summary>		
        private long _partitionid;
        public long partitionID
        {
            get { return _partitionid; }
            set { _partitionid = value; }
        }
        /// <summary>
        /// beginHeavy
        /// </summary>		
        private decimal _beginheavy;
        public decimal beginHeavy
        {
            get { return _beginheavy; }
            set { _beginheavy = value; }
        }
        /// <summary>
        /// endHeavy
        /// </summary>		
        private decimal _endheavy;
        public decimal endHeavy
        {
            get { return _endheavy; }
            set { _endheavy = value; }
        }
        /// <summary>
        /// price
        /// </summary>		
        private decimal _price;
        public decimal price
        {
            get { return _price; }
            set { _price = value; }
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


    }

    public class logistics_quotation_partition_country
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
        /// countryEnglishName
        /// </summary>		
        private string _countryenglishname;
        public string countryEnglishName
        {
            get { return _countryenglishname; }
            set { _countryenglishname = value; }
        }
        /// <summary>
        /// countryChineseName
        /// </summary>		
        private string _countrychinesename;
        public string countryChineseName
        {
            get { return _countrychinesename; }
            set { _countrychinesename = value; }
        }
        /// <summary>
        /// countryCode
        /// </summary>		
        private string _countrycode;
        public string countryCode
        {
            get { return _countrycode; }
            set { _countrycode = value; }
        }
        /// <summary>
        /// partitionID
        /// </summary>		
        private long _partitionid;
        public long partitionID
        {
            get { return _partitionid; }
            set { _partitionid = value; }
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

        public long ChannelID { get; set; }

    }


    public class logistics_quotation_partition
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
        /// partitionCode
        /// </summary>		
        private string _partitioncode;
        public string partitionCode
        {
            get { return _partitioncode; }
            set { _partitioncode = value; }
        }
        /// <summary>
        /// type
        /// </summary>		
        private bool _type;
        public bool type
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

        public long ChannelID { get; set; }

    }
}
