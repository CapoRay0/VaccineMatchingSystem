using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineMatchDBSource
{
    public class UserInfoManager
    {
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [UserID]
                        , [Name]
                        , [Gender]
                        , [Age]
                        , [Occupation]
                        , [Area]
                        , [UserLevel]
                        , [ID]
                        , [Account]
                        , [Password]
                        , [Status]
                        , [DoseCount]
                    FROM [UserInfo]
                    WHERE [Account] = @account
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

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

        public static int GetAccountUserLevel(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT 
                        [UserLevel]
                    FROM [UserInfo]
                    WHERE [Account] = @account
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                var dr = DBHelper.ReadDataRow(connectionString, dbCommandString, list);
                string UserLevelText = dr[0].ToString();
                int UserLevel = Convert.ToInt32(UserLevelText);
                return UserLevel;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return 0;
            }
        }

        public static bool UpdatePwd(string account, Guid uid, string Newpwd)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [UserInfo]
                    SET [Password] = @Newpwd                    
                    WHERE Account = @account AND UserID = @uid ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", account));
            paramList.Add(new SqlParameter("@uid", uid));
            paramList.Add(new SqlParameter("@Newpwd", Newpwd));

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

        public static DataTable GetUserInfoFor(Guid UserID)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@"SELECT [Name]
                        , [Gender]
                        , [Age]
                        , [Occupation]
                        , [Area]
                        , [ID]
                        , [Account]
                        , [Status]
                        , [DoseCount]
                    FROM [UserInfo]
                    WHERE [UserID] = @userID
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
    }
}
