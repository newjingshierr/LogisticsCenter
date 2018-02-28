using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class WareHouseDAL
    {
        public static logistics_base_warehouse GetItem(long ID, long TenantID)
        {
            var result = new logistics_base_warehouse();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",ID),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_select_by_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_warehouse>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool Insert(logistics_base_warehouse model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                       new MySqlParameter("@_TotalVolumne", model.TotalVolumne),
                        new MySqlParameter("@_Status", model.status),
                        new MySqlParameter("@_code", model.code),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_Insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_Insert, parameters);
            }
            return result == 1;

        }
        public static bool Delete(long ID, AkmiiMySqlTransaction trans = null, long TenantID = BusinessConstants.Admin.TenantID)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID", TenantID),
                        new MySqlParameter("@_ID",ID),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_detete_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_detete_by_id, parameters);
            }
            return result == 1;

        }

        public static bool Update(logistics_base_warehouse model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                           new MySqlParameter("@_Status", model.status),
    new MySqlParameter("@_TotalVolumne", model.TotalVolumne),
                        new MySqlParameter("@_code", model.code),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_update_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_update_by_id, parameters);
            }
            return result == 1;

        }


        public static bool UpdateVolumne(long ID, decimal leftVolumne, AkmiiMySqlTransaction trans = null, long TenantID = BusinessConstants.Admin.TenantID)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", TenantID),
                        new MySqlParameter("@_ID",ID),
                        new MySqlParameter("@_leftVolumne", leftVolumne),
                        new MySqlParameter("@_ModifiedBy",TenantID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_update_volumne_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_update_volumne_by_id, parameters);
            }
            return result == 1;

        }

        public static List<logistics_base_warehouse> GetByPage(DemoGetByNameRequest request, ref int totalCount, AkmiiMySqlTransaction trans = null)
        {
            var list = new List<logistics_base_warehouse>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",""),
                 new MySqlParameter("@_CreatedBy",""),
                new MySqlParameter("@_PageIndex", request.PageIndex),
                new MySqlParameter("@_PageSize", request.PageSize),
                new MySqlParameter("_totalCount", totalCount) { Direction = ParameterDirection.Output }
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_select_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_base_warehouse>.DtToList(dbResult.Tables[0]);
            }


            return list;

        }

        public static List<logistics_base_warehouse> GetAll(long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_warehouse>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Warehouse.logistics_base_warehouse_select_all, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_warehouse>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }

        public static List<logistics_base_warehouse> GetIndex(string name ,long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_warehouse>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_name",name)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Warehouse.logistics_warehouse_select_index, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_warehouse>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}
