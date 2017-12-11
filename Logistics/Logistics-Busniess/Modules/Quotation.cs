using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;
using Logistics.Core;
using Akmii.Cache.Client;
using Logistics_DAL;
using Logistics.Common;


namespace Logistics_Busniess
{
    public class QuotationManager
    {
        // logistics_quotation_partition_country
        public static decimal GetQuotationPriceByCountry(GetQuotationPriceByCountryRequest request)
        {
            var height = request.height;
            var width = request.width;
            var length = request.length;
            var weight = request.weight;
            var volume = Math.Round(height * width * length, 2);
            var volumeWeight = Math.Round(volume / 6000, 2);
            var actualWeight = (decimal)0;
            var firstHeavy = (decimal)0;
            var continuedHeavy = (decimal)0;

            if (height < 60 && width < 60 && length < 60)
                actualWeight = weight;
            else
            {
                if (weight < volumeWeight)
                {
                    actualWeight = volumeWeight;
                }
                else
                {
                    actualWeight = weight;
                }
            }


            var count =Convert.ToDouble (actualWeight)%0.5 >0?(int) (Convert.ToDouble(actualWeight) / 0.5) + 1: (int)(Convert.ToDouble(actualWeight) / 0.5);

            var partition_country_list = QuotationDal.logistics_quotation_partition_select_by_country(BusinessConstants.Admin.TenantID, request.country);
            var QuotationPriceResult = QuotationDal.logistics_quotation_partition_price_select_by_country(BusinessConstants.Admin.TenantID, partition_country_list.partitionID);
            firstHeavy = QuotationPriceResult.firstHeavy;
            continuedHeavy = QuotationPriceResult.continuedHeavy;
            var result = Math.Round(firstHeavy + (count - 1) * continuedHeavy,2);
            return result;
        }
    }
}
