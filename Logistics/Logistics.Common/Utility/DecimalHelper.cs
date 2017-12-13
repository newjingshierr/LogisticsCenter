using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Common
{
    public class DecimalHelper
    {
        public static decimal  formate(decimal value)
        {
          return  Convert.ToDecimal(value.ToString("0.00"));
        }
    }
}
