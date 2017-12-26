using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class RoleDAL
    {
        public static bool InsertRoleUser(logistics_base_role_user_binding model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                       new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID", model.ID),
                        new MySqlParameter("@_RoleID",model.RoleID),
                         new MySqlParameter("@_UserID",model.Userid),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Role.logistics_base_role_user_binding_Insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Role.logistics_base_role_user_binding_Insert, parameters);
            }
            return result == 1;

        }


        public static logistics_base_role SelectRoleItem(long TenantID, long userid)
        {
            var result = new logistics_base_role();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                new MySqlParameter("@_userid", userid),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Role.logistics_base_role_select_by_userid, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_role>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }
    }
}
