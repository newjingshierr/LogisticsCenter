using Logistics_Model;
using Logistics.Core;
using Logistics_DAL;
using Logistics.Common;
using System;
using System.Data;
using System.Collections.Generic;

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

        public static bool ValidateUser(LoginRequest request,out long userID)
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
            userID = userInfo.Userid;
            return dbResult;

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
            if (smsValidate == null)
            {
                throw new LogisticsException(SystemStatusEnum.InvalidTelOrMailRequest, $"Invalid Tel Or Mail Request");
            }
            if (smsValidate.code != item.code)
            {
                throw new LogisticsException(SystemStatusEnum.ExpiredCodeRequest, $"Expired Code Request");
            }

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

        public static bool ExistUser(UserValidateRequest item)
        {
            var result = false;
            result = UserDAL.ValidateUser(item.TenantID, item.user) == null ? true : false;
            if (result == false)
            {
                throw new LogisticsException(SystemStatusEnum.InvalidUserExistRequest, $"User Exist Request");
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


            var smsValidate = ValidateDal.GetItem(request.TenantID, request.tel, request.mail);
            if (smsValidate != null)
            {
                ///检查操作是否过于频繁；检查的逻辑，根据手机号或者邮箱去检查之前的最近的一条的创建时间和现在的时间间隔是否有超过1分钟；
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

        public static string GetTokenCahced(long TenantID, string usr, bool isCache = true, string token = null)
        {

            var key = CacheConstants.GetToken(usr, TenantID);

            if (!isCache)
            {
                MemcachedHelper.Remove(key);
            }

            var result = MemcachedHelper.GetOrSet(key, () =>
            {
                var model = token;
                return model;

            }, CacheConstants.GetTokenTime()).Result;
            return result;
        }

        public static string GetTokenCached(string key)
        {
            return MemcachedHelper.Get(key).ToString();
        }
        public static bool RemoveTokenCached(long TenantID, string user)
        {
            var key = CacheConstants.GetToken(user, TenantID);

            var resultToken = MemcachedHelper.Get(key);

            var result = false;
            if (!string.IsNullOrEmpty(user))
            {
                result = MemcachedHelper.Remove(key);
            }
            if (!result)
            {
                throw new LogisticsException(SystemStatusEnum.SigoutErrorRequest, $"Sigout Error Request");
            }

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

        public static ContextInfo GetCurrentInfo(long TenantID, string user)
        {
            ContextInfo currentInfo = new ContextInfo();
            var userInfo = new UserInfo();

            userInfo = UserDAL.ValidateUser(TenantID, user);
            var role = new logistics_base_role();
            if (userInfo != null)
            {
                role = RoleDAL.SelectRoleItem(userInfo.Userid);
            }
            else
            {
                throw new LogisticsException(SystemStatusEnum.InvalidUserNameRequest, $"Invalid UserName Request:{ user}");
            }

            if (role == null)
            {
                throw new LogisticsException(SystemStatusEnum.InvalidRoleRequest, $"Invalid Role Request:{ user}");
            }

            var navigations = new List<logistics_base_navigation>();
            navigations = NavigationDal.SelectNavigationItemsByRoleID(role.RoleID);
            NavigationView navigationView = new NavigationView();
            List<NavigationView> navigationViewList = new List<NavigationView>();
            foreach (var o in navigations)
            {
                navigationView.parentItem = o;
                navigationView.childItems = NavigationDal.SelectNavigationChildrenItems(o.ID);
                navigationViewList.Add(navigationView);
            }
            if (navigationViewList == null)
            {
                throw new LogisticsException(SystemStatusEnum.NavigationNotFound, $"Navigation Not Found:{ user}");
            }

            currentInfo.userInfo = userInfo;
            currentInfo.role = role;
            currentInfo.navigations = navigationViewList;

            return currentInfo;
        }

        public static ContextInfo GetCurrentInfoCahced(long TenantID, string usr, bool isCache = true, ContextInfo currentInfo = null)
        {
            var key = CacheConstants.GetCurrentInfo(usr, TenantID);

            if (!isCache)
            {
                MemcachedHelper.Remove(key);
            }
            var result = MemcachedHelper.GetOrSet(key, () =>
            {
                var model = currentInfo;
                return model;

            }, CacheConstants.GetCurrentInfoTime()).Result;
            return result;
        }
    }
}
