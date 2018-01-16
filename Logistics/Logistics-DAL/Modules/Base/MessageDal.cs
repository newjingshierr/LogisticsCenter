using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class MessageDal : DalBase
    {
        public static List<logistics_base_message> GetItemListByPage(int pageIndex, int pageSize, long userid, ref int totalCount, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_message>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_userID",userid),
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_PageIndex", pageIndex),
                new MySqlParameter("@_PageSize", pageSize),
                new MySqlParameter("_totalCount", totalCount) { Direction = ParameterDirection.Output }
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_message_select_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_message>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }

        public static List<logistics_base_message> GetItemListByLatest(long userid, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_message>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",userid),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_message_select_by_latest, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_message>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }

        public static bool Insert(logistics_base_message model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_message", model.message),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_message_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Base.logistics_base_message_insert, parameters);
            }
            return result == 1;

        }




    }
}
