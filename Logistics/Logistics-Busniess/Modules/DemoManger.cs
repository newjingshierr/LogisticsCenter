using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;
using Logistics_DAL;
using Logistics.Core;
using Akmii.Cache.Client;



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
            var model = MemcachedHelper.Instance().GetValue<demo>(AppModeEnum.Demo.ToString(), CacheConstants.GetDemoByID(item.ID, item.TenantID));
            if (model == null)
            {
                result = DemoDAL.GetItem(item);
                if (result != null)
                {

                    MemcachedHelper.Instance().SetValue(AppModeEnum.Demo.ToString(),
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

        public static bool DeleteDemoByID(DemoDeleteRequest item)
        {
            return DemoDAL.Delete(item);
        }

        public static bool UpdateDemoByID(DemoUpdateRequest item)
        {
            return DemoDAL.Update(item);
        }


    }
}
