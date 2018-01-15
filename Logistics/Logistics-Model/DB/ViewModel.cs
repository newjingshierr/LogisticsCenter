using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Akmii;

namespace Logistics_Model
{
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


    public class CurrentInfo
    {
        public UserInfo userInfo { get; set; }
        public logistics_base_role role { get; set; }
        public List<logistics_base_navigation> navigations { get; set; }
    }

}
