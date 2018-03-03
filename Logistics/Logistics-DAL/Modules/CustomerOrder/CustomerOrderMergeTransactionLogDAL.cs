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
  public  class CustomerOrderMergeTransactionLogDAL
    {
        public static logistics_customer_order_merge_transaction_log GetCustomerOrderMeregeTranscationLogModel(long ID, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new logistics_customer_order_merge_transaction_log();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_ID", ID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_transaction_log_GetModel, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order_merge_transaction_log>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }


        public static List<logistics_customer_order> GetItemListByPage(long TenantID, long userID, long warehouseAdmin, string customerOrderNo, int customerOrderStatus,
            string expressNo,
                long expressTypeID,
                    string TransferNo,
                        long warehouseID,
                            DateTime InWarehouseTimeBegin,
                            DateTime InWarehouseTimeEnd,
                                long CustomerServiceID,
                                    int PageIndex,
                                         int PageSize,
                                            ref int totalCount)
        {
            var result = new List<logistics_customer_order>();
            var total = new MySqlParameter("@_TotalCount", totalCount) { Direction = ParameterDirection.Output };

            MySqlParameter[] parameters = {
                                new MySqlParameter("@_TenantID", TenantID),
                                     new MySqlParameter("@_userID", userID),
                                        new MySqlParameter("@_warehouseAdmin",warehouseAdmin),
                                         new MySqlParameter("@_customerOrderNo", customerOrderNo == null ?"":customerOrderNo),
                                             new MySqlParameter("@_customerOrderStatus", customerOrderStatus),
                                              new MySqlParameter("@_expressNo", expressNo == null ?"":expressNo),
                                                new MySqlParameter("@_expressTypeID", expressTypeID),
                                                    new MySqlParameter("@_TransferNo", TransferNo == null ? "":TransferNo),
                                                         new MySqlParameter("@_warehouseID", warehouseID),
                                                            new MySqlParameter("@_InWarehouseTimeBegin", InWarehouseTimeBegin.ConvertDBTime()),
                                                                 new MySqlParameter("@_InWarehouseTimeEnd", InWarehouseTimeEnd.ConvertDBTime()),
                                                                    new MySqlParameter("@_CustomerServiceID", CustomerServiceID),
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


        public static bool Insert(logistics_customer_order_merge_transaction_log model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_TransationID", model.TransationID),
                        new MySqlParameter("@_CustomerOrderMergeID",model.CustomerOrderMergeID),
                        new MySqlParameter("@_CustomerOrderMergeNo",model.CustomerOrderMergeNo),
                        new MySqlParameter("@_Comment",model.Comment),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_transaction_log_ADD, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_transaction_log_ADD, parameters);
            }
            return result == 1;

        }


        public static bool Update(logistics_customer_order_merge_transaction_log model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_TransationID", model.TransationID),
                        new MySqlParameter("@_CustomerOrderMergeID",model.CustomerOrderMergeID),
                        new MySqlParameter("@_CustomerOrderMergeNo",model.CustomerOrderMergeNo),
                        new MySqlParameter("@_Amount",model.Amount),
                        new MySqlParameter("@_DataSource",model.DataSource),
                        new MySqlParameter("@_Comment",model.Comment),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_transaction_log_Update, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_transaction_log_Update, parameters);
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
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_transaction_log_Delete, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_transaction_log_Delete, parameters);
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
    }
}
