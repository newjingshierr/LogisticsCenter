using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Common
{
    public class DecimalHelper
    {
        public static decimal formate(decimal value)
        {
            return Convert.ToDecimal(value.ToString("0.00"));
        }

        /// <summary>
        ///    //(长度>2.7米或者两个短边相加和乘以2+最长边 >330cm或者单件实重超过68KG),这是针对于单个的货物；
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static bool IPFRule(decimal length, decimal width, decimal height, decimal weight)
        {
            decimal[] VolumeArray = new decimal[] { length, width, height };
            var VolumeArrayDesc = VolumeArray.OrderByDescending(x => x).ToArray();

            var result = false;
            if (length > 270)
            {
                result = true;
            }
            else if (weight > 68)
            {
                result = true;
            }
            else if ((VolumeArrayDesc[1] + VolumeArrayDesc[2]) * 2 + VolumeArrayDesc[0] > 330)
            {
                result = true;
            }
            return result;
        }

    }
}
