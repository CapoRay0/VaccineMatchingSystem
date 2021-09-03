using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineMatchDBSource
{
    public class DBHelper
    {
        public static string GetConnectionString()
        {
            string val = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            return val;
        }

        public static DataTable ReadDataTable(string connStr, string dbCommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    return dt;
                }
            }
        }

        public static DataRow ReadDataRow(string connStr, string dbCommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count == 0)
                        return null;

                    DataRow dr = dt.Rows[0];
                    return dt.Rows[0];

                }
            }
        }

        public static int ModifyData(string connectionString, string dbCommandString, List<SqlParameter> paramList)
        {
            // connect db & execute
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = new SqlCommand(dbCommandString, conn))
                {
                    comm.Parameters.AddRange(paramList.ToArray());

                    conn.Open();
                    int effectRowsCount = comm.ExecuteNonQuery();
                    return effectRowsCount;
                }
            }
        }

        public static void InsertUserFeedback(Guid userGuid, string Username, string UserEmail, int Reason, string UserFeedback, int Feedbackget)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@"INSERT INTO [Feedback]
                    (
                        [UserID]
                       ,[FName]
                       ,[Email]
                       ,[Reason]
                       ,[Opinion]
                       ,[FeedbackGet] 
                    )
                    VALUES
                    (
                        @ID
                       ,@Name
                       ,@Email
                       ,@Reason
                       ,@UserFeedback                    
                       ,@Feedbackget
                    )
                ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ID", userGuid));
            paramList.Add(new SqlParameter("@Name", Username));
            paramList.Add(new SqlParameter("@Email", UserEmail));
            paramList.Add(new SqlParameter("@Reason", Reason));
            paramList.Add(new SqlParameter("@UserFeedback", UserFeedback));
            paramList.Add(new SqlParameter("@Feedbackget", Feedbackget));

            try
            {
                DBHelper.CreatData(connStr, dbCommand, paramList);
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
            }
        }

        public static void CreatData(string connStr, string dbCommand, List<SqlParameter> paramList)
        {
            // connect db & execute
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddRange(paramList.ToArray());

                    conn.Open();
                    comm.ExecuteNonQuery();
                }
            }
        }
    }
}
