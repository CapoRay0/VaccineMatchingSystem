using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineMatchDBSource
{
    public class AccountingManager
    {
        public static DataTable ShowTotalAmountNumber(string userID, int UserLevel)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT
                        [ID],
                        [CreateDate],
                        [ActType],
                        [Amount],
                        [Caption]
                    FROM [UserInfo]
                    
                ";

            // 用List把Parameter裝起來，再裝到共用參數
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));
            list.Add(new SqlParameter("@UserLevel", UserLevel));
            try // 讓錯誤可以被凸顯，因此 TryCatch 不應該重構進 DBHelper
            {
                return DBHelper.ReadDataTable(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }
    }
}
