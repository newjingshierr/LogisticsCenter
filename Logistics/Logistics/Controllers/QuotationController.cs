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
    [RoutePrefix(ApiConstants.PrefixApi + "Quotation")]
    public class QuotationController : BaseController
    {
        [HttpGet]
        [Route("Item")]
        public ResponseMessage<List<QuotationChannelPriceVM>> GetQuotationPriceByCountry([FromUri] GetQuotationPriceByCountryRequest request)
        {
            if (request == null)
            {
                return GetErrorResult<List<QuotationChannelPriceVM>>(SystemStatusEnum.InvalidRequest);
            }
            var result = new List<QuotationChannelPriceVM>();
           
            try
            {
                result = QuotationManager.GetChannelPrice(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }

        [HttpGet]
        [Route("Country/Items")]
        public ResponseMessage<List<logistics_base_country>> GetAllCountryByName([FromUri] GetAllCountryByNameRequest request)
        {
            if (request == null)
            {
                request = new GetAllCountryByNameRequest();
            }

            var result = new List<logistics_base_country>();

            try
            {
                result = QuotationManager.GetAllCountryByName(request);

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }




    }

    [RoutePrefix(ApiConstants.PrefixApi + "Channel")]
    public class ChannelsController :BaseAuthController
    {
        [HttpGet]
        [Route("Items")]
        public ResponseMessage<List<logistics_quotation_channel>> GetAllChannels()
        {
          
            var result = new List<logistics_quotation_channel>();

            try
            {
                result = QuotationManager.GetAllChannels();

                return GetResult(result);
            }
            catch (LogisticsException ex)
            {
                return GetErrorResult(result, ex.Status.ToString(), (int)ex.Status);

            }

        }
    }
}
