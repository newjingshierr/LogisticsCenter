using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics
{
    public class ResponseMessage<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { set; get; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { set; get; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { set; get; }
        /// <summary>
        /// 数据总个数
        /// </summary>
        public int TotalCount { set; get; }
    }
}