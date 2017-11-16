using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model.Constants
{
    public class CacheConstants
    {
        public static string GetBudgetTemplateByCodeKey(long userID, string code)
        {
            return $"Budget_Template_{userID}_{code.Trim()}";
        }

        /*用户信息*/

        public static string GetUserInformationByUserID(long userID)
        {
            return $"User_Information_{userID}";
        }
    }
}
