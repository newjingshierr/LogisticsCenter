using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics_Model;
using Logistics.Core;
using Logistics_DAL;
using Logistics.Common;
using Logistics_Busniess;

namespace Logistics_Busniess
{
    public class UserManger
    {
        public static bool Insert(UserRegisterRequest item)
        {

            UserInfo userInfo = new UserInfo();
            userInfo.Userid = IdWorker.GetID();
            userInfo.Pwd = item.Pwd;
            userInfo.Email = item.Email;
            userInfo.Tel = item.Tel;
            userInfo.MemeberCode = RuleManger.SetCurrentNo(BusinessConstants.Defkey.user);
            userInfo.CreatedBy = userInfo.Userid;
            userInfo.ModifiedBy = userInfo.Userid;
            return Logistics_DAL.UserDAL.Insert(userInfo);





        }
    }
}
