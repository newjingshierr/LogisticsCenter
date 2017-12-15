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
                         new MySqlParameter("@_UserID",model.RoleID),
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
    }
}
