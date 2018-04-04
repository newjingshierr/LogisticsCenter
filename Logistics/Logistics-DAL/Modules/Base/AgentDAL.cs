using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class AgentDAL
    {
        public static logistics_base_agent GetModel(long ID, long TenantID)
        {
            var result = new logistics_base_agent();
            MySqlParameter[] parameters = {

                new MySqlParameter("@_TenantID", TenantID),
                     new MySqlParameter("@_ID",ID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_GetModel, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_agent>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool Insert(logistics_base_agent model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_name", model.Name),
                         new MySqlParameter("@_tel", model.tel),
                          new MySqlParameter("@_mark", model.mark),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_ADD, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_ADD, parameters);
            }
            return result == 1;

        }
        public static bool Delete(long ID, long TenantID = BusinessConstants.Admin.TenantID, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID", TenantID),
                        new MySqlParameter("@_ID",ID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_Delete, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_Delete, parameters);
            }
            return result == 1;

        }

        public static bool Update(logistics_base_agent model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                          new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_name", model.Name),
                         new MySqlParameter("@_tel", model.tel),
                          new MySqlParameter("@_mark", model.mark),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_Update, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_Update, parameters);
            }
            return result == 1;

        }

        public static List<logistics_base_agent> GetByPage(long TenantID, long ID, string name, string tel, int pageIndex, int pageSize, ref int totalCount, AkmiiMySqlTransaction trans = null)
        {
            var list = new List<logistics_base_agent>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                 new MySqlParameter("@_ID",ID == null?0:ID),
                 new MySqlParameter("@_name",name == null ? "":name),
                new MySqlParameter("@_tel", tel == null ?"":tel),
                new MySqlParameter("@_PageIndex", pageIndex),
                 new MySqlParameter("@_PageSize", pageSize),
                new MySqlParameter("_totalCount", totalCount) { Direction = ParameterDirection.Output }
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_list_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_base_agent>.DtToList(dbResult.Tables[0]);
            }

            return list;

        }


        public static List<logistics_base_agent> GetIndex(long TenantID, string name)
        {
            var list = new List<logistics_base_agent>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                 new MySqlParameter("@_name",name == null ?"": name),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Agent.logistics_base_agent_select_index, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_base_agent>.DtToList(dbResult.Tables[0]);
            }

            return list;

        }

    }
}
