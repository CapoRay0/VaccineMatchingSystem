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

        public static DataRow GetUserInfoByGuid(Guid userGuid)
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
                    WHERE [UserID] = @userGuid
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userGuid", userGuid));

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

        public static bool ChangePwd(string name, string ID, string Newpwd)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [UserInfo]
                    SET [Password] = @Newpwd                    
                    WHERE Name = @name AND ID = @ID";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@name", name));
            paramList.Add(new SqlParameter("@ID", ID));
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


        public static DataTable GetGeneralUserInfo()
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
                    WHERE [UserLevel] = 1
                ";

            List<SqlParameter> list = new List<SqlParameter>();

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
        public static DataRow GetUserInfoInDataRow()
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
                    WHERE [UserLevel] = 1
                ";

            List<SqlParameter> list = new List<SqlParameter>();

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
        public static string GetGeneralUserCount()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@" SELECT
                        COUNT ([UserID])
                    FROM [UserInfo]
                    WHERE [UserLevel] = 1
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            try
            {
                var dr = DBHelper.ReadDataRow(connectionString, dbCommandString, list);
                string ans = dr[0].ToString();
                return ans;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }
        public static string GetSystemAdminCount()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@" SELECT
                        COUNT ([UserID])
                    FROM [UserInfo]
                    WHERE [UserLevel] = 0
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            try
            {
                var dr = DBHelper.ReadDataRow(connectionString, dbCommandString, list);
                string ans = dr[0].ToString();
                return ans;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }
        public static string GetWillingCount()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                $@" SELECT 
	                    COUNT ([UserID])
                    FROM [WillingRegister]
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            try
            {
                var dr = DBHelper.ReadDataRow(connectionString, dbCommandString, list);
                string ans = dr[0].ToString();
                return ans;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }


        public static bool CheckInfoIsCorrectForChangPWD(string Account, string PWD)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        [Account]
                        ,[Password]
                    FROM [UserInfo]
                    WHERE Account = @account AND Password = @pwd";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@account", Account));
            paramList.Add(new SqlParameter("@pwd", PWD));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, paramList);

                //if (!CheckDataRowIsNull(dr))
                if (dr != null)
                {
                    var OrigAccount = dr[0].ToString();
                    var OrigPWD = dr[1].ToString();
                    if (Account.Trim() == OrigAccount.Trim() && PWD.Trim() == OrigPWD.Trim())
                    {
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return false;
            }
        }
        public static bool CheckInfoIsCorrectForForgotPWD(string Name, string ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" SELECT 
                        [Name]
                        ,[ID]
                    FROM [UserInfo]
                    WHERE [Name] = @name AND ID = @id";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@name", Name));
            paramList.Add(new SqlParameter("@id", ID));

            try
            {
                var dr = DBHelper.ReadDataRow(connStr, dbCommand, paramList);

                //if (!CheckDataRowIsNull(dr))
                if (dr != null)
                {
                    var OrigName = dr[0].ToString();
                    var OrigID = dr[1].ToString();
                    if (Name.Trim() == OrigName.Trim() && ID.Trim() == OrigID.Trim())
                    {
                        return true;
                    }
                    else
                        return false;
                }
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
