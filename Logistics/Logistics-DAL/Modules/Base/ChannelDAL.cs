using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class ChannelDAL
    {
        public static logistics_quotation_channel GetItem(long ID, long TenantID)
        {
            var result = new logistics_quotation_channel();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",ID),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Channel.logistics_quotation_channel_select_by_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_quotation_channel>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool Insert(logistics_base_channel model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_name", model.Name),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Channel.logistics_base_channel_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Channel.logistics_base_channel_insert, parameters);
            }
            return result == 1;

        }
        public static bool Delete(logistics_base_channel model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Channel.logistics_base_channel_delete_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Channel.logistics_base_channel_delete_by_id, parameters);
            }
            return result == 1;

        }

        public static bool Update(logistics_base_channel model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                          new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_name", model.Name),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Channel.logistics_base_channel_update_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Channel.logistics_base_channel_update_by_id, parameters);
            }
            return result == 1;

        }

        public static List<logistics_base_channel> GetByPage(DemoGetByNameRequest request, ref int totalCount, AkmiiMySqlTransaction trans = null)
        {
            var list = new List<logistics_base_channel>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",""),
                 new MySqlParameter("@_CreatedBy",""),
                new MySqlParameter("@_PageIndex", request.PageIndex),
                new MySqlParameter("@_PageSize", request.PageSize),
                new MySqlParameter("_totalCount", totalCount) { Direction = ParameterDirection.Output }
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_list_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_base_channel>.DtToList(dbResult.Tables[0]);
            }


            return list;

        }
    }
}
