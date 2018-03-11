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
    public class CustomerOrderMergeBalanceDAL
    {
        public static logistics_customer_order_merge_balance GetMergeBalanceModel(long ID, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new logistics_customer_order_merge_balance();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_BalanceID", ID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_GetModel, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order_merge_balance>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }
        public static logistics_customer_order_merge_balance GetMergeBalanceModelByOrderMergeID(long CustomerOrderMergeID, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new logistics_customer_order_merge_balance();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_CustomerOrderMergeID", CustomerOrderMergeID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_GetModel_By_MergeID, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order_merge_balance>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }


        public static List<logistics_customer_order_merge_balance> logistics_customer_order_merge_balance_GetList(long TenantID, int PageIndex, int PageSize, ref int totalCount)
        {
            var result = new List<logistics_customer_order_merge_balance>();
            var total = new MySqlParameter("@_TotalCount", totalCount) { Direction = ParameterDirection.Output };

            MySqlParameter[] parameters = {
                                new MySqlParameter("@_TenantID", TenantID),
                               new MySqlParameter("@_PageIndex", PageIndex),
                               new MySqlParameter("@_PageSize", PageSize),
                                total
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_GetList, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order_merge_balance>.DtToList(dbResult.Tables[0]);
                totalCount = (total.Value + "").Convert2Int32();
            }
            else
            {
                result = null;
            }

            return result;
        }


        public static bool Insert(logistics_customer_order_merge_balance model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_BalanceID",model.BalanceID),
                          new MySqlParameter("@_CustomerOrderMergeID",model.CustomerOrderMergeID),
                        new MySqlParameter("@_UserID",model.UserID),
                        new MySqlParameter("@_AgentID",model.AgentID),
                        new MySqlParameter("@_Amount",model.Amount),
                        new MySqlParameter("@_RemainAmount",model.RemainAmount),
                        new MySqlParameter("@_type",model.type),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.CreatedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_ADD, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_ADD, parameters);
            }
            return result == 1;

        }


        public static bool Update(logistics_customer_order_merge_balance model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_BalanceID",model.BalanceID),
                        new MySqlParameter("@_CustomerOrderMergeID", model.CustomerOrderMergeID),
                        new MySqlParameter("@_UserID",model.UserID),
                        new MySqlParameter("@_Amount",model.Amount),
                        new MySqlParameter("@_RemainAmount",model.RemainAmount),
                        new MySqlParameter("@_type",model.type),
                        new MySqlParameter("@_ModifiedBy",model.CreatedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_Update, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_Update, parameters);
            }
            return result == 1;

        }

        public static bool Delete(long TenantID, long ID, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID",TenantID),
                        new MySqlParameter("@_BalanceID",ID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_Delete, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_balance_Delete, parameters);
            }
            return result == 1;

        }
    }
}
