using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;
using Logistics_DAL;


namespace Logistics_Busniess
{
    public class DemoManger
    {
        public static List<demo> GetAllByName(DemoGetByNameRequest request, ref int totalCount)
        {
            return DemoDAL.GetAllByName(request, ref totalCount);

        }
    }
}
