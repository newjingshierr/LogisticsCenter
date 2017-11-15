
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Logistics
{
    public class BaseController : ApiController
    {

        public BaseController()
        {
        }

        protected ResponseMessage<T> GetErrorResult<T>(T data, string message = "", int status = -1)
        {
            return new ResponseMessage<T>
            {
                Data = data,
                Status = status,
                Message = message
            };
        }

        protected ResponseMessage<T> GetResult<T>(T data, int totalCount)
        {
            return new ResponseMessage<T>
            {
                Data = data,
                TotalCount = totalCount,
                Status = 0,
                Message = "success"
            };
        }


      


    }
}