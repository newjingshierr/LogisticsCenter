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
    }
}
