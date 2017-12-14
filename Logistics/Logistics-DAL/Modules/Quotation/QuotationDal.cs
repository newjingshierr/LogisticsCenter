using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class QuotationDal
    {
        public static bool QuotaionCountryInsert(logistics_quotation_partition_country model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_countryEnglishName", model.countryEnglishName),
                         new MySqlParameter("@_countryChineseName", model.countryEnglishName),
                          new MySqlParameter("@_countryCode", model.countryCode),
                           new MySqlParameter("@_ChannelID", model.ChannelID),
                         new MySqlParameter("@_partitionID", model.partitionID),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_country_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_country_insert, parameters);
            }
            return result == 1;

        }


        public static bool QuotaionPartitionInsert(logistics_quotation_partition model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_partitionCode", model.partitionCode),
                          new MySqlParameter("@_ChannelID", model.ChannelID),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_insert, parameters);
            }
            return result == 1;

        }


        public static logistics_quotation_partition GetPartitionIDByCodeChannelID(string code, long channelID, long TenantID)
        {
            var result = new logistics_quotation_partition();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_code",code),
                new MySqlParameter("@_channelID",channelID)

            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_select_by_Code_channelID, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_quotation_partition>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool InsertPartitionIPFPrice(logistics_quotation_partition_ipf_price model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_firstHeavyPrice", model.firstHeavyPrice),
                        new MySqlParameter("@_continuedHeavyPrice",model.continuedHeavyPrice),
                        new MySqlParameter("@_channelID",model.channelID),
                        new MySqlParameter("@_partitionID",model.partitionID),
                        new MySqlParameter("@_beginHeavy",model.beginHeavy),
                        new MySqlParameter("@_endHeavy",model.endHeavy),
                        new MySqlParameter("@_price",model.price),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                         new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_ipf_price_Insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_ipf_price_Insert, parameters);
            }
            return result == 1;

        }



        public static bool InsertPartitionPrice(logistics_quotation_partition_price model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_firstHeavyPrice", model.firstHeavyPrice),
                        new MySqlParameter("@_continuedHeavyPrice",model.continuedHeavyPrice),
                        new MySqlParameter("@_channelID",model.channelID),
                        new MySqlParameter("@_partitionID",model.partitionID),
                        new MySqlParameter("@_beginHeavy",model.beginHeavy),
                        new MySqlParameter("@_endHeavy",model.endHeavy),
                        new MySqlParameter("@_price",model.price),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                         new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_price_Insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_price_Insert, parameters);
            }
            return result == 1;

        }

        public static List<logistics_quotation_channel> SelectAllChannels(long TenantID)
        {
            var list = new List<logistics_quotation_channel>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_channel_select_all, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_quotation_channel>.DtToList(dbResult.Tables[0]);
            }
            return list;
        }


        public static logistics_quotation_partition_country selectPartitionByCountry(long TenantID, string country, long channelID)
        {
            var result = new logistics_quotation_partition_country();

            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_country", country),
                new MySqlParameter("@_channelID", channelID),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_select_by_country, parameters);
            if (dbResult.Tables.Count > 0)
            {
                if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
                {
                    result = ConvertHelper<logistics_quotation_partition_country>.DtToModel(dbResult.Tables[0]);
                }
                else
                {
                    result = null;
                }
            }
            else
            {
                result = null;
            }

            return result;
        }



        public static QuotationPriceVM SelectPartitionPrice(long TenantID, long partitionID)
        {
            var result = new QuotationPriceVM();

            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                                new MySqlParameter("@_partitionID",partitionID),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_price_select_by_country, parameters);
            if (dbResult.Tables.Count > 0)
            {
                result = ConvertHelper<QuotationPriceVM>.DtToModel(dbResult.Tables[0]);

            }
            else
            {
                result = null;
            }

            return result;
        }


        public static QuotationPriceVM SelectPriceByPartitionIDWeight(long TenantID, long partitionID, decimal weight)
        {
            var result = new QuotationPriceVM();

            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                                new MySqlParameter("@_partitionID",partitionID),
                                new MySqlParameter("@_weight",weight),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_Select_Price_By_PartitionID_Weight, parameters);
            if (dbResult.Tables.Count > 0)
            {
                result = ConvertHelper<QuotationPriceVM>.DtToModel(dbResult.Tables[0]);

            }
            else
            {
                result = null;
            }

            return result;
        }


    }
}
