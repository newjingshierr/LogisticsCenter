using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;

namespace Logistics.Core
{
    public class Authentication
    {
        public static UserInformation userInformation { get; set; }

        public Authentication(long userid)
        {
            userInformation = MemoryCacher.GetValue<UserInformation>(CacheConstants.GetUserInformationByUserID(userid));
        }
    }
}
