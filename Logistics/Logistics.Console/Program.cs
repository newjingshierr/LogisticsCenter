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
        static void Main(string[] args)
        {

            string path = "Quotation.xls";

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                IWorkbook workbook = new HSSFWorkbook(fs);

                ISheet sheet = workbook.GetSheet("Fedex资费区");
                IRow firstRow = sheet.GetRow(0);
                var columnsCount = firstRow.Cells.Count();

                for (int i = 0; i < columnsCount; i++)
                {
                    var code = firstRow.Cells[i].ToString();
                    logistics_quotation_partition partition = new logistics_quotation_partition();
                    partition.TenantID = 890501594632818690;
                    partition.partitionCode = code;
                    partition.ID = IdWorker.GetID();
                    partition.ChannelID = BusinessConstants.Channel.FedxEconomicID;
                    partition.CreatedBy = 890501594632818690;
                    partition.ModifiedBy = 890501594632818690;
                    QuotationDal.QuotaionPartitionInsert(partition);
                    System.Console.WriteLine("channel id:" + BusinessConstants.Channel.FedxEconomicID + "Fedex资费区:" + code);

                }


                sheet = workbook.GetSheet("Fedex国家");
                firstRow = sheet.GetRow(0);
                columnsCount = firstRow.Cells.Count();
                int rlast = sheet.LastRowNum;
                IRow row = null;
                for (int i = 0; i < rlast; i++)
                {
                    row = sheet.GetRow(i + 1);
                    logistics_quotation_partition_country partitionCountry = new logistics_quotation_partition_country();
                    partitionCountry.TenantID = 890501594632818690;
                    partitionCountry.ChannelID = BusinessConstants.Channel.FedxEconomicID;
                    partitionCountry.ID = IdWorker.GetID();
                    partitionCountry.countryEnglishName = row.Cells[0].ToString();
                    partitionCountry.countryChineseName = row.Cells[1].ToString();
                    partitionCountry.countryCode = row.Cells[2].ToString();
                    var partionCode = row.Cells[3].ToString();
                    var partionID = QuotationDal.GetPartitionIDByCodeChannelID(row.Cells[3].ToString(), BusinessConstants.Channel.FedxEconomicID, 890501594632818690).ID;
                    partitionCountry.partitionID = partionID;
                    partitionCountry.CreatedBy = 890501594632818690;
                    partitionCountry.ModifiedBy = 890501594632818690;
                    QuotationDal.QuotaionCountryInsert(partitionCountry);
                    System.Console.WriteLine("channel id:" + BusinessConstants.Channel.FedxEconomicID + "Fedex国家:" + row.Cells[2].ToString());
                }



                sheet = workbook.GetSheet("Fedex报价模板");
                int rfirst = sheet.FirstRowNum;
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
                        System.Console.WriteLine("channel id:" + BusinessConstants.Channel.FedxEconomicID + "Fedex报价模板:" + firstRow.Cells[j]);
                    }
                }


           



            }

            System.Console.ReadLine();
        }
    }
}
