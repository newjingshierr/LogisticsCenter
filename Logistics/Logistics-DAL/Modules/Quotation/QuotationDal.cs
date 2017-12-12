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
        public static List<logistics_quotation_partition_country> selectPartitionByCountry(long TenantID, string country)
        {
            var result = new logistics_quotation_partition_country();
            var resultList = new List<logistics_quotation_partition_country>();

            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_country", country)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_select_by_country, parameters);
            if (dbResult.Tables.Count > 0)
            {
                for (int i = 0; i < dbResult.Tables.Count; i++)
                {
                    result = ConvertHelper<logistics_quotation_partition_country>.DtToModel(dbResult.Tables[i]);
                    resultList.Add(result);
                }

            }
            else
            {
                resultList = null;
            }

            return resultList;
        }


        public static List<QuotationPriceVM> SelectPartitionPrice(long TenantID, List<logistics_quotation_partition_country> partitionCountryList)
        {
            var result = new QuotationPriceVM();
            var resultList = new List<QuotationPriceVM>();

            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                                new MySqlParameter("@_partitionID",partitionID),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Quotation.logistics_quotation_partition_price_select_by_country, parameters);
            if (dbResult.Tables.Count > 0)
            {
                result = ConvertHelper<QuotationPriceVM>.DtToModel(dbResult.Tables[0]);
                resultList.Add(result);
            }
            else
            {
                resultList = null;
            }


            return resultList;
        }

        public static List<QuotationPriceVM> logistics_quotation_partition_price_list_select_by_country(long TenantID, List<logistics_quotation_partition_country> partitionContryList)
        {
            var result = new List<QuotationPriceVM>();
            foreach (var o in partitionContryList)
            {
                var countryResult = logistics_quotation_partition_price_select_by_country(TenantID, o.partitionID);
                if (countryResult != null)
                {
                    result.Add(countryResult);
                }

            }
            return result;
        }
    }
}
