using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class DemoBatchInsert
    {
        public List<demo> demos { get; set; }
    }
    public class DemoGetByNameRequest
    {
        public string name { get; set; } = "";

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }

    public class DemoGetRequest
    {
        public long ID { get; set; } = 0L;
        public long TenantID { get; set; } = 0L;
    }
    public class DemoDeleteRequest
    {
        public long ID { get; set; } = 0L;
        public long TenantID { get; set; } = 0L;
    }


    public class DemoDeleteBatchRequest
    {
        List<DemoDeleteRequest> requests { get; set; }
    }

    public class DemoUpdateRequest
    {
        public long ID { get; set; } = 0L;
        public string name { get; set; } = "";
        public long TenantID { get; set; } = 0L;
    }

    public class DemoUpdateBatchRequest
    {
        public List<DemoUpdateRequest> requests { get; set; }
    }

}
