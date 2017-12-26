using Logistics_Model;
using Logistics.Core;
using Logistics_DAL;
using Logistics.Common;

namespace Logistics_Busniess.Modules
{
    public class RoleManager
    {
        public static logistics_base_role ValidateUser(LoginRequest request)
        {
            var dbResult = false;


            var userInfo = UserDAL.ValidateUser(request.TenantID, request.user, HashHelper.ComputeHash(request.pwd));
            dbResult = userInfo == null ? false : true;
            if (dbResult)
            {
                logistics_base_userinfo_log userinfoLog = new logistics_base_userinfo_log();
                userinfoLog.TenantID = BusinessConstants.Admin.TenantID;
                userinfoLog.ID = IdWorker.GetID();
                userinfoLog.Userid = userInfo.Userid;
                userinfoLog.userIP = SystemHelper.GetHostAddress();
                userinfoLog.type = (int)UserInfoLogEnum.LognIn;
                userinfoLog.CreatedBy = BusinessConstants.Admin.TenantID;
                userinfoLog.ModifiedBy = BusinessConstants.Admin.TenantID;
                dbResult = dbResult && UserDAL.InsertUserInfoLog(userinfoLog);
            }
            return null;

        }

    }
}
