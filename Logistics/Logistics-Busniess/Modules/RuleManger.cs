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
using System.Text.RegularExpressions;
using Logistics.Common;

namespace Logistics_Busniess
{
    public class RuleManger
    {
        /// <summary>
        ///  生成编号；
        ///  会员编号：defKey: user
        ///  用户订单：defKey: customerorder
        /// </summary>
        /// <param name="tenantID"></param>
        /// <param name="defKey"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static string SetCurrentNo( string defKey)
        {
            return FormatRuleNo(RuleDAL.SetCurrentNo( defKey));
        }

        private static string FormatRuleNo(string flowNo)
        {
            if (string.IsNullOrWhiteSpace(flowNo))
            {
                return flowNo;
            }

            Regex regex = new Regex("{(?<Column>[\\w]*?)}", RegexOptions.IgnoreCase);
            var matchs = regex.Matches(flowNo);
            ClockUtil clockUtil = new ClockUtil(TimeZoneInfo.Local);
            foreach (Match item in matchs)
            {
                var key = item.Groups["Column"].Value + "";
                switch (key.ToLower())
                {
                    case "date":
                        flowNo = flowNo.Replace(item.Value, clockUtil.Now.ToString("yyyyMMdd"));
                        break;
                    case "yymmdd":
                        flowNo = flowNo.Replace(item.Value, clockUtil.Now.ToString("yyMMdd"));
                        break;
                    case "mmdd":
                        flowNo = flowNo.Replace(item.Value, clockUtil.Now.ToString("MMdd"));
                        break;
                    case "time":
                        flowNo = flowNo.Replace(item.Value, clockUtil.Now.ToString("HHmmss"));
                        break;
                    default:
                        break;
                }
            }

            return flowNo;
        }


    }
}
