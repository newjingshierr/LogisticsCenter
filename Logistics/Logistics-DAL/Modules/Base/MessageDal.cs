using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL.Modules.Base
{
    public class MessageDal : DalBase
    {

        public static demo GetItem(long ID, long TenantID)
        {
            var result = new demo();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",ID),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Demo.Demo_Select_By_ID, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<demo>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

    }
}
