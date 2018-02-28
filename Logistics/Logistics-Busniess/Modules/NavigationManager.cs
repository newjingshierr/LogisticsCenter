using Logistics_Model;
using Logistics.Core;
using Logistics_DAL;
using Logistics.Common;
using System;
using System.Data;
using System.Collections.Generic;


namespace Logistics_Busniess
{
    public class NavigationManager
    {
        public static List<logistics_base_navigation> GetNavgationListByUserID(GetNavgationListRequest request)
        {
            var role = RoleDAL.SelectRoleItem(request.userID);
            var navigationList = NavigationDal.SelectNavigationItemsByRoleID(request.userID);
            if (navigationList == null)
            {
                throw new LogisticsException(SystemStatusEnum.NavigationNotFound, $"Navigation Not Found");
            }
            return navigationList;
        }
    }
}
