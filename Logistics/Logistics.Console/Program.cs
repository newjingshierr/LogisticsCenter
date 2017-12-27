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
using System.Net.Mail;

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
            // sendMail("fds718@163.com", "famliytree", "enzo.shi@famliytree.cn", "enzo.shi@famliytree.cn", "Infosys333", "您好！", "这是一封测试邮件!");

            Program p = new Program();

            //p.ImportPartion(BusinessConstants.Channel.FEDEXIP, "fedex优先服务IP 分区");
            //p.ImportCounty(BusinessConstants.Channel.FEDEXIP, "fedex优先服务IP 国家");
            p.ImportQuotation(BusinessConstants.Channel.FEDEXIP, "fedex优先服务IP 价格");


            //p.ImportPartion(BusinessConstants.Channel.FEDEXIE, "fedex经济服务IE 分区");
            //p.ImportCounty(BusinessConstants.Channel.FEDEXIE, "fedex经济服务IE 国家");
            p.ImportQuotation(BusinessConstants.Channel.FEDEXIE, "fedex经济服务IE 价格");


            //p.ImportPartion(BusinessConstants.Channel.UPSFSR, "UPS优先服务红单  分区");
            //p.ImportCounty(BusinessConstants.Channel.UPSFSR, "UPS优先服务红单 国家");
            p.ImportQuotation(BusinessConstants.Channel.UPSFSR, "UPS优先服务红单  价格");



            //p.ImportPartion(BusinessConstants.Channel.TNT48N, "TNT48N经济快递 分区");
            //p.ImportCounty(BusinessConstants.Channel.TNT48N, "TNT48N经济快递 国家");
            p.ImportQuotation(BusinessConstants.Channel.TNT48N, "TNT48N经济快递  价格");


            //p.ImportPartion(BusinessConstants.Channel.TNT15N, "TNT15N优先快递  分区");
            //p.ImportCounty(BusinessConstants.Channel.TNT15N, "TNT15N优先快递  国家");
            p.ImportQuotation(BusinessConstants.Channel.TNT15N, "TNT15N优先快递   价格");


            //  p.ImportAllCountries("所有国家");

       //     p.ImportPartion(BusinessConstants.Channel.EMSEconomicID, "EMS分区");
         //   p.ImportCounty(BusinessConstants.Channel.EMSEconomicID, "EMS国家");
            p.ImportEMSQuotaion(BusinessConstants.Channel.EMSEconomicID, "EMS价格");

          //  p.ImportPartion(BusinessConstants.Channel.EUB, "EUB分区");
         //   p.ImportCounty(BusinessConstants.Channel.EUB, "EUB国家");
            p.ImportEMSQuotaion(BusinessConstants.Channel.EUB, "EUB价格");

        //    p.ImportPartion(BusinessConstants.Channel.InternationalESuperFast, "国际e特快分区");
        //    p.ImportCounty(BusinessConstants.Channel.InternationalESuperFast, "国际e特快国家");
            p.ImportEMSQuotaion(BusinessConstants.Channel.InternationalESuperFast, "国际e特快价格");

            //p.ImportPartion(BusinessConstants.Channel.DHLEconomicID, "DHL经济型分区");
            //p.ImportCounty(BusinessConstants.Channel.DHLEconomicID, "DHL经济型国家");
            p.ImportEMSQuotaion(BusinessConstants.Channel.DHLEconomicID, "DHL经济型价格");
            System.Console.ReadLine();
        }


        /// <summary>
        /// 向用户发送邮件
        /// </summary>
        /// <param name="ReceiveUser">接收邮件的用户</param>
        /// <param name="SendUser">发送者显求的邮箱地址,可为空</param>
        /// <param name="DisplayName">收件人显示发件人的联系人名，可为中文</param>
        /// <param name="SendUserName">发送者的邮箱登陆名，可以与发送者地址一样</param>
        /// <param name="UserPassword">发送者的登陆密码</param>
        /// <param name="MailTitle">发送标题</param>
        /// <param name="MailContent">发送的内容</param>
        public static void sendMail(string ReceiveUser, string DisplayName, string SendUser, string SendUserName, string UserPassword, string MailTitle, string MailContent)
        {
            MailAddress toMail = new MailAddress(ReceiveUser);//接收者邮箱
            MailAddress fromMail = new MailAddress(SendUser, DisplayName);//发送者邮箱       
            MailMessage mail = new MailMessage(fromMail, toMail);
            mail.Subject = MailTitle;
            mail.IsBodyHtml = true;//是否支持HTML
            mail.Body = MailContent;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.exmail.qq.com";//设置发送者邮箱对应的smtpserver
            client.UseDefaultCredentials = false;
            //  client.Port = 465;
            client.Credentials = new NetworkCredential(SendUserName, UserPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(mail);
            }
            catch (SmtpException ex)
            {
                //Console.Write(ex.Message);
            }
            // Console.ReadKey();
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

                for (int i = 1; i < rlast; i++)
                {
                    row = sheet.GetRow(i);
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
                for (int i = 1; i <rlast; i++)
                {
                    for (int j = 2; j < columns; j++)
                    {
                        row = sheet.GetRow(i);
                        var result = QuotationDal.GetPartitionIDByCodeChannelID(Convert.ToString(firstRow.Cells[j]).Trim(), channelID, 890501594632818690);
                        partitionPrice = new logistics_quotation_partition_price();
                        partitionPrice.TenantID = 890501594632818690;
                        partitionPrice.ID = IdWorker.GetID();
                        partitionPrice.firstHeavyPrice = 0;
                        partitionPrice.continuedHeavyPrice = 0;
                        partitionPrice.channelID = channelID;
                        partitionPrice.partitionID = result.ID;
                        partitionPrice.beginHeavy = Convert.ToDecimal(row.Cells[0].ToString());
                        partitionPrice.endHeavy = Convert.ToDecimal(row.Cells[1].ToString());
                        partitionPrice.price = row.Cells[j] == null ? 0 : Convert.ToDecimal(row.Cells[j].ToString());
                        partitionPrice.CreatedBy = 890501594632818690;
                        partitionPrice.ModifiedBy = 890501594632818690;
                        QuotationDal.InsertPartitionPrice(partitionPrice);
                        System.Console.WriteLine("channel id:" + channelID + quotationSheetName + ":" + row.Cells[j]);
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
                        partitionPrice.channelID = channelID;
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

        public void ImportEMSQuotaion(long channelID, String quotationSheetName)
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
                for (int i = 1; i <rlast; i++)
                {
                    for (int j = 2; j < columns; j++)
                    {
                        row = sheet.GetRow(i);
                        var result = QuotationDal.GetPartitionIDByCodeChannelID(Convert.ToString(firstRow.Cells[j]).Trim(), channelID, 890501594632818690);
                        partitionPrice = new logistics_quotation_partition_price();
                        partitionPrice.TenantID = 890501594632818690;
                        partitionPrice.ID = IdWorker.GetID();
                        partitionPrice.firstHeavyPrice = Convert.ToDecimal(row.Cells[0].ToString());
                        partitionPrice.continuedHeavyPrice = Convert.ToDecimal(row.Cells[1].ToString());
                        partitionPrice.channelID = channelID;
                        partitionPrice.partitionID = result.ID;
                       // partitionPrice.beginHeavy = Convert.ToDecimal(row.Cells[0].ToString());
                        //partitionPrice.endHeavy = Convert.ToDecimal(row.Cells[1].ToString());
                        partitionPrice.price = row.Cells[j] == null ? 0 : Convert.ToDecimal(row.Cells[j].ToString());
                        partitionPrice.CreatedBy = 890501594632818690;
                        partitionPrice.ModifiedBy = 890501594632818690;
                        QuotationDal.InsertPartitionPrice(partitionPrice);
                        System.Console.WriteLine("channel id:" + channelID + quotationSheetName + ":" + row.Cells[j]);
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
