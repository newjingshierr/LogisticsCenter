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
    public class DemoManger
    {
        public static List<demo> GetAllByName(DemoGetByNameRequest request, ref int totalCount)
        {
            return DemoDAL.GetAllByName(request, ref totalCount);

        }

        public static bool Insert(demo item)
        {
            item.ID = IdWorker.GetID();
            item.TenantID = IdWorker.GetID();
            item.CreatedBy = IdWorker.GetID();
            return DemoDAL.Insert(item);


        }

        public static bool BatchInsert(List<demo> request)
        {
            var dbresult = true;
            foreach (var o in request)
            {
                dbresult = dbresult && Insert(o);
            }
            return dbresult;
        }

        public static demo GetDemoByID(DemoGetRequest item)
        {
            var result = new demo();
            var model = MemcachedHelper.GetValue<demo>(AppModeEnum.Demo.ToString(), CacheConstants.GetDemoByID(item.ID, item.TenantID));
            if (model == null)
            {
                result = DemoDAL.GetItem(item);
                if (result != null)
                {

                    MemcachedHelper.SetValue<demo>(AppModeEnum.Demo.ToString(),
                        CacheConstants.GetDemoByID(item.ID, item.TenantID),
                        result, CacheConstants.GetDemoByIDTime());
                }
            }
            else
            {
                result = model;
            }
            return result;

        }

        public static demo GetDemoByIDCahced(DemoGetRequest item)
        {
            return GetDemoByIDCahced(item.ID, item.TenantID);
        }
        public static demo GetDemoByIDCahced(long ID, long TenantID, bool isCache = true, bool isWrite = false)
        {
            var key = CacheConstants.GetDemoByID(ID, TenantID);
            if (!isCache)
            {
                MemcachedHelper.Remove(key);
            }

            var result = MemcachedHelper.GetOrSet(key, () =>
            {
                var model = DemoDAL.GetItem(ID, TenantID);

                return model;

            }, CacheConstants.GetDemoByIDTime()).Result;
            return result;
        }

        public static bool DeleteDemoByID(DemoDeleteRequest item)
        {
            bool dbResult = false;
            dbResult = DemoDAL.Delete(item);
            if (dbResult)
            {
                GetDemoByIDCahced(item.ID, item.TenantID,false);
            }
            return dbResult;
        }

        public static bool UpdateDemoByID(DemoUpdateRequest item)
        {
            bool dbResult = false;
            dbResult = DemoDAL.Update(item);
            if (dbResult)
            {
                GetDemoByIDCahced(item.ID, item.TenantID, false);
            }
            return DemoDAL.Update(item);
        }


    }
}
