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
        public static List<logistics_base_country> GetAllCountryByName(GetAllCountryByNameRequest request)
        {
            return QuotationDal.GetAllCountryByName(request);

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
                QuotationChannelPriceVM.Clause = o.Clause;
                QuotationChannelPriceVM.WeightLimit = o.WeightLimit;
                QuotationChannelPriceVM.SizeLimit = o.SizeLimit;
                QuotationChannelPriceList.Add(QuotationChannelPriceVM);
            }
            var result = QuotationChannelPriceList.OrderBy(item => item.Amount).ToList();
           // result.RemoveAll(item => item.Amount == 0);
            return result;
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

            if (channelID == BusinessConstants.Channel.EMSStandard || channelID == BusinessConstants.Channel.EUB || channelID == BusinessConstants.Channel.EMSPreferential)
            {
                //EMS标准快递价格规则：首重	0.5kg  续重 每0.5kg
                //E邮宝价格 首重	0.001kg 续重 每0.001kg
                //EMS特惠价格 首重	0.05kg 续重 每0.05kg


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
                var count = 0;
                //根据国家和渠道ID 获取分区
                var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                if (partitionCountry != null)
                {
                    if (channelID == BusinessConstants.Channel.EMSStandard)
                    {
                        count = Convert.ToDouble(actualWeight) % 0.5 > 0 ? (int)(Convert.ToDouble(actualWeight) / 0.5) + 1 : (int)(Convert.ToDouble(actualWeight) / 0.5);
                    }
                    else if (channelID == BusinessConstants.Channel.EUB)
                    {
                        count = Convert.ToDouble(actualWeight) % 0.001 > 0 ? (int)(Convert.ToDouble(actualWeight) / 0.001) + 1 : (int)(Convert.ToDouble(actualWeight) / 0.001);
                    }
                    else if (channelID == BusinessConstants.Channel.EMSPreferential)
                    {
                        count = Convert.ToDouble(actualWeight) % 0.05 > 0 ? (int)(Convert.ToDouble(actualWeight) / 0.05) + 1 : (int)(Convert.ToDouble(actualWeight) / 0.05);
                    }

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
            else if (channelID == BusinessConstants.Channel.FEDEXEconomic || channelID == BusinessConstants.Channel.FEDEXPrior)
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
                    //根据国家和渠道ID 获取分区
                    var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                    //根据分区获取分区价格
                    //IPF价格还没有上20171223
                    // var QuotationPrice = QuotationDal.SelectIPFPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                    var QuotationPrice = QuotationDal.SelectPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                    amount = Math.Round(Convert.ToDecimal((Convert.ToDouble(QuotationPrice.price) * 1.125)));
                }
                else
                {
                    //根据国家和渠道ID 获取分区
                    var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                    //根据分区获取分区价格\
                    var QuotationPrice = new QuotationPriceVM();
                    if (partitionCountry != null)
                    {
                        QuotationPrice = QuotationDal.SelectPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                    }
                    if (QuotationPrice != null)
                    {
                        amount = Math.Round(Convert.ToDecimal((Convert.ToDouble(QuotationPrice.price) * 1.125)));
                    }
                    if (QuotationPrice == null) amount = 0;
                }
            }
            else if (channelID == BusinessConstants.Channel.TNTEconomic || channelID == BusinessConstants.Channel.TNTPrior)
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
                //根据国家和渠道ID 获取分区
                var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                //根据分区获取分区价格\
                var QuotationPrice = new QuotationPriceVM();
                if (partitionCountry != null)
                {
                    QuotationPrice = QuotationDal.SelectPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                }
                if (QuotationPrice != null)
                {
                    amount = Math.Round(Convert.ToDecimal((Convert.ToDouble(QuotationPrice.price) * 1.125)));
                }
                if (QuotationPrice == null) amount = 0;

            }
            else if (channelID == BusinessConstants.Channel.UPSPrior)
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

                var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                var QuotationPrice = new QuotationPriceVM();
                if (partitionCountry != null)
                {
                    QuotationPrice = QuotationDal.SelectPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                }

                if (QuotationPrice != null)
                {
                    amount = QuotationPrice.price;
                }
                else
                {
                    amount = 0;
                }


            }
            else if (channelID == BusinessConstants.Channel.DHLStandard)
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

                var partitionCountry = QuotationDal.selectPartitionByCountry(request.TenantID, request.country, channelID);
                var QuotationPrice = new QuotationPriceVM();
                if (partitionCountry != null)
                {
                    QuotationPrice = QuotationDal.SelectPriceByPartitionIDWeight(request.TenantID, partitionCountry.partitionID, actualWeight);
                }

                if (QuotationPrice != null)
                {
                    amount = Math.Round(Convert.ToDecimal((Convert.ToDouble(QuotationPrice.price) * 1.15)), 2);
                }
                else
                {
                    amount = 0;
                }
                if (amount != 0)
                {
                    if (length > 120 || actualWeight > 68)
                    {
                        amount = Math.Round(Convert.ToDecimal(Convert.ToDouble(amount) + 270 * 1.15), 2);
                    }
                }

            }
            return amount;
        }





    }
}
