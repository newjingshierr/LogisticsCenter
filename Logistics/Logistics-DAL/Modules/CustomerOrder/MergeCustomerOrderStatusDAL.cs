﻿using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;
using Akmii;

namespace Logistics_DAL
{
    public class MergeCustomerOrderStatusDAL
    {
        public static List<logistics_customer_order> GetItemListByPage(long TenantID, long userID, int PageIndex, int PageSize, ref int totalCount)
        {
            var result = new List<logistics_customer_order>();
            var total = new MySqlParameter("@_TotalCount", totalCount) { Direction = ParameterDirection.Output };

            MySqlParameter[] parameters = {
                                new MySqlParameter("@_TenantID", TenantID),
                                new MySqlParameter("@_userID", userID),
                               new MySqlParameter("@_PageIndex", PageIndex),
                               new MySqlParameter("@_PageSize", PageSize),
                                total
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_select_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order>.DtToList(dbResult.Tables[0]);
                totalCount = (total.Value + "").Convert2Int32();
            }
            else
            {
                result = null;
            }

            return result;
        }

        public static bool InsertList(List<logistics_customer_order_merge_relation> relationList, AkmiiMySqlTransaction trans = null)
        {
            bool result = true;
            //foreach (var d in relationList)
            //{
            //    result = result && Insert(d, trans);
            //}
            return result;
        }


        public static bool Insert(logistics_customer_order_merge_status model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                         new MySqlParameter("@_mergeOrderID",model.mergeOrderID),
                        new MySqlParameter("@_MergeOrderNo", model.mergeOrderNo),
                         new MySqlParameter("@_currentStatus", model.currentStatus),
                         new MySqlParameter("@_currentStep", model.currentStep),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_insert, parameters);
            }
            return result == 1;

        }


        public static bool UpdateList(List<logistics_customer_order_merge_status> relationList, AkmiiMySqlTransaction trans = null)
        {
            bool result = true;
            foreach (var d in relationList)
            {
                result = result && Update(d, trans);
            }
            return result;
        }

        public static bool Update(logistics_customer_order_merge_status model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                         new MySqlParameter("@_currentStep",model.currentStep),
                        new MySqlParameter("@_currentStatus", model.currentStatus),
                        new MySqlParameter("@_ModifiedBy",model.CreatedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_Update, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_Update, parameters);
            }
            return result == 1;

        }


        public static bool Delete(long TenantID, long ID, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID",TenantID),
                        new MySqlParameter("@_ID",ID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_delete_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_delete_by_id, parameters);
            }
            return result == 1;

        }


        public static bool DeleteByMergeID( long meregeID, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_MergeID",meregeID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_delete_by_merge_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_delete_by_merge_id, parameters);
            }
            return result == 1;

        }


        public static List<logistics_customer_order> SelectCustomerOrderExpressIndex(string Name, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_customer_order>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_Name",Name)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_express_index, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }


        public static List<logistics_customer_order> SelectCustomerOrderIndex(string Name, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_customer_order>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_Name",Name)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_index, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }


        public static logistics_customer_order_merge_status GetItem(long customerOrderMergeID, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new logistics_customer_order_merge_status();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_mergeOrderID", customerOrderMergeID),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_select_by_merge_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order_merge_status>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }

    }
}
