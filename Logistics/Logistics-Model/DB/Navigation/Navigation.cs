using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Akmii;

namespace Logistics_Model
{
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

    }
}
