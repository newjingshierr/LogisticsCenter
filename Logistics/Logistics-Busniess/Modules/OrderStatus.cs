using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;
using Logistics.Core;
using Akmii.Cache.Client;
using Logistics_DAL;
using Logistics.Common;

namespace Logistics_Busniess
{
    public class OrderStatus
    {
        public static OrderStatusSummaryView SelectOrderStatusByUserID(OrderStatusRequest item)
        {
            var result = new OrderStatusSummaryView();
            var model = Logistics_DAL.OrderStatus.SelectOrderStatusByUserID(item.userID);
            if (model == null)
            {
                throw new LogisticsException(SystemStatusEnum.OrderException, $"Order Exception");
            }
            else
            {
                result = model;
            }
            return result;

        }
    }
}
