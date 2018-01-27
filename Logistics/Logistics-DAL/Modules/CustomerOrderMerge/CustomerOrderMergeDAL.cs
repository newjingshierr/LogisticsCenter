using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class CustomerOrderMergeDAL
    {
        public static logistics_customer_order_merge GetItem(long ID, long TenantID)
        {
            var result = new logistics_customer_order_merge();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",ID),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_select_by_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order_merge>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool Insert(logistics_customer_order_merge model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_UserID",model.UserID),
                         new MySqlParameter("@_MergeOrderNo", model.MergeOrderNo),
                        new MySqlParameter("@_CustomerMark", model.CustomerMark),
                        new MySqlParameter("@_CustomerChooseChannelID", model.CustomerChooseChannelID),
                        new MySqlParameter("@_InWeightTotal", model.InWeightTotal),
                             new MySqlParameter("@_InVolumeTotal", model.InVolumeTotal),
                             new MySqlParameter("@_InPackageCountTotal", model.InPackageCountTotal),
                                  new MySqlParameter("@_recipient", model.recipient),
                                   new MySqlParameter("@_country", model.country),
                                    new MySqlParameter("@_address", model.address),
                                     new MySqlParameter("@_city", model.city),
                                      new MySqlParameter("@_code", model.code),
                                       new MySqlParameter("@_tel", model.tel),
                                        new MySqlParameter("@_company", model.company),
                                         new MySqlParameter("@_taxNo", model.taxNo),
                                          new MySqlParameter("@_declareTotal", model.declareTotal),
                                           new MySqlParameter("@_customerServiceMark", model.customerServiceMark),
                                            new MySqlParameter("@_packageMark", model.packageMark),
                                             new MySqlParameter("@_packageWeight", model.packageWeight),
                                               new MySqlParameter("@_packageVolume", model.packageVolume),
                                                new MySqlParameter("@_packageLength", model.packageLength),
                                                 new MySqlParameter("@_packageHeight", model.packageHeight),
                                                  new MySqlParameter("@_packageWidth", model.packageWidth),
                                                   new MySqlParameter("@_settlementWeight", model.settlementWeight),
                                                    new MySqlParameter("@_freightFee", model.freightFee),
                                                     new MySqlParameter("@_tax", model.tax),
                                                      new MySqlParameter("@_serviceFee", model.serviceFee),
                                                       new MySqlParameter("@_remoteFee", model.remoteFee),
                                                       new MySqlParameter("@_magneticinspectionFee", model.magneticinspectionFee),
                                                        new MySqlParameter("@_totalFee", model.totalFee),
                                                         new MySqlParameter("@_ChannelID", model.ChannelID),
                                                          new MySqlParameter("@_channelNo", model.channelNo),
                                                           new MySqlParameter("@_deliverTime", model.deliverTime),
                                                            new MySqlParameter("@_AgentID", model.AgentID),
                                                             new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_insert, parameters);
            }
            return result == 1;

        }
        public static bool Delete(logistics_customer_order_merge model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                            new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),

            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_delete_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_delete_by_id, parameters);
            }
            return result == 1;

        }

        public static bool Update(logistics_customer_order_merge model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                         new MySqlParameter("@_MergeOrder", model.MergeOrderNo),
                        new MySqlParameter("@_CustomerMark", model.CustomerMark),
                        new MySqlParameter("@_CustomerChooseChannelID", model.CustomerChooseChannelID),
                        new MySqlParameter("@_InWeightTotal", model.InWeightTotal),
                             new MySqlParameter("@_InVolumeTotal", model.InVolumeTotal),
                                  new MySqlParameter("@_recipient", model.recipient),
                                   new MySqlParameter("@_country", model.country),
                                    new MySqlParameter("@_address", model.address),
                                     new MySqlParameter("@_city", model.city),
                                      new MySqlParameter("@_code", model.code),
                                       new MySqlParameter("@_tel", model.tel),
                                        new MySqlParameter("@_company", model.company),
                                         new MySqlParameter("@_taxNo", model.taxNo),
                                          new MySqlParameter("@_declareTotal", model.declareTotal),
                                           new MySqlParameter("@_customerServiceMark", model.customerServiceMark),
                                            new MySqlParameter("@_packageMark", model.packageMark),
                                             new MySqlParameter("@_packageWeight", model.packageWeight),
                                               new MySqlParameter("@_packageVolume", model.packageVolume),
                                                new MySqlParameter("@_packageLength", model.packageLength),
                                                 new MySqlParameter("@_packageHeight", model.packageHeight),
                                                  new MySqlParameter("@_packageWidth", model.packageWidth),
                                                   new MySqlParameter("@_settlementWeight", model.settlementWeight),
                                                    new MySqlParameter("@_freightFee", model.freightFee),
                                                     new MySqlParameter("@_tax", model.tax),
                                                      new MySqlParameter("@_serviceFee", model.serviceFee),
                                                       new MySqlParameter("@_remoteFee", model.remoteFee),
                                                       new MySqlParameter("@_magneticinspectionFee", model.magneticinspectionFee),
                                                        new MySqlParameter("@_totalFeet", model.totalFee),
                                                         new MySqlParameter("@_ChannelID", model.ChannelID),
                                                          new MySqlParameter("@_channelNo", model.channelNo),
                                                           new MySqlParameter("@_deliverTime", model.deliverTime),
                                                            new MySqlParameter("@_AgentID", model.AgentID),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_update_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_update_by_id, parameters);
            }
            return result == 1;

        }

        public static List<logistics_customer_order_merge> GetByPage(DemoGetByNameRequest request, ref int totalCount, AkmiiMySqlTransaction trans = null)
        {
            var list = new List<logistics_customer_order_merge>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",""),
                 new MySqlParameter("@_CreatedBy",""),
                new MySqlParameter("@_PageIndex", request.PageIndex),
                new MySqlParameter("@_PageSize", request.PageSize),
                new MySqlParameter("_totalCount", totalCount) { Direction = ParameterDirection.Output }
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_select_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_customer_order_merge>.DtToList(dbResult.Tables[0]);
            }

            return list;

        }
    }

    public class CustomerOrderMergeDetailDAL
    {
        public static logistics_customer_order_merge_detail GetItem(long ID, long TenantID)
        {
            var result = new logistics_customer_order_merge_detail();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",ID),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeDetail.logistics_customer_order_merge_detail_select_by_order_merge_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order_merge_detail>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool Insert(logistics_customer_order_merge_detail model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                         new MySqlParameter("@_mergeOrderID", model.mergeOrderID),
                        new MySqlParameter("@_productName", model.productName),
                        new MySqlParameter("@_HSCode", model.HSCode),
                        new MySqlParameter("@_declareUnitPrice", model.declareUnitPrice),
                       new MySqlParameter("@_declareTotal", model.declareTotal),
                      new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeDetail.logistics_customer_order_merge_detail_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMergeDetail.logistics_customer_order_merge_detail_insert, parameters);
            }
            return result == 1;

        }
        public static bool Delete(logistics_customer_order_merge_detail model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                            new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),

            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeDetail.logistics_customer_order_merge_detail_delete_by_order_merge_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMergeDetail.logistics_customer_order_merge_detail_delete_by_order_merge_id, parameters);
            }
            return result == 1;

        }

        public static bool Update(logistics_customer_order_merge_detail model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                       new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                         new MySqlParameter("@_mergeOrderID", model.mergeOrderID),
                        new MySqlParameter("@_productName", model.productName),
                        new MySqlParameter("@_HSCode", model.HSCode),
                        new MySqlParameter("@_declareUnitPrice", model.declareUnitPrice),
                       new MySqlParameter("@_declareTotal", model.declareTotal),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeDetail.logistics_customer_order_merge_detail_update, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMergeDetail.logistics_customer_order_merge_detail_update, parameters);
            }
            return result == 1;

        }

        public static List<logistics_customer_order_merge_detail> GetByMergeID(logistics_customer_order_merge_detail request, AkmiiMySqlTransaction trans = null)
        {
            var list = new List<logistics_customer_order_merge_detail>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",""),
                 new MySqlParameter("@_CreatedBy",""),
            };
            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeDetail.logistics_customer_order_merge_detail_select_by_order_merge_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_customer_order_merge_detail>.DtToList(dbResult.Tables[0]);
            }

            return list;
        }
    }

    public class CustomerOrderMergeRelation
    {
        public static logistics_customer_order_merge_relation GetItem(long ID, long TenantID)
        {
            var result = new logistics_customer_order_merge_relation();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",ID),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeRelation.logistics_customer_order_merge_relation_select_by_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_customer_order_merge_relation>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }
        public static bool Insert(logistics_customer_order_merge_relation model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                         new MySqlParameter("@_mergeOrderID", model.mergeOrderID),
                        new MySqlParameter("@_mergeeOrderNo", model.orderID),
                         new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeRelation.logistics_customer_order_merge_relation_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMergeRelation.logistics_customer_order_merge_relation_insert, parameters);
            }
            return result == 1;

        }
    }
    public class CustomerMergeStatus
    {
        public static logistics_customer_order_merge_status GetItem(long ID, long TenantID)
        {
            var result = new logistics_customer_order_merge_status();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",ID),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_select_by_id, parameters);
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
        public static bool Insert(logistics_customer_order_merge_status model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                         new MySqlParameter("@_mergeOrderID", model.mergeOrderID),
                        new MySqlParameter("@_mergeOrderNo", model.mergeOrderNo),
                        new MySqlParameter("@_currentStep", model.currentStep),
                        new MySqlParameter("@_currentStatus", model.currentStatus),
                         new MySqlParameter("@_CreatedBy",model.CreatedBy)
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

        public static bool Update(logistics_customer_order_merge_status model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                      new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                         new MySqlParameter("@_mergeOrderID", model.mergeOrderID),
                        new MySqlParameter("@_mergeOrderNo", model.mergeOrderNo),
                         new MySqlParameter("@_currentStep", model.currentStep),
                        new MySqlParameter("@_currentStatus", model.currentStatus),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_update_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.CustomerOrderMergeStatus.logistics_customer_order_merge_status_update_by_id, parameters);
            }
            return result == 1;

        }


    }

}
