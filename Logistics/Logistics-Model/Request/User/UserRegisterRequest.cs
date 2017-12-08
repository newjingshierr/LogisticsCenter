using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class UserRegisterRequest : BaseReqeust
    {
        public string Email { get; set; } = "";
        public string Tel { get; set; } = "";

        public string Pwd { get; set; } = "";
    }
    public class UserCheckRequest : BaseReqeust
    {
        public long TenantID { get; set; }
        public long userID { get; set; }
        public string Pwd { get; set; }
    }
}
