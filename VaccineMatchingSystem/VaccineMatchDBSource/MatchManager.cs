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
        /// <summary>
        /// 帶入第幾批次的疫苗，輸出DataRow
        /// </summary>
        /// <param name="Batch">批次</param>
        /// <returns></returns>
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

        /// <summary>
        /// 以疫苗名稱，查詢某使用者是否宣告某疫苗的意願
        /// </summary>
        /// <param name="VaccineName">疫苗名稱</param>
        /// <returns></returns>
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

                if (dr == null)
                    //if (CheckDataRowIsNull(dr))
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

     


        /// <summary>
        /// 帶入疫苗意願名稱，輸出DataRow (意願登記表 JOIN 施打人資料表)
        /// </summary>
        /// <param name="VaccineName">疫苗意願名</param>
        /// <returns></returns>
        public static DataTable WillingUsers(string VaccineName)
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

        /// <summary>
        /// 查詢民眾，把該人的該疫苗意願效力設定為0(無效)，回傳成功與否(bool)
        /// </summary>
        /// <param name="VaccineName">疫苗名</param>
        /// <param name="UserID">民眾</param>
        /// <returns></returns>
        public static bool TurnToNoEffective(string VaccineName, Guid UserID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [WillingRegister]
                    SET [IsEffective] = 0
                    WHERE [VaccineWilling] = @vaccineName AND [UserID] = @userID
                    AND [IsEffective] = 1
                ";

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

        /// <summary>
        /// 將指定疫苗設為已匹配
        /// </summary>
        /// <param name="VGUID">疫苗ID</param>
        /// <returns></returns>
        public static bool SetVaccAsMatched(Guid VGUID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [VaccineInventory]
                    SET [IsMatched] = 1
                    WHERE [VGUID] = @VGUID 
                    AND [IsMatched] = 0
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@VGUID", VGUID));

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

        /// <summary>
        /// 把演算法參數儲存進DB裡面  
        /// </summary>
        /// <param name="VGuid">疫苗ID</param>
        /// <param name="AgeButtom">指定年齡層(底)</param>
        /// <param name="AgeTop">指定年齡層(頂)</param>
        /// <param name="Direction">小的先/老的先</param>
        /// <param name="JobW">職業權重表</param>
        /// <param name="StateW">狀態權重表</param>
        /// <param name="Area">疫苗所在地</param>
        /// <param name="DoseCountRank">指定施打劑次</param>
        public static void InsertAlgWeightListIntoDB(Guid VGuid, int AgeButtom, int AgeTop, int Direction, string JobW, string StateW, string Area, int DoseCountRank)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [Algorithm]
                    (
                        [VGUID]
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
                        @VGuid
                        ,@AgeButtom
                        ,@AgeTop
                        ,@Direction
                        ,@JobW
                        ,@StateW
                        ,@Area
                        ,@DoseCountRank
                    )
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@VGuid", VGuid));
            list.Add(new SqlParameter("@AgeButtom", AgeButtom));
            list.Add(new SqlParameter("@AgeTop", AgeTop));
            list.Add(new SqlParameter("@Direction", Direction));
            list.Add(new SqlParameter("@JobW", JobW));
            list.Add(new SqlParameter("@StateW", StateW));
            list.Add(new SqlParameter("@Area", Area));
            list.Add(new SqlParameter("@DoseCountRank", DoseCountRank));

            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }



        /// <summary>
        /// 抓取所有已/未匹配的疫苗名
        /// </summary>
        /// <param name="IsMatched">已/未匹配 (1/0)</param>
        /// <returns></returns>
        public static DataTable GetAvailableVaccName(int IsMatched)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =

                $@"SELECT 
                        [VName]                  
                   FROM [VaccineMatchingSystem].[dbo].[VaccineInventory]                 
                   WHERE [IsMatched] = @IsMatched
                    GROUP BY [VName]
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@IsMatched", IsMatched));
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

   

        /// <summary>
        /// 以疫苗ID查詢演算法權重表
        /// </summary>
        /// <param Guid="VGuid">疫苗ID</param>
        /// <returns></returns>
        public static DataRow GetAlgWeightList(Guid VGuid)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =

                $@"
                    SELECT  
                     [targetAgeButtom]
                     ,[targetAgeTop]
                     ,[direction]
                     ,[JobWeight]
                     ,[StateWeight]
                     ,[TargetArea]
                     ,[DoseCountRank]
                    FROM [VaccineMatchingSystem].[dbo].[Algorithm]
                    WHERE [VGUID] = @VGuid
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@VGuid", VGuid));
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

        /// <summary>
        /// 將配對完成者insert進配對結果紀錄表
        /// </summary>
        /// <param name="WillingID">意願ID</param>
        /// <param name="AlgorithmID">演算法ID</param>
        /// <param name="Priority">順位</param>
        /// <param name="UserID">民眾GUID</param>
        /// <param name="Score">分數</param>
        public static void InsertMatchingResult(int WillingID, int AlgorithmID, int Priority, Guid UserID, float Score, string VName)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [MatchingResultRecord]
                    (
                            [WillingID]
                            ,[AlgorithmID]
                            ,[Priority]
                            ,[UserID]
                            ,[Score]
                            ,[VName]
                    )
                    VALUES 
                    (
                        @WillingID,
                        @AlgorithmID,
                        @Priority,
                        @UserID,
                        @Score,
                        @VName
                    )
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@WillingID", WillingID));
            list.Add(new SqlParameter("@AlgorithmID", AlgorithmID));
            list.Add(new SqlParameter("@Priority", Priority));
            list.Add(new SqlParameter("@UserID", UserID));
            list.Add(new SqlParameter("@Score", Score));
            list.Add(new SqlParameter("@VName", VName));


            try
            {
                DBHelper.CreatData(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }



        /// <summary>
        /// 取得意願流水號
        /// </summary>
        /// <param name="UserID">民眾ID</param>
        /// <returns></returns>
        public static int GetWillingID(Guid UserID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                     [WillingID]
                    FROM [WillingRegister]
                    WHERE [UserID] = @UserID AND IsEffective = 1
                    ORDER BY [WillingID] DESC
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", UserID));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, list);
                return (int)dr[0];
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return -1;
            }
        }

        /// <summary>
        /// 取得演算法流水號
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int GetAlgID(Guid VaccID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                     [AlgorithmID]
                    FROM [Algorithm]
                    WHERE [VGUID] = @VaccID 
                    ORDER BY [AlgorithmID] DESC
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@VaccID", VaccID));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, list);
                return (int)dr[0];
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return -1;
            }
        }

        public static DataTable GetResultForGeneralUser(Guid UserID)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =

                $@"SELECT [PriorityAccNote]
                      ,[WillingID]
                      ,[Priority]
                      ,[UserID]
                      ,[Score]
                      ,M.[AlgorithmID]
                      ,[VName]
                	  ,A.[TargetArea]
                  FROM [MatchingResultRecord] AS M
                  JOIN [Algorithm] AS A
                  ON M.[AlgorithmID] = A.[AlgorithmID]
                  WHERE M.[UserID] = @userID
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", UserID));

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


        public static bool CheckResultForGeneralUserIsNull(Guid UserID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT [UserID]
                     FROM [VaccineMatchingSystem].[dbo].[MatchingResultRecord]
                     WHERE [UserID] = @userID
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", UserID));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, list);

                if (dr == null)
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

        //-----------------------------//
        /// <summary>
        /// 以演算法ID查詢配到的民眾資料  (未完成)
        /// </summary>
        /// <param Guid="VGuid">疫苗ID</param>
        /// <returns></returns>
        public static DataTable GetMatchingRecord(int AlgorithmID)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =

                $@"
                    SELECT 
            Ｕ.[Name],
            U.[Occupation],
            U.[Age],
            M.[Priority]
                  FROM [MatchingResultRecord] AS M
                  JOIN [UserInfo] AS U
                       ON U.[UserID] = M.[UserID]
                  WHERE [AlgorithmID] = @AlgorithmID
      ORDER BY M.[Priority] ASC
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@AlgorithmID", AlgorithmID));
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

        /// <summary>
        /// 以疫苗名抓取 [已/未] 匹配的疫苗批次
        /// </summary>
        /// <param name="VaccName">疫苗名</param>
        /// <param name="IsMatched">[已/未] 1/0</param>
        /// <returns></returns>
        public static DataTable GetAvailableVaccBatch(string VaccName, int IsMatched)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =

                $@"SELECT 
                        [VBatch]                  
                   FROM [VaccineMatchingSystem].[dbo].[VaccineInventory]                 
                   WHERE [IsMatched] = @IsMatched AND [VName]=@VaccName
                    ORDER BY [VBatch] ASC
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@VaccName", VaccName));
            list.Add(new SqlParameter("@IsMatched", IsMatched));
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

        /// <summary>
        /// 抓取疫苗ID、數量by選擇疫苗批次
        /// </summary>
        /// <param name="VaccineName">疫苗名</param>
        /// <param name="Batch">疫苗批次</param>
        /// <param name="IsMatched">[已/未]匹配  [1/0] </param>
        /// <returns></returns>
        public static DataRow GetVaccIDAndNumByBatch(string VaccineName, int Batch, int IsMatched)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =

                $@"SELECT 
                         [VGUID]
                        ,[Quantity]
                   FROM [VaccineMatchingSystem].[dbo].[VaccineInventory]
                   WHERE [VName] = @VaccineName AND [VBatch]=@Batch AND [IsMatched] = @IsMatched
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@vaccineName", VaccineName));
            list.Add(new SqlParameter("@Batch", Batch));
            list.Add(new SqlParameter("@IsMatched", IsMatched));
            try
            {
                //return DBHelper.ReadDataTable(connectionString, dbCommandString, list);
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }

    }
}
