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
        public ResponseMessage<decimal> GetQuotationPriceByCountry([FromUri] GetQuotationPriceByCountryRequest request)
        {

            var result = (decimal)0;

            try
            {
                result = QuotationManager.GetQuotationPriceByCountry(request);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }
    }
}
