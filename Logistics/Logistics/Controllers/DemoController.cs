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
    [RoutePrefix(ApiConstants.PrefixApi + "Demo")]
    public class DemoController : BaseController
    {
        /// <summary>
        /// 根据Name 查找Demo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public ResponseMessage<List<demo>> DemoGetAll([FromUri] DemoGetByNameRequest request)
        {


            LogHelper log = LogHelper.GetLogger(typeof(DemoController));
            log.ErrorFormat("HolidayBalanceInsert is error!");

            int totalCount = 0;
            if (request.PageIndex < 1)
                request.PageIndex = 1;
            if (request.PageSize < 1)
                request.PageSize = 20;
            var result = new List<demo>();

            try
            {
                result = DemoManger.GetAllByName(request, ref totalCount);

                return GetResult(result, totalCount);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }

        [HttpPost]
        [Route("Items")]
        public ResponseMessage<string> BatchInsert(DemoBatchInsert request)
        {

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



        [HttpPost]
        [Route("Item")]
        public ResponseMessage<string> Insert([FromUri] demo request)
        {

            var result = false;
            try
            {
                result = DemoManger.Insert(request);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);
            }

        }


        [HttpPut]
        [Route("Item")]
        public ResponseMessage<string> Update([FromUri] DemoUpdateRequest request)
        {

            var result = false;
            try
            {
                result = DemoManger.UpdateDemoByID(request);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }

        }


        [HttpDelete]
        [Route("Item")]
        public ResponseMessage<string> Delete([FromUri] DemoDeleteRequest request)
        {

            var result = false;
            try
            {
                result = DemoManger.DeleteDemoByID(request);

                return GetResult(result.ToString());
            }
            catch (Exception ex)
            {
                return GetErrorResult(result.ToString(), ex.Message);

            }

        }


        [HttpGet]
        [Route("Item")]
        public ResponseMessage<demo> Get([FromUri] DemoGetRequest request)
        {

            var result = new demo();
            try
            {
                result = DemoManger.GetDemoByIDCahced(request);

                return GetResult(result);
            }
            catch (Exception ex)
            {
                return GetErrorResult(result, ex.Message);

            }

        }




    }
}
