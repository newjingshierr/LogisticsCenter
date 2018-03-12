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
    public class CustomerOrderDAL
    {
        public static logistics_customer_order GetCustomerOrderByID(long ID, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new logistics_customer_order();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_ID", ID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_select_by_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order>.DtToModel(dbResult.Tables[0]);
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


        public static bool Insert(logistics_customer_order model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_userid", model.userid),
                        new MySqlParameter("@_CustomerOrderNo",model.CustomerOrderNo),
                        new MySqlParameter("@_expressNo",model.expressNo),
                        new MySqlParameter("@_expressTypeID",model.expressTypeID),
                        new MySqlParameter("@_expressTypeName",model.expressTypeName),
                        new MySqlParameter("@_TransferNo",model.TransferNo),
                        new MySqlParameter("@_InPackageCount",model.InPackageCount),
                        new MySqlParameter("@_InWeight",model.InWeight),
                        new MySqlParameter("@_InVolume",model.InVolume),
                        new MySqlParameter("@_InLength",model.InLength),
                        new MySqlParameter("@_InWidth",model.InWidth),
                        new MySqlParameter("@_InHeight",model.InHeight),
                        new MySqlParameter("@_WareHouseID",model.WareHouseID),
                        new MySqlParameter("@_CustomerServiceID",model.CustomerServiceID),
                         new MySqlParameter("@_WarehouseAdminRemark",model.WarehouseAdminRemark),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_insert, parameters);
            }
            return result == 1;

        }


        public static bool Update(logistics_customer_order model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_userid", model.userid),
                        new MySqlParameter("@_expressNo",model.expressNo),
                        new MySqlParameter("@_expressTypeID",model.expressTypeID),
                        new MySqlParameter("@_expressTypeName",model.expressTypeName),
                        new MySqlParameter("@_TransferNo",model.TransferNo),
                        new MySqlParameter("@_InPackageCount",model.InPackageCount),
                        new MySqlParameter("@_InWeight",model.InWeight),
                        new MySqlParameter("@_InVolume",model.InVolume),
                        new MySqlParameter("@_InLength",model.InLength),
                        new MySqlParameter("@_InWidth",model.InWidth),
                        new MySqlParameter("@_InHeight",model.InHeight),
                        new MySqlParameter("@_WareHouseID",model.WareHouseID),
                        new MySqlParameter("@_WarehouseAdminRemark",model.WarehouseAdminRemark),
                        new MySqlParameter("@_CustomerServiceID",model.CustomerServiceID),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_update_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_update_by_id, parameters);
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

        public static logistics_customer_order logistics_customer_order_GetModel(long customerOrderID)
        {
            var result = new logistics_customer_order();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID", customerOrderID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrder.logistics_customer_order_GetModel, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;

        }

    }
}
