using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VaccineMatchDBSource;

namespace VaccineMatchAuth
{
    public class AuthManager
    {

        #region 登入驗證
        /// <summary> 檢查目前是否登入 </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }

        /// <summary> 取得已登入的使用者資訊 (如果沒有登入就回傳 null) </summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);

            if (dr == null)
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            UserInfoModel model = new UserInfoModel();
            model.UserID = ((Guid)dr["UserID"]);
            model.Name = dr["Name"].ToString();
            model.Gender = Convert.ToInt32(dr["Gender"]);
            model.Age = Convert.ToInt32(dr["Age"]);
            model.Occupation = dr["Occupation"].ToString();
            model.Area = dr["Area"].ToString();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Password = dr["Password"].ToString();
            model.Status = dr["Status"].ToString();
            model.DoseCount = Convert.ToInt32(dr["DoseCount"]);

            return model;
        }
        #endregion




        #region 登入/登出
        /// <summary> 登入 </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            // check empty
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "Account / PWD is required.";
                return false;
            }

            // read db and check

            var dr = UserInfoManager.GetUserInfoByAccount(account);

            //check null
            if (dr == null)
            {
                errorMsg = $"Account: {account} doesn't exists."; // 查不到的話
                return false;
            }

            // check account / pwd
            if (string.Compare(dr["Account"].ToString(), account, true) == 0 &&
                string.Compare(dr["Password"].ToString(), pwd, false) == 0) // 因密碼要強制大小寫因此設定為false
            {
                HttpContext.Current.Session["UserLoginInfo"] = dr["Account"].ToString(); // 正確!!，跳頁至 UserInfo.aspx
                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "Login failed. Please check PWD.";
                return false;
            }

        }

        /// <summary> 登出 </summary>
        /// <returns></returns>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
        }
        #endregion

    }
}
