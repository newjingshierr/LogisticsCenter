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


        public static bool InsertSMSValidate(SmsValidateRequest item)
        {
            logistics_base_sms_validate smsValidate = new logistics_base_sms_validate();
            smsValidate.ID = IdWorker.GetID();
            smsValidate.code = item.code;
            smsValidate.tel = item.tel;
            smsValidate.TenantID = item.TenantID;
            smsValidate.startTime = System.DateTime.Now;
            smsValidate.endTime = smsValidate.startTime.AddMinutes(15);
            smsValidate.CreatedBy = BusinessConstants.Admin.TenantID;
            smsValidate.ModifiedBy = BusinessConstants.Admin.TenantID;
            return SmsValidateDal.Insert(smsValidate);
        }

        public static bool CheckSmsValidate(CheckSmsValidateRequest item)
        {
            var smsValidate = SmsValidateDal.GetItem(item.TenantID, item.tel);
            return SmsValidateDal.ChekcItem(item.TenantID, item.tel, item.code, smsValidate.startTime, smsValidate.endTime) == null ? false : true;
        }

        public static bool SendSMSValidate(SendSMSValidateRequest request)
        {
            var radmon = SMSHelper.GetRandom();
            var sendResult = SMSHelper.send(radmon, SMSTypeEnum.Register, request.tel);
            var result = false;
            if (sendResult)
            {
                SmsValidateRequest InsertRequest = new SmsValidateRequest();
                InsertRequest.code = radmon;
                InsertRequest.tel = request.tel;
                InsertRequest.TenantID = request.TenantID;
                result = InsertSMSValidate(InsertRequest);
            }
            return result;
        }



    }
}
