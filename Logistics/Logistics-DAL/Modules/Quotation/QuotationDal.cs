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


    }
}
