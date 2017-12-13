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
                ISheet sheet = workbook.GetSheet("Fedex报价模板");
                int rfirst = sheet.FirstRowNum;
                int rlast = sheet.LastRowNum;
                IRow firstRow = sheet.GetRow(rfirst);
                var columns = firstRow.Cells.Count();
                IRow row = null;

                logistics_quotation_partition_price partitionPrice = null;
                for (int i = 0; i < rlast; i++)
                {
                    for( int j = 2; j < columns; j++)
                    {
                        row = sheet.GetRow(i+1);
                        var result =QuotationDal.GetPartitionIDByCodeChannelID(Convert.ToString(firstRow.Cells[j]).Trim(), BusinessConstants.Channel.FedxEconomicID, 890501594632818690);
                        partitionPrice = new logistics_quotation_partition_price();
                        partitionPrice.TenantID = 890501594632818690;
                        partitionPrice.ID = IdWorker.GetID();
                        partitionPrice.firstHeavyPrice = 0;
                        partitionPrice.continuedHeavyPrice = 0;
                        partitionPrice.channelID = BusinessConstants.Channel.FedxEconomicID;
                        partitionPrice.partitionID = result.ID;
                        partitionPrice.beginHeavy =Convert.ToDecimal(row.Cells[0].ToString());
                        partitionPrice.endHeavy = Convert.ToDecimal(row.Cells[1].ToString());
                        partitionPrice.price = row.Cells[j]  == null? 0: Convert.ToDecimal(row.Cells[j].ToString());
                        partitionPrice.CreatedBy = 890501594632818690;
                        partitionPrice.ModifiedBy = 890501594632818690;
                        QuotationDal.InsertPartitionPrice(partitionPrice);
                        System.Console.WriteLine("channel id:"+BusinessConstants.Channel.FedxEconomicID +"distinct:"+ firstRow.Cells[j]);
                    }
                }

            }


            //  var result = SMSHelper.send();

            // var userNo =  RuleManger.SetCurrentNo(901992431992573952, "user");
            //  var oderNo = RuleManger.SetCurrentNo(901992431992573952, "order");
            //MemcachedClientConfiguration config = new MemcachedClientConfiguration();
            //config.Servers.Add(new IPEndPoint(IPAddress.Loopback, 11211));
            //config.Protocol = MemcachedProtocol.Binary;
            //config.Authentication.Type = typeof(PlainTextAuthenticator);
            //config.Authentication.Parameters["userName"] = "demo";
            //config.Authentication.Parameters["password"] = "demo";

            //var mc = new MemcachedClient(config);

            //for (var i = 0; i < 100; i++)
            //    mc.Store(StoreMode.Set, "Hello", "World");
            // MemcachedHelper.Instance().SetValue("11", "22", "44");
            //AA aa = new AA();
            //aa.a = 2;

            //MemcachedHelper.Instance().SetValue("33", "22", aa);
            // var obj = MemcachedHelper.Instance().GetValue("33", "22");




        }
    }


    public class SimpleClass
    {
        public static int c = 1;
        // Static constructor
        static SimpleClass()
        {
            int a = 1;
            c = 2;
            //
        }

        public static void print()
        {
            int a = 1;
            var d = c + 1;
        }
    }
}
