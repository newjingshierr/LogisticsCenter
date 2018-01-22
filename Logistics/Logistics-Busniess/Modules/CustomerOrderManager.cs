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
    public class CustomerOrderManager
    {
        public static List<logistics_customer_order> GetItemListByPage(CustomerOrderSelectRequest request,long userID, ref int totalCount)
        {
            return CustomerOrderDAL.GetItemListByPage(request.TenantID,  userID, request.PageIndex, request.PageSize, ref totalCount);

        }
    }
}
