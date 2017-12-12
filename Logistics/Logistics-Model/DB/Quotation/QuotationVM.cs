using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// firstHeavy
        /// </summary>		
        private decimal _firstheavy;
        public decimal firstHeavy
        {
            get { return _firstheavy; }
            set { _firstheavy = value; }
        }
        /// <summary>
        /// continuedHeavy
        /// </summary>		
        private decimal _continuedheavy;
        public decimal continuedHeavy
        {
            get { return _continuedheavy; }
            set { _continuedheavy = value; }
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
        public int type { get; set; }

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
    }
}
