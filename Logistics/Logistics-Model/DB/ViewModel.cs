using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Akmii;

namespace Logistics_Model
{
    public class CustomerOrderMergeVM
    {
        public string currentStatus { get; set; }

        public string currentStep { get; set; }
        /// <summary>
        /// TenantID
        /// </summary>		
        public long _tenantid;
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
        [JsonConverter(typeof(Long2StringConverter))]
        public long UserID { get; set; }
        /// <summary>
        /// MergeOrder
        /// </summary>		
        private string _mergeorderno;
        public string MergeOrderNo
        {
            get { return _mergeorderno; }
            set { _mergeorderno = value; }
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
        //视图所用
        public string CustomerChooseChannelName { get; set; }
        public string ChannelName { get; set; }
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

    public class QuotationPriceVM
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
    public class QuotationChannelPriceVM
    {
        /// <summary>
        /// 渠道ID
        /// </summary>
        public long channelID { get; set; }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public String channelName { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        public decimal weight { get; set; }

        //时效
        public string Prescription { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        public decimal ServiceAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 条款
        /// </summary>
        public string Clause { get; set; }

        /// <summary>
        /// 重量限制
        /// </summary>
        public string WeightLimit { get; set; }

        /// <summary>
        /// 尺寸限制
        /// </summary>
        public string SizeLimit { get; set; }
    }

    public class QuotationIPFPriceVM
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

    public class AllUserInfo
    {
        public UserInfo userInfo { get; set; }
        public logistics_base_role role { get; set; }

        public string ticket { get; set; }

    }


    public class ContextInfo
    {
        public UserInfo userInfo { get; set; }
        public logistics_base_role role { get; set; }
        public List<NavigationView> navigations { get; set; }
    }

    public class NavigationView
    {
        public logistics_base_navigation parentItem { get; set; }
        public List<logistics_base_navigation> childItems { get; set; }
    }


    public class OrderStatusSummaryView
    {
        /// <summary>
        /// 等待客服打包提交打包
        /// </summary>
        public int waitForCustomerPackgeCount { get; set; }
        /// <summary>
        ///等待客户付款
        /// </summary>
        public int waitForPayCount { get; set; }
        /// <summary>
        /// 已发货
        /// </summary>
        public int DeliveryDoneCount { get; set; }
    }

}
