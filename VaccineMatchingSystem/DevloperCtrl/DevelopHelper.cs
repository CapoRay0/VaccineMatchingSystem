using AlgorithmData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VaccineMatchDBSource;
 
namespace DevloperCtrl
{
    public class DevCtrl
    {
        /// <summary>
        /// 建立新民眾
        /// </summary>
        /// <param name="OccupationList">要進入Random的狀職業清單</param>
        /// <param name="StatusList">要進入Random的狀態清單</param>
        public static void AddNewUser(List<string> OccupationList, List<string> StatusList, Guid userGuid, int count)
        {

            //------資料模組------//
            //Guid userGuid = Guid.NewGuid();
            string userName_Acc_pwd = "User" + (count + 1);
            int userAge = new Random().Next(1, 100);
            int occuListPicker = new Random().Next(0, OccupationList.Count);
            string userOccupation = OccupationList[occuListPicker];
            var map = CityModel.CreateCityModel();
            var area = map[new Random().Next(0, map.Count)];
            string userArea = area[new Random().Next(0, area.Length)];
            int userLevel = 1;
            string[] alphabet = { "A", "B", "C", "D", "E" };
            int userGender = new Random().Next(1, 2);
            int IDFirst = userGender;
            int IDLast = new Random().Next(100000000, 999999999);
            string userID = alphabet[new Random().Next(0, alphabet.Length)] + IDFirst + IDLast;
            string userStatus = StatusList[new Random().Next(0, StatusList.Count)];
            int userDoseCount = new Random().Next(0, 1);


            //--------------//

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [UserInfo]
                    (
                          [UserID]
                          ,[Name]
                          ,[Gender]
                          ,[Age]
                          ,[Occupation]
                          ,[Area]
                          ,[UserLevel]
                          ,[ID]
                          ,[Account]
                          ,[Password]
                          ,[Status]
                          ,[DoseCount]
                    )
                    VALUES 
                    (
                          @UserID
                          ,@Name
                          ,@Gender
                          ,@Age
                          ,@Occupation
                          ,@Area
                          ,@UserLevel
                          ,@ID
                          ,@Account
                          ,@Password
                          ,@Status
                          ,@DoseCount
                    )
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userGuid));
            list.Add(new SqlParameter("@Name", userName_Acc_pwd));
            list.Add(new SqlParameter("@Gender", userGender));
            list.Add(new SqlParameter("@Age", userAge));
            list.Add(new SqlParameter("@Occupation", userOccupation));
            list.Add(new SqlParameter("@Area", userArea));
            list.Add(new SqlParameter("@UserLevel", userLevel));
            list.Add(new SqlParameter("@ID", userID));
            list.Add(new SqlParameter("@Account", userName_Acc_pwd));
            list.Add(new SqlParameter("@Password", userName_Acc_pwd));
            list.Add(new SqlParameter("@Status", userStatus));
            list.Add(new SqlParameter("@DoseCount", userDoseCount));

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
        /// 取得現在DB內的user數量
        /// </summary>
        /// <returns></returns>
        public static int GetUserNumber()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT 
                        count([UserID])
                    FROM [UserInfo]
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@account", account));

