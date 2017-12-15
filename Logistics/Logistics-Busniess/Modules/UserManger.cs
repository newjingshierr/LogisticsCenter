using Logistics_Model;
using Logistics.Core;
using Logistics_DAL;
using Logistics.Common;

namespace Logistics_Busniess
{
    public class UserManger
    {

        public static bool InsertUser(UserRegisterRequest item)
        {

            UserInfo userInfo = new UserInfo();
            userInfo.Userid = IdWorker.GetID();
            userInfo.Pwd = HashHelper.ComputeHash(item.pwd);
            userInfo.Email = item.mail;
            userInfo.WebChatID = "";
            userInfo.Token = "";
            userInfo.UserName = "";
            userInfo.TenantID = item.TenantID;
            userInfo.Tel = item.tel;
            userInfo.MemeberCode = RuleManger.SetCurrentNo(BusinessConstants.Defkey.user);
            userInfo.CreatedBy = BusinessConstants.Admin.TenantID;
            userInfo.ModifiedBy = BusinessConstants.Admin.TenantID;
            return UserDAL.Insert(userInfo);
        }

        public static UserInfo ValidateUser(LoginRequest request)
        {
            return UserDAL.ValidateUser(request.TenantID, request.user, HashHelper.ComputeHash(request.pwd));
        }


        public static bool InsertSMSValidate(ValidateRequest item)
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
            return ValidateDal.Insert(smsValidate);
        }

        public static bool CodeValidate(ValidateRequest item)
        {
            var smsValidate = ValidateDal.GetItem(item.TenantID, item.tel, item.mail);
            return ValidateDal.ChekcItem(item.TenantID, item.tel, item.mail, item.code, smsValidate.startTime, smsValidate.endTime) == null ? false : true;
        }

        public static bool ValidateUser(UserValidateRequest item)
        {
            return UserDAL.ValidateUser(item.TenantID, item.user) == null ? false : true;
        }

        public static bool SendSMS(SendSMSRequest request)
        {
            var radmon = SMSHelper.GetRandom();
            var sendResult = SMSHelper.send(radmon, SMSTypeEnum.Register, request.tel);
            var result = false;
            if (sendResult)
            {
                ValidateRequest InsertRequest = new ValidateRequest();
                InsertRequest.code = radmon;
                InsertRequest.tel = request.tel;
                InsertRequest.TenantID = request.TenantID;
                result = InsertSMSValidate(InsertRequest);
            }
            return result;
        }

    }
}
