using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.Core;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using System.Net;
using Logistics_Busniess;
using NPOI;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using Logistics_Model;
using Logistics_DAL;



namespace Logistics.Console
{
    [Serializable]
    public class AA
    {
        public int a;
    }


    public class Program
    {
        public string path = "Quotation.xls";
        public ISheet sheet = null;
        public IWorkbook workbook = null;
        public IRow firstRow = null;
        public int rfirst;
        public int rlast;
        public IRow row;
        public int columnsCount;


        static void Main(string[] args)
        {
            Program p = new Program();
            //p.ImportPartion(BusinessConstants.Channel.FedxEconomicID, "Fedex资费区");
            //p.ImportCounty(BusinessConstants.Channel.FedxEconomicID, "Fedex国家");
            //p.ImportQuotation(BusinessConstants.Channel.FedxEconomicID, "Fedex报价模板");
            //p.ImportIPF(BusinessConstants.Channel.FedxEconomicID, "Fedex IPF");

            //p.ImportPartion(BusinessConstants.Channel.EMSEconomicID, "EMS资费区");
            //p.ImportCounty(BusinessConstants.Channel.EMSEconomicID, "EMS国家");


            //p.ImportPartion(BusinessConstants.Channel.UPSEconomicID, "UPS资费区");
            //p.ImportCounty(BusinessConstants.Channel.UPSEconomicID, "UPS国家");
            //p.ImportQuotation(BusinessConstants.Channel.UPSEconomicID, "UPS报价模板");

            //p.ImportPartion(BusinessConstants.Channel.DHLEconomicID, "DHL资费区");
            //p.ImportCounty(BusinessConstants.Channel.DHLEconomicID, "DHL国家");
            //p.ImportQuotation(BusinessConstants.Channel.DHLEconomicID, "DHL报价模板");

            //p.ImportPartion(BusinessConstants.Channel.TNTEconomicID, "TNT资费区");
            //p.ImportCounty(BusinessConstants.Channel.TNTEconomicID, "TNT国家");
            //p.ImportQuotation(BusinessConstants.Channel.TNTEconomicID, "TNT报价模板");
            p.ImportAllCountries("所有国家");
            System.Console.ReadLine();
        }

        /// <summary>
        /// 导入资费区
        /// </summary>
        public void ImportPartion(long channelID, string partitionSheetName)
        {


            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                workbook = new HSSFWorkbook(fs);

                sheet = workbook.GetSheet(partitionSheetName);
                firstRow = sheet.GetRow(0);
                var columnsCount = firstRow.Cells.Count();

                for (int i = 0; i < columnsCount; i++)
                {
                    var code = firstRow.Cells[i].ToString();
                    logistics_quotation_partition partition = new logistics_quotation_partition();
                    partition.TenantID = 890501594632818690;
                    partition.partitionCode = code;
                    partition.ID = IdWorker.GetID();
                    partition.ChannelID = channelID;
                    partition.CreatedBy = 890501594632818690;
                    partition.ModifiedBy = 890501594632818690;
                    QuotationDal.QuotaionPartitionInsert(partition);
                    System.Console.WriteLine("channel id:" + channelID + partitionSheetName + ":" + code);

                }

            }

        }

