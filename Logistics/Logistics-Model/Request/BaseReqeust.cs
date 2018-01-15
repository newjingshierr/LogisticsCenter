using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class BaseReqeust
    {
        public long TenantID { get; set; } = 890501594632818690;
    }

    public class GetItemListByUserIDRequest : BaseReqeust
    {
        public long userID { get; set; }
    }



}
