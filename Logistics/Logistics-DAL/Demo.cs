using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;

namespace Logistics_DAL
{
    public class DemoDAL : DalBase
    {
        public static bool Insert(demo model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_name", model.Name),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy)
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
        public static List<demo> GetAllByName(DemoGetByNameRequest request, ref int totalCount, AkmiiMySqlTransaction trans = null)
        {
            var list = new List<demo>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",""),
                 new MySqlParameter("@_CreatedBy",""),
                new MySqlParameter("@_name",request.name),
                new MySqlParameter("@_PageIndex", request.PageIndex),
                new MySqlParameter("@_PageSize", request.PageSize),
                new MySqlParameter("_totalCount", totalCount) { Direction = ParameterDirection.Output }
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Demo.Demo_Select_By_Name, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<demo>.DtToList(dbResult.Tables[0]);
            }


            return list;

        }
    }
}
