using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;


namespace Logistics_DAL
{
    public class TokenDAL
    {
        public static logistics_base_token_log GetItem(long userid)
        {
            var result = new logistics_base_token_log();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_userid",userid),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.TokenLog.logistics_base_token_log_select_by_user_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_token_log>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool Insert(logistics_base_token_log model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_token", model.token),
                         new MySqlParameter("@_userid", model.Userid),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.TokenLog.logistics_base_token_log_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.TokenLog.logistics_base_token_log_insert, parameters);
            }
            return result == 1;

        }
        public static bool Delete(long userid, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_userid", userid)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.TokenLog.logistics_base_token_log_delete_by_user_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.TokenLog.logistics_base_token_log_delete_by_user_id, parameters);
            }
            return result == 1;

        }

    }
}
