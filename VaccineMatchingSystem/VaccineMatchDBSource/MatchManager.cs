using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineMatchDBSource
{
    public class MatchManager
    {
        public static DataRow VaccinePerBatch(int Batch) // 帶入第幾批次的疫苗，輸出DataRow
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [VGUID]
                         ,[VName]
                         ,[Quantity]
                         ,[VBatch]
                    FROM [VaccineInventory]
                    WHERE [VBatch] = @batch
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@batch", Batch));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }
        public static bool QuantityReduce1(int Batch, int Quantity)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [VaccineInventory]
                    SET [Quantity] = @quantity
                    WHERE [VBatch] = @batch";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@batch", Batch));
            paramList.Add(new SqlParameter("@quantity", Quantity));

            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }


        public static bool CheckWillingUserIsNull(string VaccineName)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                         [UserID]
                         ,[IsEffective]
                         ,[VaccineWilling]
                    FROM [WillingRegister]
                    WHERE [VaccineWilling] = @vaccineName AND IsEffective = 1
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@vaccineName", VaccineName));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, list);

                if (CheckDataRowIsNull(dr))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }
        public static bool CheckDataRowIsNull(DataRow dataRow)
        {
            if (dataRow == null)
            {
                return true;
            }
            return false;
        }


        public static DataTable WillingUsers(string VaccineName) // 帶入疫苗意願名稱，輸出DataRow (意願登記表 JOIN 施打人資料表)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =

                $@"SELECT [WillingID]
                         , W.[UserID]
                         ,[IsEffective]
                         ,[VaccineWilling]
	                     ,[Name]
                         ,[Age]
                         ,[Occupation]
                         ,[Area]
                         ,[Status]
                         ,[DoseCount]
                   FROM [WillingRegister] AS W
                   LEFT JOIN[UserInfo] as U
                   ON W.UserID = U.UserID
                   WHERE [VaccineWilling] = @vaccineName AND [IsEffective] = 1
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@vaccineName", VaccineName));
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
        public static bool TurnToNoEffective(string VaccineName, Guid UserID) // 這邊還需要帶入 UserID (GUID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [WillingRegister]
                    SET [IsEffective] = 0
                    WHERE [VaccineWilling] = @vaccineName AND [UserID] = @userID";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@vaccineName", VaccineName));
            paramList.Add(new SqlParameter("@userID", UserID));

            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }

        

        public static void InsertIntoAlgorithm(int AlgID, Guid VGuid, int AgeButtom, int AgeTop, int Direction, string JobW, string StateW, string Area, int DoseCountRank)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [Algorithm]
                    (
                        [AlgorithmID]
                        ,[VGUID]
                        ,[targetAgeButtom]
                        ,[targetAgeTop]
                        ,[direction]
                        ,[JobWeight]
                        ,[StateWeight]
                        ,[TargetArea]
                        ,[DoseCountRank]
                    )
                    VALUES 
                    (
                        @userID
                        ,1
                        ,@VaccineWilling
                    )
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@userID", userGuid));
            //list.Add(new SqlParameter("@VaccineWilling", WillingRecord));

            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }

    }
}
