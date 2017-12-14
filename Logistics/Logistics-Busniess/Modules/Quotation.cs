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
        public bool importFedex()
        {



            return true;
        }
        public static List<QuotationChannelPriceVM> GetChannelPrice(GetQuotationPriceByCountryRequest request)
        {
            var AllChannels = QuotationDal.SelectAllChannels(request.TenantID);
            var QuotationChannelPriceList = new List<QuotationChannelPriceVM>();
            QuotationChannelPriceVM QuotationChannelPriceVM = null;

            foreach (var o in AllChannels)
            {
                QuotationChannelPriceVM = new QuotationChannelPriceVM();
                QuotationChannelPriceVM.Amount = GetPriceByChannelID(request, o.ID);
                QuotationChannelPriceVM.channelID = o.ID;
                QuotationChannelPriceVM.channelName = o.Name;
                QuotationChannelPriceVM.Prescription = o.Prescription;
                QuotationChannelPriceVM.Remark = o.Remark;
                QuotationChannelPriceVM.ServiceAmount = 0;
                QuotationChannelPriceVM.weight = request.weight;
                QuotationChannelPriceList.Add(QuotationChannelPriceVM);

            }

            return QuotationChannelPriceList;
        }


        // 根据渠道获取价格
        public static decimal GetPriceByChannelID(GetQuotationPriceByCountryRequest request, long channelID)
        {
            var height = request.height;
            var width = request.width;
            var length = request.length;
            var weight = request.weight;
            var volume = Math.Round(height * width * length, 2);
            var volumeWeight = (decimal)0.00;
            var actualWeight = (decimal)0.00;
            var firstHeavy = (decimal)0.00;
            var continuedHeavy = (decimal)0.00;
            var amount = (decimal)0.00;

            if (channelID == BusinessConstants.Channel.EMSEconomicID)
            {
                volumeWeight = Math.Round(volume / 6000, 2);
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
                var count = Convert.ToDouble(actualWeight) % 0.5 > 0 ? (int)(Convert.ToDouble(actualWeight) / 0.5) + 1 : (int)(Convert.ToDouble(actualWeight) / 0.5);
                //根据国家和渠道ID 获取分区
                var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                if (partitionCountry != null)
                {
                    //根据分区获取分区首重价格续重价格
                    var QuotationPrice = QuotationDal.SelectPartitionPrice(request.TenantID, partitionCountry.partitionID);
                    firstHeavy = QuotationPrice.firstHeavyPrice;
                    continuedHeavy = QuotationPrice.continuedHeavyPrice;
                    amount = firstHeavy + (count - 1) * continuedHeavy;
                }
                else
                {
                    amount = 0;
                }



            }
            else if (channelID == BusinessConstants.Channel.FedxEconomicID)
            {
                volumeWeight = Math.Round(volume / 5000, 2);
                if (weight > volumeWeight)
                {
                    actualWeight = weight;
                }
                else
                {
                    actualWeight = volumeWeight;
                }

                if (DecimalHelper.IPFRule(length, width, height, weight))
                {

                }
                else
                {
                    //根据国家和渠道ID 获取分区
                    var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                    //根据分区获取分区价格
                    var QuotationPrice = QuotationDal.SelectPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                    amount = Math.Round(Convert.ToDecimal((Convert.ToDouble(QuotationPrice.price) * 1.125)));
                }
            }
            else if (channelID == BusinessConstants.Channel.UPSEconomicID)
            {
                volumeWeight = Math.Round(volume / 5000, 2);
                var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                var QuotationPrice = QuotationDal.SelectPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                amount = QuotationPrice.price;

            }
            else if (channelID == BusinessConstants.Channel.DHLEconomicID)
            {
                volumeWeight = Math.Round(volume / 5000, 2);
                var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                var QuotationPrice = QuotationDal.SelectPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                amount = Math.Round(Convert.ToDecimal((Convert.ToDouble(QuotationPrice.price) * 1.15)),2);
                if (length >120 || actualWeight > 68)
                {
                    amount = Math.Round(Convert.ToDecimal(Convert.ToDouble(amount) + 270 * 1.15),2);
                }
            }



            return amount;
        }





    }
}
