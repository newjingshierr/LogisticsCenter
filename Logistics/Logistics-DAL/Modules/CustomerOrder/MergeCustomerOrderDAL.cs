using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;
using Akmii;
using Akmii.Core;

namespace Logistics_DAL
{
    public class MergeCustomerOrderDAL
    {

        public static List<CustomerOrderMergeVM> GetListByPage(long userID,
            string customerOrderMergeNo,
            long CustomerChooseChannelID,
            string recipient,
            string country,
            long ChannelID,
            System.DateTime deliverTimeBegin,
            System.DateTime deliverTimeEnd,
            long AgentID,
            System.DateTime orderMergeTimeBegin,
             System.DateTime orderMergeTimeEnd,
             string expressNo,
             string currentStep,
             string currentStatus,
            int PageIndex, int PageSize, ref int totalCount)
        {
            var result = new List<CustomerOrderMergeVM>();
            var total = new MySqlParameter("@_TotalCount", totalCount) { Direction = ParameterDirection.Output };



            MySqlParameter[] parameters = {
                                new MySqlParameter("@_TenantID", BusinessConstants.Admin.TenantID),
                                new MySqlParameter("@_userID", userID),
                                new MySqlParameter("@_customerOrderMergeNo", customerOrderMergeNo ==null ?"":customerOrderMergeNo),
                                new MySqlParameter("@_CustomerChooseChannelID", CustomerChooseChannelID),
                                new MySqlParameter("@_recipient", recipient == null ?"":recipient),
                                new MySqlParameter("@_country", country == null ?"":country),
                                new MySqlParameter("@_ChannelID", ChannelID),
                                new MySqlParameter("@_deliverTimeBegin", deliverTimeBegin.ConvertDBTime()),
                                new MySqlParameter("@_deliverTimeEnd", deliverTimeEnd.ConvertDBTime()),
                                new MySqlParameter("@_AgentID", AgentID),
                                new MySqlParameter("@_orderMergeTimeBegin", orderMergeTimeBegin.ConvertDBTime()),
                                new MySqlParameter("@_orderMergeTimeEnd", orderMergeTimeEnd.ConvertDBTime()),
                                new MySqlParameter("@_expressNo", expressNo == null ?"":expressNo),
                                new MySqlParameter("@_currentStep", currentStep == null ?"":currentStep),
                                new MySqlParameter("@_currentStatus", currentStatus == null ?"":currentStatus),
                               new MySqlParameter("@_PageIndex", PageIndex),
                               new MySqlParameter("@_PageSize", PageSize),
                                total
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.CustomerOrderMerge.logistics_customer_order_merge_select_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<CustomerOrderMergeVM>.DtToList(dbResult.Tables[0]);
                totalCount = (total.Value + "").Convert2Int32();
            }
            else
            {
                result = null;
            }
            result.ForEach(o =>
            {
                if (o.currentStep == "2")
                {
                    o.currentStep = "客服确认中";
                }
                else if (o.currentStep == "3")
                {
                    o.currentStep = "仓库打包中";
                }
                else if (o.currentStep == "4")
                {
                    o.currentStep = "待付款";

                }
                else if (o.currentStep == "5")
                {
                    o.currentStep = "待发货";
                }
            });

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
                        new MySqlParameter("@_CustomerChooseChannelName", model.CustomerChooseChannelName),
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


        public static bool Update(logistics_customer_order_merge model, AkmiiMySqlTransaction trans = null)
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
    }
}
