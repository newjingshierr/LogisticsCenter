using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logistics_Busniess;
using Logistics_Model;
using Logistics.Core;
using Akmii;
using Logistics.Common;
using System.Data;

namespace Logistics.Controllers
{
    [RoutePrefix(ApiConstants.PrefixApi + "InvestmentProject")]
    public class InvestmentProjectController : BaseController
    {
        [HttpPost]
        [Route("Item")]
        public ResponseMessage<string> Insert(DemoBatchInsert request)
        {
          
            DataTable tblDatas = new DataTable("Datas");
            DataColumn dc = null;
            //賦值給dc，是便於對每一個datacolumn的操作
            dc = tblDatas.Columns.Add("ID", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自動增加
            dc.AutoIncrementSeed = 1;//起始為1
            dc.AutoIncrementStep = 1;//步長為1
            dc.AllowDBNull = false;//

            dc = tblDatas.Columns.Add("projectName", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("sex", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("age", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("str1", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("str2", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("str3", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("str4", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("str5", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("str6", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("remark", Type.GetType("System.String"));
            DataRow newRow;
            newRow = tblDatas.NewRow();
            newRow["projectName"] = "張三";
            newRow["sex"] = "男";
            newRow["age"] = "11";
            newRow["str1"] = "字符串1";
            newRow["str2"] = "字符串2";
            newRow["str3"] = "字符串3";
            newRow["str4"] = "字符串4";
            newRow["str5"] = "字符串5";
            newRow["str6"] = "字符串6";
            newRow["remark"] = "備註一下";
            tblDatas.Rows.Add(newRow);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("$projectName$", "projectName");

            string tempFile = "~/InvestmentProjectTemplate.docx";
            string saveFile = "~/InvestmentProjectTemplate11.docx";
            WordUtility w = new WordUtility(tempFile, saveFile);
            w.GenerateWord(tblDatas, dic, null);

            var result = false;

            try
            {
                result = DemoManger.BatchInsert(request.demos);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);
            }

        }
    }

}
