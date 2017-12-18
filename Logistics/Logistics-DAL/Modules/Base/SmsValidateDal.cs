﻿using Akmii.Core.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Logistics_Model;
using Logistics.Common;

namespace Logistics_DAL
{
    public class ValidateDal
    {
        public static bool Insert(logistics_base_sms_validate model, AkmiiMySqlTransaction trans = null)
        {

            MySqlParameter[] parameters = {
                        new MySqlParameter("@_TenantID",model.TenantID) ,
                        new MySqlParameter("@_ID", model.ID) ,
                        new MySqlParameter("@_mail", model.mail) ,
                        new MySqlParameter("@_tel", model.tel) ,
                        new MySqlParameter("@_code", model.code) ,
                        new MySqlParameter("@_startTime", model.startTime) ,
                        new MySqlParameter("@_endTime", model.endTime) ,
                        new MySqlParameter("@_CreatedBy",model.CreatedBy),
                        new MySqlParameter("@_ModifiedBy",model.ModifiedBy),
            };

            int result = 0;
            if (trans == null)
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(ConnectionManager.GetWriteConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_sms_validate_insert, parameters);
            }
            else
            {
                result = AkmiiMySqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, Proc.Base.logistics_base_sms_validate_insert, parameters);
            }
            return result == 1;

        }

        public static logistics_base_sms_validate ChekcItem(long TenantID, string tel, string mail, string code, DateTime startTime, DateTime endTime)
        {
            var result = new logistics_base_sms_validate();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                 new MySqlParameter("@_Tel", tel),
                 new MySqlParameter("@_Mail", mail),
                  new MySqlParameter("@_code", code),
                  new MySqlParameter("@_startTime", startTime),
                  new MySqlParameter("@_endTime", System.DateTime.Now),
            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetReadConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_sms_validate_check, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_sms_validate>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }
            return result;
        }
        public static logistics_base_sms_validate GetItem(long TenantID, string tel, string mail)
        {
            var result = new logistics_base_sms_validate();
            MySqlParameter[] parameters = {
                new MySqlParameter("@_TenantID", TenantID),
                 new MySqlParameter("@_Tel", tel),
                 new MySqlParameter("@_Mail", mail),

            };

            var dbResult = AkmiiMySqlHelper.GetDataSet(ConnectionManager.GetReadConn(), CommandType.StoredProcedure, Proc.Base.logistics_base_sms_validate_select, parameters);
            if (dbResult.Tables.Count > 0 && dbResult.Tables[0].Rows.Count > 0)
            {
                result = ConvertHelper<logistics_base_sms_validate>.DtToModel(dbResult.Tables[0]);
            }
            else
            {
                result = null;
            }

            return result;
        }
    }

}
