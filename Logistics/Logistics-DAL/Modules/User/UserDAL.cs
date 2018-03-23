using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;
namespace Logistics_DAL
{
    public class UserDAL
    {
        public static UserInfo ValidateUser(long TenantID, string user)
        {
            var result = new UserInfo();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_User", user),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.logistics_userInfo_validate, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<UserInfo>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }


        public static UserInfo ValidateUser(long TenantID, string user, byte[] Pwd)
        {
            var result = new UserInfo();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_User", user),
                 new MySqlParameter("@_Pwd", Pwd),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.Logistics_UserInfo_Select, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<UserInfo>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool Insert(UserInfo model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                       new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_Userid", model.Userid),
                        new MySqlParameter("@_Email",model.Email),
                         new MySqlParameter("@_Token",""),
                        new MySqlParameter("@_Username",""),
                        new MySqlParameter("@_Pwd", model.Pwd),
                        new MySqlParameter("@_Tel", model.Tel),
                         new MySqlParameter("@_WebChatID",""),
                        new MySqlParameter("@_MemeberCode",model.MemeberCode),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.Logistics_UserInfo_Insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.User.Logistics_UserInfo_Insert, parameters);
            }
            return result == 1;

        }

        public static bool InsertUserInfoLog(logistics_base_userinfo_log model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                       new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID", model.ID),
                        new MySqlParameter("@_Userid", model.Userid),
                        new MySqlParameter("@_userIP",model.userIP),
                         new MySqlParameter("@_type",model.type),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.logistics_base_userinfo_log_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.User.logistics_base_userinfo_log_insert, parameters);
            }
            return result == 1;

        }

        public static UserInfo SelectUserLogByTime(DateTime startTime, DateTime endTime, long userid, long tenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new UserInfo();

            MySqlParameter[] parameters = {
                       new MySqlParameter("@_TenantID", tenantID),
                       new MySqlParameter("@_userID",userid),
                        new MySqlParameter("@_startTime",startTime),
                        new MySqlParameter("@_endTime",endTime),
                
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.logistics_base_userinfo_log_select_by_time, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<UserInfo>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool UpdateUser(UserInfo model, AkmiiMySqlTransaction trans = null)
        {
            MySqlParameter[] parameters = {
                       new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_Userid", model.Userid),
                        new MySqlParameter("@_Pwd", model.Pwd),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.logistics_userinfo_update_pwd, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.User.logistics_userinfo_update_pwd, parameters);
            }
            return result == 1;
        }

        public static List<UserInfo> SelectMemberIndex(string Name, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<UserInfo>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_Name",Name)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.logistics_base_userinfo_select_member_index, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<UserInfo>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }

        public static List<UserInfo> SelectCusteomrerServiceIndex(string Name, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<UserInfo>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_Name",Name)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.logistics_base_userinfo_select_customer_service_index, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<UserInfo>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }


        public static List<UserInfo> SelectWarehouseAdminIndex(string Name, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<UserInfo>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_Name",Name)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.logistics_base_userinfo_select_warehouse_admin_index, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<UserInfo>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }

        public static List<UserInfo> SelectAllUserInfo(long TenantID)
        {
            var result = new List<UserInfo>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID)
 
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.User.logistics_base_userinfo_select_all, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<UserInfo>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }

    }
}
