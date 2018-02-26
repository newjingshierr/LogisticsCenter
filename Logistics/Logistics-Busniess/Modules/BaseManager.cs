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
    public class FileManager
    {
        public static List<logistics_base_attachment> GetAttachmentListByCustomerOrderID(long customerOrderID)
        {
            return AttachmentDAL.GetAttachmentListByCustomerOrderID(customerOrderID);
        }

        public static long Insert(string path,long userid)
        {
            logistics_base_attachment file = new logistics_base_attachment();
            file.ID = IdWorker.GetID();
            file.TenantID = BusinessConstants.Admin.TenantID;
            file.path = path;
            file.CreatedBy = userid;
            file.customerOrderID = 0L;
            file.customerOrderNo = "";
            var result = false;
            result = AttachmentDAL.Insert(file);

            if (result)
            {
                return file.ID;
            }
            else
            {
                return 0;
            }
        }

        public static bool update(long customerOrderID, string customerOrderNo,long userid)
        {
            logistics_base_attachment file = new logistics_base_attachment();
            file.TenantID = BusinessConstants.Admin.TenantID;
            file.customerOrderID = customerOrderID;
            file.customerOrderNo = customerOrderNo;
            file.ModifiedBy = userid;
            return AttachmentDAL.Update(file);
        }
        public static bool DeleteByID(long fileID)
        {
            logistics_base_attachment file = new logistics_base_attachment();
            file.TenantID = BusinessConstants.Admin.TenantID;
            file.ID = fileID;
            return AttachmentDAL.Delete(file);
        }

    }

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

    public class RecipientsAddressManager
    {

        public static logistics_base_recipients_address GetItem(RecipientsAddressGetRequest request)
        {
            return RecipientsAddressDAL.GetItem(request.id);

        }
        public static List<logistics_base_recipients_address> GetAll(RecipientsAddressGetAllRequest request)
        {
            return RecipientsAddressDAL.GetAll(request.userid);
        }

        public static bool Insert(RecipientsAddressInsertRequest item,long userid)
        {
            logistics_base_recipients_address address = new logistics_base_recipients_address();
            address.ID = IdWorker.GetID();
            address.recipient = item.recipient;
            address.TenantID = BusinessConstants.Admin.TenantID;
            address.Userid = userid;
            address.country = item.country;
            address.postalcode = item.postalcode;
            address.Tel = item.Tel;
            address.taxno = item.taxno;
            address.City = item.City;
            address.companyName = item.companyName;
            address.Address = item.Address;
            address.CreatedBy = BusinessConstants.Admin.TenantID;
            return RecipientsAddressDAL.Insert(address);
        }

        public static bool update(RecipientsAddressUpdateRequest item)
        {
            logistics_base_recipients_address address = new logistics_base_recipients_address();
            address.ID = item.id;
            address.TenantID = BusinessConstants.Admin.TenantID;
            address.Userid = item.userid;
            address.recipient = item.recipient;
            address.country = item.country;
            address.postalcode = item.postalcode;
            address.Tel = item.Tel;
            address.taxno = item.taxno;
            address.companyName = item.companyName;
            address.Address = item.Address;
            address.CreatedBy = BusinessConstants.Admin.TenantID;
            return RecipientsAddressDAL.Update(address);
        }

        public static bool DeleteByID(RecipientsAddressDeleteRequest item)
        {
            return RecipientsAddressDAL.Delete(item.id);
           
        }


    }
}
