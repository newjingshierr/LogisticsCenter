using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;


namespace Logistics_DAL
{
    public class AttachmentDAL
    {
        public static List<logistics_base_attachment> GetAttachmentListByCustomerOrderID(long customerOrderID, AkmiiMySqlTransaction trans = null)
        {
            var list = new List<logistics_base_attachment>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",BusinessConstants.Admin.TenantID),
                 new MySqlParameter("@_customerOrderID",customerOrderID),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.File.logistics_base_attachment_get_by_customer_order_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_base_attachment>.DtToList(dbResult.Tables[0]);
            }


            return list;

        }

        public static logistics_base_attachment GetAttachmentListByID(long ID, AkmiiMySqlTransaction trans = null)
        {
            var model = new logistics_base_attachment();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",BusinessConstants.Admin.TenantID),
                 new MySqlParameter("@_ID",ID),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.File.logistics_base_attachment_get_by_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                model = ConvertHelper<logistics_base_attachment>.DtToModel(dbResult.Tables[0]);
            }


            return model;

        }


        public static bool Insert(logistics_base_attachment model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_customerOrderID", model.customerOrderID),
                        new MySqlParameter("@_customerOrderNo", model.customerOrderNo),
                         new MySqlParameter("@_path", model.path),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.File.logistics_base_attachment_Insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.File.logistics_base_attachment_Insert, parameters);
            }
            return result == 1;

        }


        public static bool InsertList(List<logistics_base_attachment> modelList, AkmiiMySqlTransaction trans = null)
        {

            var result = true;

            foreach (var o in modelList)
            {
                result = result && Insert(o, trans);
            }

            return result;

        }


        public static bool Delete(logistics_base_attachment model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.File.logistics_base_attachment_delete_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.File.logistics_base_attachment_delete_by_id, parameters);
            }
            return result == 1;

        }

        public static bool Update(logistics_base_attachment model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                          new MySqlParameter("@_TenantID", model.TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_customerOrderID", model.customerOrderID),
                         new MySqlParameter("@_customerOrderNo", model.customerOrderNo),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.File.logistics_base_attachment_update_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.File.logistics_base_attachment_update_by_id, parameters);
            }
            return result == 1;

        }

        public static bool UpdateList(List<logistics_base_attachment> modelList, AkmiiMySqlTransaction trans = null)
        {
            var result = true;

            foreach (var o in modelList)
            {
                result = result && Update(o, trans);
            }

            return result;
        }


        public static bool DeleteByCustomerOrderID(long customerOrderID, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_customerOrderID",customerOrderID)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.File.logistics_base_attachment_delete_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.File.logistics_base_attachment_delete_by_id, parameters);
            }
            return result == 1;

        }



    }
}
