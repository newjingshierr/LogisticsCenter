using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;
using Akmii;

namespace Logistics_DAL
{
    public class MessageDal : DalBase
    {
        public static bool logistics_base_message_delete(long ID, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID",BusinessConstants.Admin.TenantID),
                        new MySqlParameter("@_ID",ID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_message_delete, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Base.logistics_base_message_delete, parameters);
            }
            return result == 1;

        }
        public static List<logistics_base_message> GetItemListByPage(int pageIndex, int pageSize, int type, long userid, ref int totalCount, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_message>();
            var total = new MySqlParameter("@_TotalCount", totalCount) { Direction = ParameterDirection.Output };

            MySqlParameter[] parameters = {
                new MySqlParameter("@_userID",userid),
                   new MySqlParameter("@_messageType",type),
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_PageIndex", pageIndex),
                new MySqlParameter("@_PageSize", pageSize),
                total
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_message_select_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_message>.DtToList(dbResult.Tables[0]);
                totalCount = (total.Value + "").Convert2Int32();
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
                new MySqlParameter("@_userid",userid),
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
        public static List<logistics_base_message> GetSystemMessagesByLatest(long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_message>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_system_message_select_by_latest, parameters);
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
                          new MySqlParameter("@_type",model.type),
                          new MySqlParameter("@_status", model.status),
                          new MySqlParameter("@_title", model.message),
                        new MySqlParameter("@_message", model.message),
                        new MySqlParameter("@_IsRead", model.IsRead),
                          new MySqlParameter("@_userid", model.userid),
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

        public static bool InsertList(List<logistics_base_message> modelList, AkmiiMySqlTransaction trans = null)
        {

            var result = true;
            if (modelList != null)
            {
                foreach (var o in modelList)
                {
                    result = result && Insert(o, trans);
                }
            }
            return result;

        }

        public static bool Update(logistics_base_message model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                          new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_status", model.status),
                         new MySqlParameter("@_title", model.title),
                          new MySqlParameter("@_message", model.message),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_message_update, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Base.logistics_base_message_update, parameters);
            }
            return result == 1;

        }

        public static int UnReadMessageCount(long userid, long TenantID = BusinessConstants.Admin.TenantID)
        {

            MySqlParameter[] parameters = {
                          new MySqlParameter("@_TenantID",TenantID),
                        new MySqlParameter("@_userid",userid),
            };

            var result = AkmiiMySqlHelper.ExecuteScalar(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_message_unread, parameters);
            return Convert.ToInt32(result);

        }

        public static bool logistics_base_message_unread_update(long userid, long TenantID = BusinessConstants.Admin.TenantID, AkmiiMySqlTransaction trans = null)
        {
            MySqlParameter[] parameters = {
                          new MySqlParameter("@_TenantID", TenantID),
                        new MySqlParameter("@_userid",userid),
                        new MySqlParameter("@_ModifiedBy",userid)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_message_unread_update, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Base.logistics_base_message_unread_update, parameters);
            }
            return result > 1;
        }

    }
}
