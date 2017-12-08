using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class SmsValidateDal
    {
        public static bool Insert(logistics_base_sms_validate model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@TenantID",model.TenantID) ,
                        new MySqlParameter("@ID", model.ID) ,
                        new MySqlParameter("@tel", model.tel) ,
                        new MySqlParameter("@code", model.code) ,
                        new MySqlParameter("@startTime", model.startTime) ,
                        new MySqlParameter("@endTime", SqlDbType.DateTime) ,
                        new MySqlParameter("@CreatedBy",model.Created),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_sms_validate_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Base.logistics_base_sms_validate_insert, parameters);
            }
            return result == 1;

        }

        public static logistics_base_sms_validate ChekcItem(long TenantID, string tel, string code, DateTime startTime, DateTime endTime)
        {
            var result = new logistics_base_sms_validate();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                 new MySqlParameter("@_Tel", tel),
                  new MySqlParameter("@_codel", code),
                  new MySqlParameter("@_startTime", startTime),
                   new MySqlParameter("@_endTime", endTime),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetReadConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_sms_validate_select, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_sms_validate>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }
        public static logistics_base_sms_validate GetItem(long TenantID, string tel)
        {
            var result = new logistics_base_sms_validate();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                 new MySqlParameter("@_Tel", tel)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetReadConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_sms_validate_select, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_sms_validate>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }
    }

}
