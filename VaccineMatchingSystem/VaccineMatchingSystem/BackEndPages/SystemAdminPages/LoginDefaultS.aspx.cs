using AlgorithmData;
using DataFormatTransfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchAuth;
using VaccineMatchDBSource;
using static DataFormatTransfer.ExcelDataManager;

namespace VaccineMatchingSystem.BackEndPages.SystemAdminPages
{

    public partial class LoginDefault : System.Web.UI.Page
    {
        private static string tempPathUserInfo;
        private static string tempPathVaccInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/FrontEndPages/Login.aspx");
                return;
            }
            this.ltlShowTotalUserNumb.Text = UserInfoManager.GetGeneralUserCount();
            this.ltlShowTotalAdminUserNumb.Text = UserInfoManager.GetSystemAdminCount();
            this.ltlWillingNumb.Text = UserInfoManager.GetWillingCount();
        }

        #region 單純頁面導向
        /// <summary>
        /// 導向到匹配頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStartMatching_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMatchResult.aspx");
        }
        /// <summary>
        /// 導向到反饋檢視頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnToFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetFeedback.aspx");
        }
        #endregion

        #region  excel進db
        /// <summary>
        /// 匯入使用者資料    (把UserInfo的excel轉化為DT，並且輸入至DB)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsertUserInfo_Click(object sender, EventArgs e)
        {
            InsertDTIntoSQL Vacc = InsertUserInfoIntoSQL; //指定委派方法的具體內容
            TryInsertExcel(tempPathUserInfo, ltUserInfoUploadWarning, Vacc);
        }

        /// <summary>
        /// 匯入本批疫苗資料  (把VaccQuin的excel轉化為DT，並且輸入至DB)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsertVaccQuin_Click(object sender, EventArgs e)
        {
            InsertDTIntoSQL Vacc = InsertVaccQuantityIntoSQL;  //指定委派方法的具體內容
            TryInsertExcel(tempPathVaccInfo, ltVaccQuinUploadWarning, Vacc);
        }

        /// <summary>
        /// Excel匯入DB的method
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="literal">顯示結果的標籤</param>
        private void TryInsertExcel(string path, Literal literal, InsertDTIntoSQL Inserter)
        {

            if (path == null)
            {
                literal.Text = "請上傳檔案";
                return;
            }
            if (InsertExcelToDb(path, Inserter))
            {
                literal.Text = "資料庫輸入成功";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('資料庫輸入成功')</script>");
            }
            else
                literal.Text = "請檢查路徑或檔案的正確性";
            path = null;
        }
        #endregion

        #region db到網頁
        /// <summary>
        /// 讀取匯入使用者的資料   (把DB裡面的UserInfo抓出，Bind到頁面)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetUserInfo_Click(object sender, EventArgs e)
        {
            DataTable dt = UserInfoManager.GetGeneralUserInfo();
            this.GridUserInfo.DataSource = dt;
            this.GridUserInfo.DataBind();
        }

        /// <summary>
        /// 讀取匯入疫苗資料       (把DB裡面的VaccData抓出，Bind到頁面)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetVaccData_Click(object sender, EventArgs e)
        {
            DataTable ds = GetCurrentVaccInfo();
            this.RepeaterShowVacc.DataSource = ds;
            this.RepeaterShowVacc.DataBind();
        }
        #endregion

        #region 讀取本機excel
        /// <summary>
        /// 從本機讀取本批次使用者資料(Excel>>C#)，並bind到頁面上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReadUserInfo_Click(object sender, EventArgs e)
        {
            string thisFilePath = Server.MapPath("~/");   //取得自己.aspx的路徑
            string thisFilePathFather = ExcelDataManager.GetUpLevelDirectory(thisFilePath, 2) + "\\Data\\ExcelFiles\\";   //找上2層，找ExcelFiles
            string uploadedResult = ExcelDataManager.UploadExcel(this.fuUserInfoExcel, thisFilePathFather, "UserInfo");  //上傳excel，指定黨名頭=UserInfo
            if (uploadedResult == null)  //檢查有無檔案
            {
                ltUserInfoUploadWarning.Text = "請上傳檔案";
                return;
            }
            string UserInfopath = thisFilePathFather + uploadedResult;     //找回excel檔的路徑
            tempPathUserInfo = UserInfopath;  //把路徑儲存以利insert進SQL
            DataTable dt = ExcelDataManager.GetDataTableFromExcelFile(UserInfopath);
            //bind到頁面上
            this.gvReadUserInfoFromExel.DataSource = dt;
            this.gvReadUserInfoFromExel.DataBind();
        }

        /// <summary>
        /// 從本機讀取本批次疫苗資料(Excel>>C#)，並bind到頁面上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReadVaccInfoThisBatch_Click(object sender, EventArgs e)
        {
            string thisFilePath = Server.MapPath("~/");   //取得自己.aspx的路徑
            string thisFilePathFather = ExcelDataManager.GetUpLevelDirectory(thisFilePath, 2) + "\\Data\\ExcelFiles\\";   //找上2層，找ExcelFiles
            string uploadedResult = ExcelDataManager.UploadExcel(this.fuVaccQuinExcel, thisFilePathFather, "VaccQuin");  //上傳excel，指定黨名頭=VaccQuin
            if (uploadedResult == null)  //檢查有無檔案
            {
                ltVaccQuinUploadWarning.Text = "請上傳檔案";
                return;
            }
            string Path = thisFilePathFather + uploadedResult;     //找回excel檔的路徑
            tempPathVaccInfo = Path;  //把路徑儲存以利insert進SQL
            DataTable dt = ExcelDataManager.GetDataTableFromExcelFile(Path);
            //bind到頁面上
            this.rpReadVaccQuinFromExcel.DataSource = dt;
            this.rpReadVaccQuinFromExcel.DataBind();
        }
        #endregion

        /// <summary>
        ///  GriView的顯示項
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = row.FindControl("lblGender") as Label;
                var dr = row.DataItem as DataRowView;
                int UserGender = dr.Row.Field<int>("Gender");
                switch (UserGender)
                {
                    case 0:
                        lbl.Text = "其他";
                        break;
                    case 1:
                        lbl.Text = "男性";
                        break;
                    case 2:
                        lbl.Text = "女性";
                        break;
                }
            }
        }
        /// <summary>
        /// List陣列轉型
        /// </summary>
        /// <param name="pf"></param>
        /// <returns></returns>
        public static Guid StringToGuid(string pf)
        {
            return Guid.Parse(pf);
        }

        protected void gvReadUserInfoFromExel_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        
    }
}