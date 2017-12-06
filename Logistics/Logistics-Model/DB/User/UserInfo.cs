using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class UserInfo
    {
        public string Email { get; set; }

        public string Tel { get; set; }
        public string UserName { get; set; }

        public long Userid { get; set; }

        public string Pwd { get; set; }

        public string Token { get; set; }

        public string MemeberCode { get; set; }

        public string LastLoginTime { get; set; }

        public DateTime Created { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

    }
}
