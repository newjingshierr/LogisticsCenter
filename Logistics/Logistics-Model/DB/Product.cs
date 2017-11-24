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
    [Serializable]
    public class demo
    {
        [DataMember]
        [JsonConverter(typeof(Long2StringConverter))]
        public long TenantID { get; set; }

        [DataMember]
        [JsonConverter(typeof(Long2StringConverter))]
        public long ID { get; set; }
        [DataMember]

        public string Name { get; set; }

        [DataMember]
        [JsonConverter(typeof(DateTime2IOSStringConverter))]  
        public DateTime Created { get; set; }

        [DataMember]
        [JsonConverter(typeof(DateTime2IOSStringConverter))]
        public DateTime Modified { get; set; }

        [DataMember]
        [JsonConverter(typeof(Long2StringConverter))]
        public long CreatedBy { get; set; }

        [DataMember]
        [JsonConverter(typeof(Long2StringConverter))]
        public long ModifiedBy { get; set; }
    }
}
