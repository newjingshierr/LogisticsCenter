using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class RuleDAL
    {
        public static string SetCurrentNo(string defKey, AkmiiMySqlTransaction trans = null)
        {
            var currentNo = "";
            var flowNo = new MySqlParameter("@_CurrentNo", currentNo) { Direction = ParameterDirection.Output };
            MySqlParameter[] parameters = {
                new MySqlParameter("@_DefKey",defKey) ,
                flowNo
            };

            if (trans == null)
            {
                AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteDB(), CommandType.StoredProcedure,
                   Proc.Rule.Logistics_Businessnorule_Update_CurrentNo, parameters);
            }
            else
            {
                AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure,
                 Proc.Rule.Logistics_Businessnorule_Update_CurrentNo, parameters);
            }

            currentNo = flowNo.Value + "";

            return currentNo;
        }
    }
}
