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
using System.Data;
using Logistics.Common;


namespace Logistics.Console
{


    public class NpoiMemoryStream : MemoryStream
    {
        public NpoiMemoryStream()
        {
            AllowClose = true;
        }

        public bool AllowClose { get; set; }
        public override void Close()
        {
            if (AllowClose)
                base.Close();
        }
    }

    [Serializable]
    public class AA
    {
        public int a;
    }


    public class Program
    {
        public string path = "Quotation.xls";
        public string tell = "Tel.xlsx";
        public ISheet sheet = null;
        public IWorkbook workbook = null;
        public IRow firstRow = null;
        public int rfirst;
        public int rlast;
        public IRow row;
        public int columnsCount;


        static void Main(string[] args)
        {
            InsertUser("warehouseadmin1", BusinessConstants.Role.wareHouseAdmin);
            InsertUser("warehouseadmin2", BusinessConstants.Role.wareHouseAdmin);
            InsertUser("warehouseadmin3", BusinessConstants.Role.wareHouseAdmin);
            InsertUser("warehouseadmin5", BusinessConstants.Role.wareHouseAdmin);

            //  var strTicket = "18721819403&sj456789&890501594632818690";
            //  var ticketArray = strTicket.Split('&');
            //  var strUser = ticketArray[0];
            //  var strPwd = ticketArray[1];
            //  var strTenantID = ticketArray[2];

            //  //缓存中读取，进行验证token;
            //var result =  MemcachedHelper.Set("11", "11", System.DateTime.Now.AddHours(10));

            //  var result1 = MemcachedHelper.Get("11");
            //  var cachedToken = UserManger.GetTokenCahced(long.Parse(strTenantID), strUser);


            // sendMail("fds718@163.com", "famliytree", "enzo.shi@famliytree.cn", "enzo.shi@famliytree.cn", "Infosys333", "您好！", "这是一封测试邮件!");

            //  Program p = new Program();
            ///  p.ImportCode("Tel.xls", "ss");

            //p.ImportPartion(BusinessConstants.Channel.FEDEXPrior, "FedEX优先快递分区");
            //p.ImportCounty(BusinessConstants.Channel.FEDEXPrior, "FedEX优先快递国家");
            //p.ImportQuotation(BusinessConstants.Channel.FEDEXPrior, "FedEX优先快递价格");


            //p.ImportPartion(BusinessConstants.Channel.FEDEXEconomic, "FedEX经济快递分区");
            //p.ImportCounty(BusinessConstants.Channel.FEDEXEconomic, "FedEX经济快递国家");
            //p.ImportQuotation(BusinessConstants.Channel.FEDEXEconomic, "FedEX经济快递价格");


            //p.ImportPartion(BusinessConstants.Channel.UPSPrior, "UPS优先快递分区");
            //p.ImportCounty(BusinessConstants.Channel.UPSPrior, "UPS优先快递国家");
            //p.ImportQuotation(BusinessConstants.Channel.UPSPrior, "UPS优先快递价格");



            //p.ImportPartion(BusinessConstants.Channel.TNTEconomic, "TNT经济快递分区");
            //p.ImportCounty(BusinessConstants.Channel.TNTEconomic, "TNT优先快递国家");
            //p.ImportQuotation(BusinessConstants.Channel.TNTEconomic, "TNT经济快递价格");


            //p.ImportPartion(BusinessConstants.Channel.TNTPrior, "TNT优先快递分区");
            //p.ImportCounty(BusinessConstants.Channel.TNTPrior, "TNT优先快递国家");
            //p.ImportQuotation(BusinessConstants.Channel.TNTPrior, "TNT优先快递价格");


            //  p.ImportAllCountries("所有国家");

            //p.ImportPartion(BusinessConstants.Channel.EMSStandard, "EMS标准快递分区");
            //p.ImportCounty(BusinessConstants.Channel.EMSStandard, "EMS标准快递国家");
            // p.ImportEMSQuotaion(BusinessConstants.Channel.EMSStandard, "EMS标准快递价格");

            //p.ImportPartion(BusinessConstants.Channel.EUB, "E邮宝分区");
            //p.ImportCounty(BusinessConstants.Channel.EUB, "E邮宝国家");
            //  p.ImportEMSQuotaion(BusinessConstants.Channel.EUB, "E邮宝价格");

            //p.ImportPartion(BusinessConstants.Channel.EMSPreferential, "EMS特惠分区");
            //p.ImportCounty(BusinessConstants.Channel.EMSPreferential, "EMS特惠国家");
            //  p.ImportEMSQuotaion(BusinessConstants.Channel.EMSPreferential, "EMS特惠价格");

            //p.ImportPartion(BusinessConstants.Channel.DHLStandard, "DHL标准快递分区");
            //p.ImportCounty(BusinessConstants.Channel.DHLStandard, "DHL标准快递国家");
            // p.ImportQuotation(BusinessConstants.Channel.DHLStandard, "DHL标准快递价格");
            System.Console.ReadLine();
        }

