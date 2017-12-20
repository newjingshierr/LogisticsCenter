using Logistics_Model;
using Logistics.Core;
using Logistics_DAL;
using Logistics.Common;
using System;

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
            roleUser.CreatedBy = BusinessConstants.Admin.TenantID;
            roleUser.ModifiedBy = BusinessConstants.Admin.TenantID;

            ValidateRequest request = new ValidateRequest();
            request.code = item.code;
            request.mail = item.mail;
            request.tel = item.tel;
            if (!ValidateCode(request))
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
            smsValidate.endTime = smsValidate.startTime.AddMinutes(15);//15分钟有效期
            smsValidate.CreatedBy = BusinessConstants.Admin.TenantID;
            smsValidate.ModifiedBy = BusinessConstants.Admin.TenantID;
            return ValidateDal.Insert(smsValidate);
        }

        public static bool ValidateCode(ValidateRequest item)
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

        public static bool ValidateCodeRate(ValidateRequest item)
        {
            var smsValidate = ValidateDal.GetItem(item.TenantID, item.tel, item.mail);
            var result = false;
            TimeSpan timeSpan = DateTime.Now - smsValidate.Created;

            result = timeSpan.TotalMinutes < 1 ? true : false;

            if (result == true)
            {
                throw new LogisticsException(SystemStatusEnum.OperateRateRequest, $"operate exceed limit");
            }
            return result;
        }

        public static bool ValidateUser(UserValidateRequest item)
        {
            var result = false;
            result = UserDAL.ValidateUser(item.TenantID, item.user) == null ? true : false;
            if (result == false)
            {
                throw new LogisticsException(SystemStatusEnum.InvalidUserExistRequest, $"User Exist Request");
            }
            return result;
        }

        public static bool SendSMS(SendSMSRequest request)
        {
            var radmon = SMSHelper.GetRandom();
            var result = false;
            var sendResult = false;

            ///检查操作是否过于频繁；检查的逻辑，根据手机号或者邮箱去检查之前的最近的一条的创建时间和现在的时间间隔是否有超过1分钟；
            var smsValidate = ValidateDal.GetItem(request.TenantID, request.tel, request.mail);
            if (smsValidate != null)
            {
                TimeSpan timeSpan = DateTime.Now - smsValidate.Created;
                var CodeRateResult = timeSpan.TotalMinutes < 1 ? true : false;
                if (CodeRateResult == true)
                {
                    throw new LogisticsException(SystemStatusEnum.OperateRateRequest, $"operate exceed limit");
                }
            }

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
                InsertRequest.mail = request.mail;

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

        public static bool UpdateUserPass(UpdateUserPwdRequest item)
        {
            var result = false;
            ValidateRequest validateCodeRequest = new ValidateRequest();
            validateCodeRequest.code = item.code;
            validateCodeRequest.mail = item.mail;
            validateCodeRequest.tel = item.tel;
            var userInfo = new UserInfo();
            var userInfo1 = new UserInfo();

            if (ValidateCode(validateCodeRequest))
            {
                var user = item.mail == "" ? item.tel : item.tel;
                userInfo = UserDAL.ValidateUser(item.TenantID, user);
                if (userInfo == null)
                {
                    throw new LogisticsException(SystemStatusEnum.InvalidUserExistRequest, $"Invalid User Exist Request");
                }
                userInfo1 = UserDAL.ValidateUser(item.TenantID, user, HashHelper.ComputeHash(item.pwd));
                if (userInfo1 != null)
                {
                    throw new LogisticsException(SystemStatusEnum.BadPwdRequest, $"Bad Pwd Request");
                }

            }
            userInfo.Pwd = HashHelper.ComputeHash(item.pwd);
            result = UserDAL.UpdateUser(userInfo);
            return result;
        }

    }
}
