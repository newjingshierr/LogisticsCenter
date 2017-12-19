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


            logistics_base_role_user_binding roleUser = new logistics_base_role_user_binding();
            roleUser.TenantID = BusinessConstants.Admin.TenantID;
            roleUser.ID = IdWorker.GetID();
            roleUser.RoleID = BusinessConstants.Role.member;
            roleUser.Userid = userInfo.Userid;
            userInfo.CreatedBy = BusinessConstants.Admin.TenantID;
            userInfo.ModifiedBy = BusinessConstants.Admin.TenantID;

            ValidateRequest request = new ValidateRequest();
            request.code = item.code;
            request.mail = item.mail;
            request.tel = item.tel;
            if (!CodeValidate(request))
            {
                throw new LogisticsException(SystemStatusEnum.InvalidCodeRequest, $"code is not valid:{ item.code}");
            }


            var dbResult = false;

            using (var conn = ConnectionManager.GetWriteConn())
            {
                dbResult = Akmii.Core.DataAccess.AkmiiMySqlHelper.ExecuteInTransaction(conn, (trans) =>
                {
                    //更改balance记录；
                    var result = true;
                    result = UserDAL.Insert(userInfo, trans) && RoleDAL.InsertRoleUser(roleUser, trans);
                    return result;
                });
            }

            return dbResult;
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
            smsValidate.mail = item.mail;
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
            var result = false;
            result = ValidateDal.ChekcItem(item.TenantID, item.tel, item.mail, item.code, smsValidate.startTime, smsValidate.endTime) == null ? false : true;

            if (result == false)
            {
                throw new LogisticsException(SystemStatusEnum.InvalidCodeRequest, $"code is not valid:{ item.code}");
            }
            return result;
        }

        public static bool ValidateUser(UserValidateRequest item)
        {
            return UserDAL.ValidateUser(item.TenantID, item.user) == null ? false : true;
        }

        public static bool SendSMS(SendSMSRequest request)
        {
            var radmon = SMSHelper.GetRandom();
            var result = false;
            var sendResult = false;

            if (request.type == SendTypeEnum.Tel)
            {
                if (string.IsNullOrEmpty(request.tel))
                {
                    throw new LogisticsException(SystemStatusEnum.InvalidTelOrMailRequest, $"InvalidTelOrMailRequest");
                }

                sendResult = SMSHelper.Send(radmon, SMSTypeEnum.Register, request.tel);
            }
            else if (request.type == SendTypeEnum.Mail)
            {
                if (string.IsNullOrEmpty(request.mail))
                {
                    throw new LogisticsException(SystemStatusEnum.InvalidTelOrMailRequest, $"InvalidTelOrMailRequest");
                }
                sendResult = MailHelper.Send(request.mail, radmon, MailTemplateEnum.Register);
            }

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

        public static AllUserInfo GetAllUserInfoCahced(long TenantID, string usr, bool isCache = true, bool isWrite = false, AllUserInfo allInfo = null)
        {
            var key = CacheConstants.GetAllInfo(usr, TenantID);

            if (!isCache)
            {
                MemcachedHelper.Instance().Remove(key);
            }

            var result = MemcachedHelper.Instance().GetOrSet(key, () =>
            {
                var model = allInfo;

                return model;

            }, CacheConstants.GetGetAllInfoTime()).Result;
            return result;
        }

    }
}