        /// <summary>
        /// 导入国家
        /// </summary>
        public void ImportCounty(long channelID, string countrySheetName)
        {

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                workbook = new HSSFWorkbook(fs);
                sheet = workbook.GetSheet(countrySheetName);
                firstRow = sheet.GetRow(0);
                columnsCount = firstRow.Cells.Count();
                rlast = sheet.LastRowNum;
                IRow row = null;

                for (int i = 0; i < rlast; i++)
                {
                    row = sheet.GetRow(i + 1);
                    logistics_quotation_partition_country partitionCountry = new logistics_quotation_partition_country();
                    partitionCountry.TenantID = 890501594632818690;
                    partitionCountry.ChannelID = channelID;
                    partitionCountry.ID = IdWorker.GetID();
                    partitionCountry.countryEnglishName = row.Cells[0].ToString();
                    partitionCountry.countryChineseName = row.Cells[1].ToString();
                    partitionCountry.countryCode = row.Cells[2].ToString();
                    var partionCode = row.Cells[3].ToString();
                    var partionID = QuotationDal.GetPartitionIDByCodeChannelID(row.Cells[3].ToString(), channelID, 890501594632818690).ID;
                    partitionCountry.partitionID = partionID;
                    partitionCountry.CreatedBy = 890501594632818690;
                    partitionCountry.ModifiedBy = 890501594632818690;
                    QuotationDal.QuotaionCountryInsert(partitionCountry);
                    System.Console.WriteLine("channel id:" + channelID + countrySheetName + ":" + row.Cells[2].ToString());
                }

            }

        }

        /// <summary>
        /// 导入报价
        /// </summary>
        public void ImportQuotation(long channelID, string quotationSheetName)
        {

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                IWorkbook workbook = new HSSFWorkbook(fs);
                sheet = workbook.GetSheet(quotationSheetName);
                rfirst = sheet.FirstRowNum;
                rlast = sheet.LastRowNum;
                firstRow = sheet.GetRow(rfirst);
                var columns = firstRow.Cells.Count();

                logistics_quotation_partition_price partitionPrice = null;
                for (int i = 0; i < rlast; i++)
                {
                    for (int j = 2; j < columns; j++)
                    {
                        row = sheet.GetRow(i + 1);
                        var result = QuotationDal.GetPartitionIDByCodeChannelID(Convert.ToString(firstRow.Cells[j]).Trim(), BusinessConstants.Channel.FedxEconomicID, 890501594632818690);
                        partitionPrice = new logistics_quotation_partition_price();
                        partitionPrice.TenantID = 890501594632818690;
                        partitionPrice.ID = IdWorker.GetID();
                        partitionPrice.firstHeavyPrice = 0;
                        partitionPrice.continuedHeavyPrice = 0;
                        partitionPrice.channelID = BusinessConstants.Channel.FedxEconomicID;
                        partitionPrice.partitionID = result.ID;
                        partitionPrice.beginHeavy = Convert.ToDecimal(row.Cells[0].ToString());
                        partitionPrice.endHeavy = Convert.ToDecimal(row.Cells[1].ToString());
                        partitionPrice.price = row.Cells[j] == null ? 0 : Convert.ToDecimal(row.Cells[j].ToString());
                        partitionPrice.CreatedBy = 890501594632818690;
                        partitionPrice.ModifiedBy = 890501594632818690;
                        QuotationDal.InsertPartitionPrice(partitionPrice);
                        System.Console.WriteLine("channel id:" + channelID + quotationSheetName + ":" + firstRow.Cells[j]);
                    }


                }
            }
        }

        /// <summary>
        /// 导入IPF
        /// </summary>
        public void ImportIPF(long channelID, string quotationSheetName)
        {

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                IWorkbook workbook = new HSSFWorkbook(fs);
                sheet = workbook.GetSheet(quotationSheetName);
                rfirst = sheet.FirstRowNum;
                rlast = sheet.LastRowNum;
                firstRow = sheet.GetRow(rfirst);
                var columns = firstRow.Cells.Count();

                logistics_quotation_partition_ipf_price partitionPrice = null;
                for (int i = 0; i < rlast; i++)
                {
                    for (int j = 2; j < columns; j++)
                    {
                        row = sheet.GetRow(i + 1);
                        var result = QuotationDal.GetPartitionIDByCodeChannelID(Convert.ToString(firstRow.Cells[j]).Trim(), BusinessConstants.Channel.FedxEconomicID, 890501594632818690);
                        partitionPrice = new logistics_quotation_partition_ipf_price();
                        partitionPrice.TenantID = 890501594632818690;
                        partitionPrice.ID = IdWorker.GetID();
                        partitionPrice.firstHeavyPrice = 0;
                        partitionPrice.continuedHeavyPrice = 0;
                        partitionPrice.channelID = BusinessConstants.Channel.FedxEconomicID;
                        partitionPrice.partitionID = result.ID;
                        partitionPrice.beginHeavy = Convert.ToDecimal(row.Cells[0].ToString());
                        partitionPrice.endHeavy = Convert.ToDecimal(row.Cells[1].ToString());
                        partitionPrice.price = row.Cells[j] == null ? 0 : Convert.ToDecimal(row.Cells[j].ToString());
                        partitionPrice.CreatedBy = 890501594632818690;
                        partitionPrice.ModifiedBy = 890501594632818690;
                        QuotationDal.InsertPartitionIPFPrice(partitionPrice);
                        System.Console.WriteLine("channel id:" + channelID + quotationSheetName + ":" + firstRow.Cells[j]);
                    }


                }
            }
        }


        public void ImportAllCountries(string allCountriesName)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                IWorkbook workbook = new HSSFWorkbook(fs);
                sheet = workbook.GetSheet(allCountriesName);
                rfirst = sheet.FirstRowNum;
                rlast = sheet.LastRowNum;
                firstRow = sheet.GetRow(rfirst);
                var columns = firstRow.Cells.Count();

                logistics_base_country partitionPrice = null;
                for (int i = 0; i < rlast; i++)
                {
                        row = sheet.GetRow(i);
                        partitionPrice = new logistics_base_country();
                        partitionPrice.TenantID = 890501594632818690;
                        partitionPrice.ID = IdWorker.GetID();
                        partitionPrice.englishName = row.Cells[0].ToString();
                        partitionPrice.code = row.Cells[1].ToString();
                        partitionPrice.chineseName = row.Cells[2].ToString();
                        partitionPrice.CreatedBy = 890501594632818690;
                        partitionPrice.ModifiedBy = 890501594632818690;
                        QuotationDal.InsertCountry(partitionPrice);
                        System.Console.WriteLine(partitionPrice.chineseName);

                }
            }
        }
    }
}
