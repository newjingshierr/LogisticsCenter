using Logistics_Model;
using Logistics.Core;
using Logistics_DAL;
using Logistics.Common;
using System;
using System.Data;
using System.Collections.Generic;

namespace Logistics_Busniess
{
    public class TokenManager
    {
        public static bool InsertTokenLog(InsertTokenLogRequest item)
        {
            logistics_base_token_log tokenLog = new logistics_base_token_log();
            tokenLog.ID = IdWorker.GetID();
            tokenLog.token = item.token;
            tokenLog.Userid = item.userID;
            tokenLog.CreatedBy = item.userID;
            return TokenDAL.Insert(tokenLog);
        }

        public static bool GetTokenByUserID(long userID)
        {
            var dbResult = false;
            var tokenLog = TokenDAL.GetItem(userID);
            if (tokenLog != null)
            {
                TimeSpan timeSpan = DateTime.Now - tokenLog.Created;

                if (timeSpan.TotalMinutes > 2)
                {
                    dbResult = true;
                }
                else
                {
                    dbResult = false;
                }
            }
            else
            {
                dbResult = false;
            }

            return dbResult;
        }


        public static bool DeleteTokenLog(long userID)
        {
            return TokenDAL.Delete(userID);
        }



    }
}
