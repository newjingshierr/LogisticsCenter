using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;
using Akmii;

namespace Logistics_DAL
{
    public class QuestionDAL: DalBase
    {
        public static bool logistics_base_question_Delete(long ID, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID",BusinessConstants.Admin.TenantID),
                        new MySqlParameter("@_ID",ID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Question.logistics_base_question_Delete, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Question.logistics_base_question_Delete, parameters);
            }
            return result == 1;

        }
        public static List<logistics_base_question> GetItemListByPage(int pageIndex, int pageSize, int type, long userid, ref int totalCount, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_question>();
            var total = new MySqlParameter("@_TotalCount", totalCount) { Direction = ParameterDirection.Output };

            MySqlParameter[] parameters = {
                new MySqlParameter("@_userID",userid),
                new MySqlParameter("@_TenantID", TenantID),
                new MySqlParameter("@_PageIndex", pageIndex),
                new MySqlParameter("@_PageSize", pageSize),
                total
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Question.logistics_base_question_by_page, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_question>.DtToList(dbResult.Tables[0]);
                totalCount = (total.Value + "").Convert2Int32();
            }
            else
            {
                result = null;
            }

            return result;
        }



        public static bool Insert(logistics_base_question model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                          new MySqlParameter("@_userid",model.userid),
                          new MySqlParameter("@_CreatedBy", model.CreatedBy),
                          new MySqlParameter("@_ModifiedBy", model.ModifiedBy),
                        new MySqlParameter("@_title", model.title),
                        new MySqlParameter("@_message", model.message),
                          new MySqlParameter("@_IsReply", model.IsReply)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Question.logistics_base_question_ADD, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Question.logistics_base_question_ADD, parameters);
            }
            return result == 1;

        }

        public static bool InsertList(List<logistics_base_question> modelList, AkmiiMySqlTransaction trans = null)
        {

            var result = true;
            if (modelList != null)
            {
                foreach (var o in modelList)
                {
                    result = result && Insert(o, trans);
                }
            }
            return result;

        }
    }
}
