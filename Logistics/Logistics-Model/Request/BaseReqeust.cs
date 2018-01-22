using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class BaseRequest
    {
        public long TenantID { get; set; } = 890501594632818690;
    }
    public class BaseRequestPage:BaseRequest
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }

    public class GetItemListByUserIDRequest : BaseRequest
    {
        public long userID { get; set; }
    }





    #region systembase
    //message
    public class GetItemListByPageRequest : BaseRequestPage
    {

    }

    #endregion


}
