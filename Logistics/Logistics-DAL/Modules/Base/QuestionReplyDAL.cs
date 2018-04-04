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
    public class QuestionReplyDAL : DalBase
    {
        public static bool logistics_base_message_reply_delete(long questionID, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID",BusinessConstants.Admin.TenantID),
                        new MySqlParameter("@_quesitonid",questionID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.QuestionReply.logistics_base_question_reply_delete_by_quesiton_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.QuestionReply.logistics_base_question_reply_delete_by_quesiton_id, parameters);
            }
            return result == 1;

        }
        public static List<logistics_base_question_reply> logistics_base_question_reply_by_question_id(long questionID, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new List<logistics_base_question_reply>();


            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                   new MySqlParameter("@_questionID",questionID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.QuestionReply.logistics_base_question_reply_by_question_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_question_reply>.DtToList(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }



        public static bool Insert(logistics_base_question_reply model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                          new MySqlParameter("@_quesitonID",model.questionID),
                          new MySqlParameter("@_reply", model.reply),
                          new MySqlParameter("@_customerServiceID", model.customerServiceID),
                        new MySqlParameter("@_CreatedBy", model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy", model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.QuestionReply.logistics_base_question_reply_ADD, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.QuestionReply.logistics_base_question_reply_ADD, parameters);
            }
            return result == 1;

        }

        public static bool InsertList(List<logistics_base_question_reply> modelList, AkmiiMySqlTransaction trans = null)
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
