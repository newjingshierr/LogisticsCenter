using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Akmii;


namespace Logistics_Model
{
    public class logistics_base_token_log
    {

        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// token
        /// </summary>		
        private string _token;
        public string token
        {
            get { return _token; }
            set { _token = value; }
        }
        /// <summary>
        /// Userid
        /// </summary>		
        private long _userid;
        [JsonConverter(typeof(Long2StringConverter))]
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
    public class logistics_base_recipients_address
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Userid
        /// </summary>		
        private long _userid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// ProvinceID
        /// </summary>		
        private long _provinceid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ProvinceID
        {
            get { return _provinceid; }
            set { _provinceid = value; }
        }
        /// <summary>
        /// CityID
        /// </summary>		
        private long _cityid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long CityID
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        /// <summary>
        /// postalcode
        /// </summary>		
        private string _postalcode;
        public string postalcode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }
        /// <summary>
        /// Tel
        /// </summary>		
        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// Address
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
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
    public class logistics_base_attachment
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// path
        /// </summary>		
        private string _path;
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }
        /// <summary>
        /// customerOrderID
        /// </summary>		
        private long _customerorderid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long customerOrderID
        {
            get { return _customerorderid; }
            set { _customerorderid = value; }
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
    public class logistics_base_channel
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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
    public class logistics_base_express_type
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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
    public class logistics_base_navigation_role_binding
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// NavigationID
        /// </summary>		
        private long _navigationid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long NavigationID
        {
            get { return _navigationid; }
            set { _navigationid = value; }
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
        [JsonConverter(typeof(Long2StringConverter))]
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
    public class logistics_base_role_user_binding
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
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
        /// Userid
        /// </summary>		
        private long _userid;
        [JsonConverter(typeof(Long2StringConverter))]
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
    public class logistics_base_warehouse
    {
        public int Status { get; set; }
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
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
    public class logistics_customer_order_status
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// OrderID
        /// </summary>		
        private long _orderid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        /// <summary>
        /// OrderNo
        /// </summary>		
        private string _orderno;
        public string OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
        }
        /// <summary>
        /// currentStep
        /// </summary>		
        private string _currentstep;
        public string currentStep
        {
            get { return _currentstep; }
            set { _currentstep = value; }
        }
        /// <summary>
        /// userID
        /// </summary>		
        private long _userid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long userID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// currentStatus
        /// </summary>		
        private string _currentstatus;
        public string currentStatus
        {
            get { return _currentstatus; }
            set { _currentstatus = value; }
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

    public class logistics_customer_order
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// userid
        /// </summary>		
        private long _userid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// CustomerOrderNo
        /// </summary>		
        private string _customerorderno;
        public string CustomerOrderNo
        {
            get { return _customerorderno; }
            set { _customerorderno = value; }
        }
        /// <summary>
        /// expressNo
        /// </summary>		
        private string _expressno;
        public string expressNo
        {
            get { return _expressno; }
            set { _expressno = value; }
        }
        /// <summary>
        /// expressTypeID
        /// </summary>		
        private long _expresstypeid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long expressTypeID
        {
            get { return _expresstypeid; }
            set { _expresstypeid = value; }
        }
        /// <summary>
        /// expressTypeName
        /// </summary>		
        private string _expresstypename;
        public string expressTypeName
        {
            get { return _expresstypename; }
            set { _expresstypename = value; }
        }
        /// <summary>
        /// TransferNo
        /// </summary>		
        private string _transferno;
        public string TransferNo
        {
            get { return _transferno; }
            set { _transferno = value; }
        }
        /// <summary>
        /// InPackageCount
        /// </summary>		
        private decimal _inpackagecount;
        public decimal InPackageCount
        {
            get { return _inpackagecount; }
            set { _inpackagecount = value; }
        }
        /// <summary>
        /// InWeight
        /// </summary>		
        private decimal _inweight;
        public decimal InWeight
        {
            get { return _inweight; }
            set { _inweight = value; }
        }
        /// <summary>
        /// InVolume
        /// </summary>		
        private decimal _involume;
        public decimal InVolume
        {
            get { return _involume; }
            set { _involume = value; }
        }
        /// <summary>
        /// InLength
        /// </summary>		
        private decimal _inlength;
        public decimal InLength
        {
            get { return _inlength; }
            set { _inlength = value; }
        }
        /// <summary>
        /// InWidth
        /// </summary>		
        private decimal _inwidth;
        public decimal InWidth
        {
            get { return _inwidth; }
            set { _inwidth = value; }
        }
        /// <summary>
        /// InHeight
        /// </summary>		
        private decimal _inheight;
        public decimal InHeight
        {
            get { return _inheight; }
            set { _inheight = value; }
        }
        /// <summary>
        /// WareHouseID
        /// </summary>		
        private long _warehouseid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long WareHouseID
        {
            get { return _warehouseid; }
            set { _warehouseid = value; }
        }
        /// <summary>
        /// InWareHouseTime
        /// </summary>		
        private DateTime _inwarehousetime;
        public DateTime InWareHouseTime
        {
            get { return _inwarehousetime; }
            set { _inwarehousetime = value; }
        }
        /// <summary>
        /// CustomerServiceID
        /// </summary>		
        private long _customerserviceid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long CustomerServiceID
        {
            get { return _customerserviceid; }
            set { _customerserviceid = value; }
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
    public class logistics_customer_order_merge
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// MergeOrder
        /// </summary>		
        private string _mergeorder;
        public string MergeOrder
        {
            get { return _mergeorder; }
            set { _mergeorder = value; }
        }
        /// <summary>
        /// CustomerMark
        /// </summary>		
        private string _customermark;
        public string CustomerMark
        {
            get { return _customermark; }
            set { _customermark = value; }
        }
        /// <summary>
        /// CustomerChooseChannelID
        /// </summary>		
        private long _customerchoosechannelid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long CustomerChooseChannelID
        {
            get { return _customerchoosechannelid; }
            set { _customerchoosechannelid = value; }
        }
        /// <summary>
        /// InWeightTotal
        /// </summary>		
        private decimal _inweighttotal;
        public decimal InWeightTotal
        {
            get { return _inweighttotal; }
            set { _inweighttotal = value; }
        }
        /// <summary>
        /// InVolumeTotal
        /// </summary>		
        private decimal _involumetotal;
        public decimal InVolumeTotal
        {
            get { return _involumetotal; }
            set { _involumetotal = value; }
        }
        /// <summary>
        /// InPackageCountTotal
        /// </summary>		
        private decimal _inpackagecounttotal;
        public decimal InPackageCountTotal
        {
            get { return _inpackagecounttotal; }
            set { _inpackagecounttotal = value; }
        }
        /// <summary>
        /// recipient
        /// </summary>		
        private string _recipient;
        public string recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }
        /// <summary>
        /// country
        /// </summary>		
        private string _country;
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }
        /// <summary>
        /// address
        /// </summary>		
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// city
        /// </summary>		
        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; }
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
        /// tel
        /// </summary>		
        private string _tel;
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// company
        /// </summary>		
        private string _company;
        public string company
        {
            get { return _company; }
            set { _company = value; }
        }
        /// <summary>
        /// taxNo
        /// </summary>		
        private string _taxno;
        public string taxNo
        {
            get { return _taxno; }
            set { _taxno = value; }
        }
        /// <summary>
        /// declareTotal
        /// </summary>		
        private decimal _declaretotal;
        public decimal declareTotal
        {
            get { return _declaretotal; }
            set { _declaretotal = value; }
        }
        /// <summary>
        /// customerServiceMark
        /// </summary>		
        private string _customerservicemark;
        public string customerServiceMark
        {
            get { return _customerservicemark; }
            set { _customerservicemark = value; }
        }
        /// <summary>
        /// packageMark
        /// </summary>		
        private string _packagemark;
        public string packageMark
        {
            get { return _packagemark; }
            set { _packagemark = value; }
        }
        /// <summary>
        /// packageWeight
        /// </summary>		
        private decimal _packageweight;
        public decimal packageWeight
        {
            get { return _packageweight; }
            set { _packageweight = value; }
        }
        /// <summary>
        /// packageVolume
        /// </summary>		
        private decimal _packagevolume;
        public decimal packageVolume
        {
            get { return _packagevolume; }
            set { _packagevolume = value; }
        }
        /// <summary>
        /// packageLength
        /// </summary>		
        private decimal _packagelength;
        public decimal packageLength
        {
            get { return _packagelength; }
            set { _packagelength = value; }
        }
        /// <summary>
        /// packageHeight
        /// </summary>		
        private decimal _packageheight;
        public decimal packageHeight
        {
            get { return _packageheight; }
            set { _packageheight = value; }
        }
        /// <summary>
        /// packageWidth
        /// </summary>		
        private decimal _packagewidth;
        public decimal packageWidth
        {
            get { return _packagewidth; }
            set { _packagewidth = value; }
        }
        /// <summary>
        /// settlementWeight
        /// </summary>		
        private decimal _settlementweight;
        public decimal settlementWeight
        {
            get { return _settlementweight; }
            set { _settlementweight = value; }
        }
        /// <summary>
        /// freightFee
        /// </summary>		
        private decimal _freightfee;
        public decimal freightFee
        {
            get { return _freightfee; }
            set { _freightfee = value; }
        }
        /// <summary>
        /// tax
        /// </summary>		
        private decimal _tax;
        public decimal tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
        /// <summary>
        /// serviceFee
        /// </summary>		
        private decimal _servicefee;
        public decimal serviceFee
        {
            get { return _servicefee; }
            set { _servicefee = value; }
        }
        /// <summary>
        /// remoteFee
        /// </summary>		
        private decimal _remotefee;
        public decimal remoteFee
        {
            get { return _remotefee; }
            set { _remotefee = value; }
        }
        /// <summary>
        /// magneticinspectionFee
        /// </summary>		
        private decimal _magneticinspectionfee;
        public decimal magneticinspectionFee
        {
            get { return _magneticinspectionfee; }
            set { _magneticinspectionfee = value; }
        }
        /// <summary>
        /// totalFee
        /// </summary>		
        private decimal _totalfee;
        public decimal totalFee
        {
            get { return _totalfee; }
            set { _totalfee = value; }
        }
        /// <summary>
        /// ChannelID
        /// </summary>		
        private long _channelid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ChannelID
        {
            get { return _channelid; }
            set { _channelid = value; }
        }
        /// <summary>
        /// channelNo
        /// </summary>		
        private string _channelno;
        public string channelNo
        {
            get { return _channelno; }
            set { _channelno = value; }
        }
        /// <summary>
        /// deliverTime
        /// </summary>		
        private DateTime _delivertime;
        public DateTime deliverTime
        {
            get { return _delivertime; }
            set { _delivertime = value; }
        }
        /// <summary>
        /// AgentID
        /// </summary>		
        private long _agentid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long AgentID
        {
            get { return _agentid; }
            set { _agentid = value; }
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
    public class logistics_customer_order_merge_detail
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
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// mergeOrderID
        /// </summary>		
        private long _mergeorderid;
        public long mergeOrderID
        {
            get { return _mergeorderid; }
            set { _mergeorderid = value; }
        }
        /// <summary>
        /// productName
        /// </summary>		
        private string _productname;
        public string productName
        {
            get { return _productname; }
            set { _productname = value; }
        }
        /// <summary>
        /// HSCode
        /// </summary>		
        private string _hscode;
        public string HSCode
        {
            get { return _hscode; }
            set { _hscode = value; }
        }
        /// <summary>
        /// declareUnitPrice
        /// </summary>		
        private decimal _declareunitprice;
        public decimal declareUnitPrice
        {
            get { return _declareunitprice; }
            set { _declareunitprice = value; }
        }
        /// <summary>
        /// declareTotal
        /// </summary>		
        private decimal _declaretotal;
        public decimal declareTotal
        {
            get { return _declaretotal; }
            set { _declaretotal = value; }
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
    public class logistics_customer_order_merge_relation
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// mergeOrderID
        /// </summary>		
        private long _mergeorderid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long mergeOrderID
        {
            get { return _mergeorderid; }
            set { _mergeorderid = value; }
        }
        /// <summary>
        /// orderID
        /// </summary>		
        private long _orderid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long orderID
        {
            get { return _orderid; }
            set { _orderid = value; }
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
    public class logistics_customer_order_merge_status
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// mergeOrderID
        /// </summary>		
        private long _mergeorderid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long mergeOrderID
        {
            get { return _mergeorderid; }
            set { _mergeorderid = value; }
        }
        /// <summary>
        /// mergeeOrderNo
        /// </summary>		
        private string _mergeorderno;
        public string mergeOrderNo
        {
            get { return _mergeorderno; }
            set { _mergeorderno = value; }
        }
        /// <summary>
        /// currentStep
        /// </summary>		
        private string _currentstep;
        public string currentStep
        {
            get { return _currentstep; }
            set { _currentstep = value; }
        }
        /// <summary>
        /// currentStatus
        /// </summary>		
        private string _currentstatus;
        public string currentStatus
        {
            get { return _currentstatus; }
            set { _currentstatus = value; }
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
    public class logistics_recipient_address
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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
        /// country
        /// </summary>		
        private string _country;
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }
        /// <summary>
        /// address
        /// </summary>		
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// city
        /// </summary>		
        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; }
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
        /// tel
        /// </summary>		
        private string _tel;
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// companyName
        /// </summary>		
        private string _companyname;
        public string companyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }
        /// <summary>
        /// taxNo
        /// </summary>		
        private string _taxno;
        public string taxNo
        {
            get { return _taxno; }
            set { _taxno = value; }
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
        public long ModifiedBy
        {
            get { return _modifiedby; }
            set { _modifiedby = value; }
        }

    }
    public class logistics_base_message
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// message
        /// </summary>		
        private string _message;
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        /// <summary>
        /// userid
        /// </summary>		
        private long _userid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public int type
        {
            get; set;
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

    public class logistics_base_agent
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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
        /// tel
        /// </summary>		
        private string _tel;
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// mark
        /// </summary>		
        private string _mark;
        public string mark
        {
            get { return _mark; }
            set { _mark = value; }
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
    public class logistics_base_userinfo_log
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Userid
        /// </summary>		
        private long _userid;
        [JsonConverter(typeof(Long2StringConverter))]
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

    public class logistics_base_country
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// englishName
        /// </summary>		
        private string _englishname;
        public string englishName
        {
            get { return _englishname; }
            set { _englishname = value; }
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
        /// chineseName
        /// </summary>		
        private string _chinesename;
        public string chineseName
        {
            get { return _chinesename; }
            set { _chinesename = value; }
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

    public class logistics_base_userinfo_recipients_address
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Userid
        /// </summary>		
        private long _userid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// ProvinceID
        /// </summary>		
        private long _provinceid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ProvinceID
        {
            get { return _provinceid; }
            set { _provinceid = value; }
        }
        /// <summary>
        /// CityID
        /// </summary>		
        private long _cityid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long CityID
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        /// <summary>
        /// postalcode
        /// </summary>		
        private string _postalcode;
        public string postalcode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }
        /// <summary>
        /// Tel
        /// </summary>		
        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// Address
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
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

    public class logistics_base_sms_validate
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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

    public class logistics_base_navigation
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
        /// ID
        /// </summary>		

        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Name_CN
        /// </summary>		
        private string _name_cn;

        public string Name_CN
        {
            get { return _name_cn; }
            set { _name_cn = value; }
        }
        /// <summary>
        /// Name_EN
        /// </summary>		
        private string _name_en;
        public string Name_EN
        {
            get { return _name_en; }
            set { _name_en = value; }
        }
        /// <summary>
        /// Summary
        /// </summary>		
        private string _summary;
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        /// <summary>
        /// Image
        /// </summary>		
        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        /// <summary>
        /// Url
        /// </summary>		
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
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
        /// <summary>
        /// ParentID
        /// </summary>		
        private long _parentid;
        [JsonConverter(typeof(Long2StringConverter))]
        public long ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// SortID
        /// </summary>		
        private int _sortid;
        public int SortID
        {
            get { return _sortid; }
            set { _sortid = value; }
        }

        public string color { get; set; }
    }

    public class logistics_quotation_channel
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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

        public string WeightLimit { get; set; }
        public string SizeLimit { get; set; }
    }

    public class logistics_quotation_partition_ipf_price
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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
        [JsonConverter(typeof(Long2StringConverter))]
        public long channelID
        {
            get { return _channelid; }
            set { _channelid = value; }
        }
        /// <summary>
        /// partitionID
        /// </summary>		
        private long _partitionid;
        [JsonConverter(typeof(Long2StringConverter))]
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
    public class logistics_quotation_partition_price
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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
        [JsonConverter(typeof(Long2StringConverter))]
        public long channelID
        {
            get { return _channelid; }
            set { _channelid = value; }
        }
        /// <summary>
        /// partitionID
        /// </summary>		
        private long _partitionid;
        [JsonConverter(typeof(Long2StringConverter))]
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

    public class logistics_quotation_partition_country
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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
        [JsonConverter(typeof(Long2StringConverter))]
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
        [JsonConverter(typeof(Long2StringConverter))]
        public long ChannelID { get; set; }

    }

    public class logistics_quotation_partition
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
        /// ID
        /// </summary>		
        private long _id;
        [JsonConverter(typeof(Long2StringConverter))]
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

        public long ChannelID { get; set; }

    }
}
