using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class RecipientsAddressDAL
    {
        public static logistics_base_recipients_address GetItem(long ID, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var result = new logistics_base_recipients_address();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_ID",ID),
                new MySqlParameter("@_TenantID", TenantID)
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.RecipientsAddress.logistics_base_recipients_address_select_by_id, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_recipients_address>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }


            return result;
        }

        public static bool Insert(logistics_base_recipients_address model, AkmiiMySqlTransaction trans = null, long TenantID = BusinessConstants.Admin.TenantID)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID", TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_Userid", model.Userid),
                        new MySqlParameter("_country", model.country),
                        new MySqlParameter("_recipient", model.recipient),
                        new MySqlParameter("@_City", model.City),
                        new MySqlParameter("@_postalcode", model.postalcode),
                        new MySqlParameter("@_Tel", model.Tel),
                        new MySqlParameter("@_taxno", model.taxno),
                         new MySqlParameter("@_companyName", model.companyName),
                        new MySqlParameter("@_Address", model.Address),
                        new MySqlParameter("@_CreatedBy",model.CreatedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.RecipientsAddress.logistics_base_recipients_address_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.RecipientsAddress.logistics_base_recipients_address_insert, parameters);
            }
            return result == 1;

        }
        public static bool Delete(long id, AkmiiMySqlTransaction trans = null, long TenantID = BusinessConstants.Admin.TenantID)
        {

            MySqlParameter[] parameters = {
                         new MySqlParameter("@_TenantID", TenantID),
                        new MySqlParameter("@_ID",id),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.RecipientsAddress.logistics_base_recipients_address_delete_by_id, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.RecipientsAddress.logistics_base_recipients_address_delete_by_id, parameters);
            }
            return result == 1;

        }

        public static bool Update(logistics_base_recipients_address model, AkmiiMySqlTransaction trans = null, long TenantID = BusinessConstants.Admin.TenantID)
        {

            MySqlParameter[] parameters = {
                                         new MySqlParameter("@_TenantID", TenantID),
                        new MySqlParameter("@_ID",model.ID),
                        new MySqlParameter("@_Userid", model.Userid),
                        new MySqlParameter("_country", model.country),
                        new MySqlParameter("_recipient", model.recipient),
                        new MySqlParameter("@_City", model.City),
                        new MySqlParameter("@_postalcode", model.postalcode),
                        new MySqlParameter("@_Tel", model.Tel),
                        new MySqlParameter("@_taxno", model.taxno),
                         new MySqlParameter("@_companyName", model.companyName),
                        new MySqlParameter("@_Address", model.Address),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy)
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.RecipientsAddress.logistics_base_recipients_address_update, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.RecipientsAddress.logistics_base_recipients_address_update, parameters);
            }
            return result == 1;

        }

        public static List<logistics_base_recipients_address> GetAll(long userid,  AkmiiMySqlTransaction trans = null, long TenantID = BusinessConstants.Admin.TenantID)
        {
            var list = new List<logistics_base_recipients_address>();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID",TenantID),
                 new MySqlParameter("@_userID",userid),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.RecipientsAddress.logistics_base_recipients_address_select_all, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                list = ConvertHelper<logistics_base_recipients_address>.DtToList(dbResult.Tables[0]);
            }
            return list;

        }
    }
}
