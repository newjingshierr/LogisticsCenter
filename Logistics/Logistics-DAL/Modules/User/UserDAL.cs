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
        public static bool Insert(UserInfo model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_Userid", model.Userid),
                        new MySqlParameter("@_Email",model.Email),
                        new MySqlParameter("@_Pwd", model.Pwd),
                        new MySqlParameter("@_MemeberCode",model.MemeberCode),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
                        new MySqlParameter("@_Tel",model.Tel),

            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Demo.Demo_Insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Demo.Demo_Insert, parameters);
            }
            return result == 1;

        }
    }
}