       public static void InsertUser(string tel, long roleType)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Userid = IdWorker.GetID();
            userInfo.Pwd = HashHelper.ComputeHash("123456");
            userInfo.WebChatID = "";
            userInfo.Token = "";
            userInfo.UserName = "";
            userInfo.TenantID = BusinessConstants.Admin.TenantID;
            userInfo.Email = "";
            userInfo.Tel = tel;
            userInfo.MemeberCode = RuleManger.SetCurrentNo(BusinessConstants.Defkey.user);
            userInfo.CreatedBy = BusinessConstants.Admin.TenantID;
            userInfo.ModifiedBy = BusinessConstants.Admin.TenantID;


            logistics_base_role_user_binding roleUser = new logistics_base_role_user_binding();
            roleUser.TenantID = BusinessConstants.Admin.TenantID;
            roleUser.ID = IdWorker.GetID();
            roleUser.RoleID = roleType;
            roleUser.Userid = userInfo.Userid;
            roleUser.CreatedBy = BusinessConstants.Admin.TenantID;
            roleUser.ModifiedBy = BusinessConstants.Admin.TenantID;

            var dbResult = false;


            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    //更改balance记录；
                    var result = true;
                    result = UserDAL.Insert(userInfo, trans) && RoleDAL.InsertRoleUser(roleUser, trans);
                    return result;
                });
            }


        }

        public void ImportCode(string path, string partitionSheetName)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                workbook = new HSSFWorkbook(fs);

                sheet = workbook.GetSheet(partitionSheetName);
                firstRow = sheet.GetRow(0);
                var lastRow = sheet.LastRowNum;
                var data = new DataTable();
                data.Columns.Add("aa");

                for (int i = 0; i < lastRow; i++)
                {
                    var code = sheet.GetRow(i).Cells[0].ToString();
                    for (int j = 0; j <= 9; j++)
                    {
                        for (int k = 0; k <= 9; k++)
                        {
                            var result = code + j.ToString() + k.ToString() + "86";
                            DataRow row = data.NewRow();
                            row[0] = result;
                            data.Rows.Add(row);
                        }
                    }



                }
                ImportTel(data);
            }
        }


        public void ImportTel(DataTable dt, string importPath = "import.xls")
        {
            //using (FileStream fs = new FileStream(importPath, FileMode.Open, FileAccess.ReadWrite))
            //{
            //    workbook = new HSSFWorkbook(fs);
            //    sheet = workbook.GetSheet("导入模板");

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        IRow row = sheet.CreateRow(dt.Rows.Count);
            //        row.CreateCell(0).SetCellValue("11");
            //        row.CreateCell(4).SetCellValue(dt.Rows[i][0].ToString());
            //    }
            //    workbook.Write(fs);
            //}
            HSSFWorkbook wk =new HSSFWorkbook();
            ISheet tb = wk.CreateSheet("33");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = tb.CreateRow(i);
                row.CreateCell(0).SetCellValue("11");
                row.CreateCell(1).SetCellValue(dt.Rows[i][0].ToString());
            
            }


            using (FileStream fs = File.OpenWrite(importPath))
            {
                wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。

            }


        }

        public static bool DataTableToExcel(DataTable dt)
        {
            bool result = false;
            IWorkbook workbook = null;
            FileStream fs = null;
            IRow row = null;
            ISheet sheet = null;
            ICell cell = null;
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    workbook = new HSSFWorkbook();
                    sheet = workbook.CreateSheet("Sheet0");//创建一个名称为Sheet0的表
                    int rowCount = dt.Rows.Count;//行数
                    int columnCount = dt.Columns.Count;//列数

                    //设置列头
                    row = sheet.CreateRow(0);//excel第一行设为列头
                    for (int c = 0; c < columnCount; c++)
                    {
                        cell = row.CreateCell(c);
                        cell.SetCellValue(dt.Columns[c].ColumnName);
                    }

                    //设置每行每列的单元格,
                    for (int i = 0; i < rowCount; i++)
                    {
                        row = sheet.CreateRow(i + 1);
                        for (int j = 0; j < columnCount; j++)
                        {
                            cell = row.CreateCell(j);//excel第二行开始写入数据
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                    }
                    using (fs = File.OpenWrite(@"D:/import.xls"))
                    {
                        workbook.Write(fs);//向打开的这个xls文件中写入数据
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return false;
            }
        }



        //public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        //{
        //    int i = 0;
        //    int j = 0;
        //    int count = 0;
        //    ISheet sheet = null;

        //    fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        //    if (fileName.IndexOf(".xlsx") > 0) // 2007版本
        //        workbook = new XSSFWorkbook();
        //    else if (fileName.IndexOf(".xls") > 0) // 2003版本
        //        workbook = new HSSFWorkbook();

        //    try
        //    {
        //        if (workbook != null)
        //        {
        //            sheet = workbook.CreateSheet(sheetName);
        //        }
        //        else
        //        {
        //            return -1;
        //        }

        //        if (isColumnWritten == true) //写入DataTable的列名
        //        {
        //            IRow row = sheet.CreateRow(0);
        //            for (j = 0; j < data.Columns.Count; ++j)
        //            {
        //                row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
        //            }
        //            count = 1;
        //        }
        //        else
        //        {
        //            count = 0;
        //        }

        //        for (i = 0; i < data.Rows.Count; ++i)
        //        {
        //            IRow row = sheet.CreateRow(count);
        //            for (j = 0; j < data.Columns.Count; ++j)
        //            {
        //                row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
        //            }
        //            ++count;
        //        }
        //        workbook.Write(fs); //写入到excel
        //        return count;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: " + ex.Message);
        //        return -1;
        //    }
        //}


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

                for (int i = 1; i <= rlast; i++)
                {
                    row = sheet.GetRow(i);
                    if (row.Cells[0].ToString() != "")
                    {
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
                for (int i = 1; i <= rlast; i++)
                {
                    for (int j = 2; j < columns; j++)
                    {
                        row = sheet.GetRow(i);
                        if (row.Cells[0].ToString() != "")
                        {
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
        }

        /// <summary>
        /// 导入IPF
        /// </summary>
        public void ImportIPF(long channelID, string quotationSheetName)
        {

            //using (FileStream fs = new FileStream(path, FileMode.Open))
            //{
            //    IWorkbook workbook = new HSSFWorkbook(fs);
            //    sheet = workbook.GetSheet(quotationSheetName);
            //    rfirst = sheet.FirstRowNum;
            //    rlast = sheet.LastRowNum;
            //    firstRow = sheet.GetRow(rfirst);
            //    var columns = firstRow.Cells.Count();

            //    logistics_quotation_partition_ipf_price partitionPrice = null;
            //    for (int i = 0; i < rlast; i++)
            //    {
            //        for (int j = 2; j < columns; j++)
            //        {
            //            row = sheet.GetRow(i + 1);
            //            var result = QuotationDal.GetPartitionIDByCodeChannelID(Convert.ToString(firstRow.Cells[j]).Trim(), BusinessConstants.Channel.FedxEconomicID, 890501594632818690);
            //            partitionPrice = new logistics_quotation_partition_ipf_price();
            //            partitionPrice.TenantID = 890501594632818690;
            //            partitionPrice.ID = IdWorker.GetID();
            //            partitionPrice.firstHeavyPrice = 0;
            //            partitionPrice.continuedHeavyPrice = 0;
            //            partitionPrice.channelID = channelID;
            //            partitionPrice.partitionID = result.ID;
            //            partitionPrice.beginHeavy = Convert.ToDecimal(row.Cells[0].ToString());
            //            partitionPrice.endHeavy = Convert.ToDecimal(row.Cells[1].ToString());
            //            partitionPrice.price = row.Cells[j] == null ? 0 : Convert.ToDecimal(row.Cells[j].ToString());
            //            partitionPrice.CreatedBy = 890501594632818690;
            //            partitionPrice.ModifiedBy = 890501594632818690;
            //            QuotationDal.InsertPartitionIPFPrice(partitionPrice);
            //            System.Console.WriteLine("channel id:" + channelID + quotationSheetName + ":" + firstRow.Cells[j]);
            //        }


            //   }
            // }
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
                for (int i = 1; i <= rlast; i++)
                {
                    for (int j = 2; j < columns; j++)
                    {
                        row = sheet.GetRow(i);
                        var nextRow = sheet.GetRow(i + 1);
                        if (row.Cells[0].ToString() != "")
                        {
                            var result = QuotationDal.GetPartitionIDByCodeChannelID(Convert.ToString(firstRow.Cells[j]).Trim(), channelID, 890501594632818690);
                            partitionPrice = new logistics_quotation_partition_price();
                            partitionPrice.TenantID = 890501594632818690;
                            partitionPrice.ID = IdWorker.GetID();
                            partitionPrice.firstHeavyPrice = Convert.ToDecimal(row.Cells[j].ToString());
                            partitionPrice.continuedHeavyPrice = Convert.ToDecimal(nextRow.Cells[j].ToString());
                            partitionPrice.channelID = channelID;
                            partitionPrice.partitionID = result.ID;
                            // partitionPrice.beginHeavy = Convert.ToDecimal(row.Cells[0].ToString());
                            //partitionPrice.endHeavy = Convert.ToDecimal(row.Cells[1].ToString());
                            // partitionPrice.price = row.Cells[j] == null ? 0 : Convert.ToDecimal(row.Cells[j].ToString());
                            partitionPrice.CreatedBy = 890501594632818690;
                            partitionPrice.ModifiedBy = 890501594632818690;
                            QuotationDal.InsertPartitionPrice(partitionPrice);
                            System.Console.WriteLine("channel id:" + channelID + quotationSheetName + ":" + row.Cells[j]);
                        }

                    }
                    break;


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
                for (int i = 0; i <= rlast; i++)
                {
                    row = sheet.GetRow(i);
                    if (row.Cells[0].ToString() != "")
                    {
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
}
