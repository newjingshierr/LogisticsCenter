using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;
using Logistics.Core;
using Akmii.Cache.Client;
using Logistics_DAL;
using Logistics.Common;

namespace Logistics_Busniess
{
    public class MessagerManager
    {
        public static List<logistics_base_message> GetItemListByUserID(GetItemListByUserIDRequest request)
        {
            return MessageDal.GetItemListByUserID(request.userID, request.TenantID);
        }
    }
}
