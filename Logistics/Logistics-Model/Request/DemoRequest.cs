using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
    public class DemoGetByNameRequest
    {
        public string name { get; set; } = "";

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
