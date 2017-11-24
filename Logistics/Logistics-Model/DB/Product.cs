using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Akmii;

namespace Logistics_Model
{
    public class demo
    {
        [JsonConverter(typeof(Long2StringConverter))]
        public long TenantID { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(DateTime2IOSStringConverter))]
        public DateTime Created { get; set; }
        [JsonConverter(typeof(DateTime2IOSStringConverter))]
        public DateTime Modified { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long CreatedBy { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long ModifiedBy { get; set; }
    }
}
