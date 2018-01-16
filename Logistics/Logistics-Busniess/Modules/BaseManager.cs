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
    public class BaseManager
    {
        public static List<logistics_base_message> GetItemListByLatest(long userID)
        {
            return MessageDal.GetItemListByLatest(userID);
        }

        public static List<logistics_base_message> GetItemListByPage(GetItemListByPageRequest request,long userID,ref int totalCount)
        {
            return MessageDal.GetItemListByPage(request.PageIndex,request.PageSize,userID,ref totalCount);
        }
    }
}