            try
            {
                var dr = DBHelper.ReadDataRow(connectionString, dbCommandString, list);
                int ans = (int)dr[0];
                return ans;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return 0;
            }
        }

        /// <summary>
        /// 新增意願
        /// </summary>
        public static void AddNewWilling(Guid UserID, List<string> VaccList)
        {
            //------資料模組------//
            int pickNum = new Random().Next(0, 3);
            List<string> tempList = new List<string>();
            List<string> AddList = new List<string>();
            int tempNum;
            for (int i = 0; i <= pickNum; i++)//抽n次
            {
                tempNum = new Random().Next(0, VaccList.Count);  //抽籤
                tempList.Add(VaccList[tempNum]); //佔存               
                Thread.Sleep(1);
            }
            AddList = tempList.Where((x, y) => tempList.FindIndex(z => z == x) == y).ToList();  //list去重

            //------資料模組------//

            foreach (var VaccineWilling in AddList)
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
                          @UserID
                          ,1
                          ,@VaccineWilling
                  
                    )
                ";

                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("@UserID", UserID));
                list.Add(new SqlParameter("@VaccineWilling", VaccineWilling));
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

        /// <summary>
        /// 找回Admin
        /// </summary>
        public static void AddAdmin()
        {
            //------資料模組------//
            Guid userGuid = Guid.NewGuid();
            string userName_Acc_pwd = "Q";
            int userAge = 0;
            string userOccupation = "Admin";
            var map = CityModel.CreateCityModel();
            var area = map[new Random().Next(0, map.Count)];
            string userArea = area[new Random().Next(0, area.Length)];
            int userLevel = 0;
            string[] alphabet = { "A", "B", "C", "D", "E" };
            int userGender = new Random().Next(1, 2);
            int IDFirst = userGender;
            int IDLast = new Random().Next(100000000, 999999999);
            string userID = alphabet[new Random().Next(0, alphabet.Length)] + IDFirst + IDLast;
            string userStatus = "Admin";
            int userDoseCount = 0;


            //--------------//

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" 
                    INSERT INTO [UserInfo]
                    (
                          [UserID]
                          ,[Name]
                          ,[Gender]
                          ,[Age]
                          ,[Occupation]
                          ,[Area]
                          ,[UserLevel]
                          ,[ID]
                          ,[Account]
                          ,[Password]
                          ,[Status]
                          ,[DoseCount]
                    )
                    VALUES 
                    (
                          @UserID
                          ,@Name
                          ,@Gender
                          ,@Age
                          ,@Occupation
                          ,@Area
                          ,@UserLevel
                          ,@ID
                          ,@Account
                          ,@Password
                          ,@Status
                          ,@DoseCount
                    )
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userGuid));
            list.Add(new SqlParameter("@Name", userName_Acc_pwd));
            list.Add(new SqlParameter("@Gender", userGender));
            list.Add(new SqlParameter("@Age", userAge));
            list.Add(new SqlParameter("@Occupation", userOccupation));
            list.Add(new SqlParameter("@Area", userArea));
            list.Add(new SqlParameter("@UserLevel", userLevel));
            list.Add(new SqlParameter("@ID", userID));
            list.Add(new SqlParameter("@Account", userName_Acc_pwd));
            list.Add(new SqlParameter("@Password", userName_Acc_pwd));
            list.Add(new SqlParameter("@Status", userStatus));
            list.Add(new SqlParameter("@DoseCount", userDoseCount));

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
        /// 清空民眾
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ID"></param>
        /// <param name="Newpwd"></param>
        /// <returns></returns>
        public static bool DELETE_FROM_UserInfo()
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"
                DELETE FROM [UserInfo] 
                WHERE [UserLevel]=1;

                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            //paramList.Add(new SqlParameter("@name", name));


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
        /// 清空願望
        /// </summary>
        /// <returns></returns>
        public static bool DELETE_FROM_WillingRegister()
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"

                
                DELETE FROM [WillingRegister] 
     
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            //paramList.Add(new SqlParameter("@name", name));


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

        //----------------------------//

        /// <summary>
        /// 清空演算法參數紀錄
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ID"></param>
        /// <param name="Newpwd"></param>
        /// <returns></returns>
        public static bool DELETE_FROM_Algorithm()
        {
            //var IsEffective = 1;
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"
                DELETE FROM [Algorithm]                
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            //paramList.Add(new SqlParameter("@IsEffective", IsEffective));

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
        /// 清空配對紀錄
        /// </summary>
        /// <returns></returns>
        public static bool DELETE_FROM_MatchingResultRecord()
        {
            //var IsEffective = 1;
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"
               

                DELETE FROM [MatchingResultRecord] 
           
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            //paramList.Add(new SqlParameter("@IsEffective", IsEffective));

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
        /// 清空疫苗庫存
        /// </summary>
        /// <returns></returns>
        public static bool DELETE_FROM_VaccineInventory()
        {
            //var IsEffective = 1;
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"
        

                DELETE FROM [VaccineInventory] 
              
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            //paramList.Add(new SqlParameter("@IsEffective", IsEffective));

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
        /// 還原民眾願望為有效
        /// </summary>
        /// <returns></returns>
        public static bool UPDATE_WillingRegister_SET_IsEffectiveAs_1()
        {
            //var IsEffective = 1;
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"

                UPDATE  [WillingRegister]
                SET [IsEffective] = 1
                WHERE [IsEffective] = 0
      
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            //paramList.Add(new SqlParameter("@IsEffective", IsEffective));

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



    }
}
