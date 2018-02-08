using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{
   public class  GetAllCountryByNameRequest:BaseRequest
    {
        public string name { get; set; } = "";
    }
    public class GetQuotationPriceByCountryRequest:BaseRequest
    {
        public string country { get; set; } = "";
        public decimal weight { get; set; } = 0;

        public decimal length { get; set; } = 0;

        public decimal width { get; set; } = 0;

        public decimal height { get; set; } = 0;


    }
    public class GetAllChannelsRequest : BaseRequest
    {

    }
}
