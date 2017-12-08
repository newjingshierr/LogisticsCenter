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
            userInfo.Pwd = HashHelper.ComputeHash(item.Pwd);
            userInfo.Email = item.Email;
            userInfo.WebChatID = "";
            userInfo.Token = "";
            userInfo.UserName = "";
            userInfo.TenantID = item.TenantID;
            userInfo.Tel = item.Tel;
            userInfo.MemeberCode = RuleManger.SetCurrentNo(BusinessConstants.Defkey.user);
            userInfo.CreatedBy = BusinessConstants.Admin.TenantID;
            userInfo.ModifiedBy = BusinessConstants.Admin.TenantID;
            return UserDAL.Insert(userInfo);
        }

        public static bool CheckPwd(long TenantID, long userID, string Pwd)
        {
            return UserDAL.CheckPwd(TenantID, userID, HashHelper.ComputeHash(Pwd)) == null ? false : true;
        }


    }
}
