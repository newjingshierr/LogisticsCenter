using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;


namespace Logistics_DAL
{
    public class ExpressDAL
    {
        public static List<logistics_base_express_type> GetAll(long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_express_type>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.ExpressType.logistics_base_express_type_select_all, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_express_type>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }



    }
}
