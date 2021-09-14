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

        public static void InsertUserWillingVaccin(Guid userGuid, string WillingRecord)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [WillingRegister]
                    (
                        [UserID] 
                        ,[IsEffective]
                        ,[VaccineWilling]
                    )
                    VALUES 
                    (
                        @userID
                        ,1
                        ,@VaccineWilling
                    )
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userGuid));
            list.Add(new SqlParameter("@VaccineWilling", WillingRecord));

            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }
        public static bool CheckWillingIfChecked(Guid userGuid)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        [UserID]
                        ,[IsEffective]
                    FROM [WillingRegister]
                    WHERE [IsEffective] = 1 AND [UserID] = @userID";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userID", userGuid));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, paramList);

                if (dr != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }


        public static bool CheckSingleWillingIsNull(Guid userGuid, string WillingVName)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        [UserID]
                        ,[IsEffective]
                        ,[VaccineWilling]
                    FROM [WillingRegister]
                    WHERE [IsEffective] = 1 AND [UserID] = @userID AND [VaccineWilling] = @willingVName";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userID", userGuid));
            paramList.Add(new SqlParameter("@willingVName", WillingVName));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, paramList);

                if (dr == null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }



        public class Vaccination
        {
            public Guid VGUID { get; set; }
            public string VName { get; set; }
            public int Quantity { get; set; }
            public int VBatch { get; set; }
            public int IsMatched { get; set; }
        }

        /// <summary> 取得疫苗資訊 => 用來動態加入疫苗 </summary>
        /// <returns></returns>
        public static DataTable EveryVName()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =

                $@"SELECT [VName]
                     FROM [VaccineInventory]
                     GROUP BY [VName]
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@vguid", VGUID));
            try
            {
                return DBHelper.ReadDataTable(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }



    }
}
