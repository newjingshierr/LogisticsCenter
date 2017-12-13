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


namespace Logistics.Controllers
{
    public class QuotationController : BaseController
    {
        [HttpGet]
        [Route("Item")]
        public ResponseMessage<List<QuotationChannelPriceVM>> GetQuotationPriceByCountry([FromUri] GetQuotationPriceByCountryRequest request)
        {

            var result = new List<QuotationChannelPriceVM>();

            try
            {
                result = QuotationManager.GetChannelPrice(request);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }
    }
}
