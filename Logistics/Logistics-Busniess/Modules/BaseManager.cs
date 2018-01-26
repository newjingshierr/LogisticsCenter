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
    public class MessageManager
    {
        public static List<logistics_base_message> GetMessageListByLatest(long userID)
        {
            return MessageDal.GetItemListByLatest(userID);
        }

        public static List<logistics_base_message> GetMessageListByPage(GetItemListByPageRequest request, long userID, ref int totalCount)
        {
            return MessageDal.GetItemListByPage(request.PageIndex, request.PageSize, userID, ref totalCount);
        }

        public static bool InsertMessage(MessageInsertRequest item)
        {
            logistics_base_message message = new logistics_base_message();
            message.ID = IdWorker.GetID();
            message.TenantID = BusinessConstants.Admin.TenantID;
            message.type = (int)item.type;
            message.message = item.message;
            message.userid = item.userid;

            return MessageDal.Insert(message);
        }

    }

    public class ExpressTypeManger
    {
        public static List<logistics_base_express_type> GetAll()
        {
            return ExpressDAL.GetAll();
        }

        public static List<logistics_base_express_type> GetIndex(GetExpressTypeIndexRequest request)
        {
            return ExpressDAL.GetIndex(request.name);
        }
    }

    public class WarehouseManger
    {

        public static List<logistics_base_warehouse> GetAll()
        {
            return WareHouseDAL.GetAll();
        }

        public static List<logistics_base_warehouse> GetIndex(GetWarehouseIndexRequest request)
        {
            return WareHouseDAL.GetIndex(request.name);
        }
    }
}
