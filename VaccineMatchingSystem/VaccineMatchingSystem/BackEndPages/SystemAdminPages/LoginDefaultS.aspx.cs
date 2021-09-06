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

namespace VaccineMatchingSystem.BackEndPages.SystemAdminPages
{
    public partial class LoginDefault : System.Web.UI.Page
    {
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

        /// <summary>
        /// 匯入使用者資料    (把UserInfo的excel轉化為DT，並且輸入至DB)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsetUserInfo_Click(object sender, EventArgs e)
        {
            string UserInfopath = @"../ExcelFiles/FirstTryUserInfo.xlsx";
            //string UserInfopath = "C:\\TryExcelintoC#\\FirstTryUserInfo.xlsx";
            DataTable ds = ExcelDataManager.GetDataTableFromExcelFile(UserInfopath);
            ExcelDataManager.InsertUserInfoIntoSQL(ds);

        }

        /// <summary>
        /// 讀取匯入使用者的資料    (把DB裡面的UserInfo抓出，Bind到頁面)
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
        /// 匯入本批疫苗資料 (把VaccQuin的excel轉化為DT，並且輸入至DB)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsertVaccQuin_Click(object sender, EventArgs e)
        {
            string UserInfopath = @"..\ExcelFiles\VaccInventoryTest01.xlsx";
            //string UserInfopath = "C:\\TryExcelintoC#\\VaccInventoryTest01.xlsx";
            DataTable dt = ExcelDataManager.GetDataTableFromExcelFile(UserInfopath);
            ExcelDataManager.InsertVaccQuantityIntoSQL(dt);
        }


        /// <summary>
        /// 讀取匯入疫苗資料    (把DB裡面的VaccData抓出，Bind到頁面)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetVaccData_Click(object sender, EventArgs e)
        {
            DataTable ds = ExcelDataManager.GetCurrentVaccInfo();
            this.RepeaterShowVacc.DataSource = ds;
            this.RepeaterShowVacc.DataBind();
        }



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
                    case 1:
                        lbl.Text = "男性";

                        break;
                    case 2:
                        lbl.Text = "女性";
                        break;
                }
            }
        }

        protected void btnSystemExit_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();
            Response.Redirect("/FrontEndPages/Default.aspx");
        }

        public static Guid StringToGuid(string pf)
        {
            return Guid.Parse(pf);
        }

        /// <summary>
        /// 讀取本批次使用者資料(Excel>>C#)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReadUserInfo_Click(object sender, EventArgs e)
        {
            string thisFilePath = Server.MapPath("~/");   //取得自己.aspx的路徑
            string thisFilePathFather = ExcelDataManager.GetUpLevelDirectory(thisFilePath, 2) + "\\Data\\ExcelFiles\\";   //找上2層，找ExcelFiles
            string uploadedResult = ExcelDataManager.UploadExcel(this.fuUserInfoExcel, thisFilePathFather, "UserInfo");  //上傳excel，指定黨名頭=UserInfo
            string UserInfopath = thisFilePathFather + uploadedResult;     //找回excel檔的路徑
            DataTable dt = ExcelDataManager.GetDataTableFromExcelFile(UserInfopath);
            this.gvReadUserInfoFromExel.DataSource = dt;
            this.gvReadUserInfoFromExel.DataBind();
        }

        /// <summary>
        /// 讀取本批次疫苗資料(Excel>>C#)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReadVaccInfoThisBatch_Click(object sender, EventArgs e)
        {
            string thisFilePath = Server.MapPath("~/");   //取得自己.aspx的路徑
            string thisFilePathFather = ExcelDataManager.GetUpLevelDirectory(thisFilePath, 2) + "\\Data\\ExcelFiles\\";   //找上2層，找ExcelFiles
            string uploadedResult = ExcelDataManager.UploadExcel(this.fuVaccQuinExcel, thisFilePathFather, "VaccQuin");  //上傳excel，指定黨名頭=VaccQuin
            string UserInfopath = thisFilePathFather + uploadedResult;     //找回excel檔的路徑
            DataTable dt = ExcelDataManager.GetDataTableFromExcelFile(UserInfopath);
            this.rpReadVaccQuinFromExcel.DataSource = dt;
            this.rpReadVaccQuinFromExcel.DataBind();
        }


        /// <summary>
        /// 讀取匯入的本批次疫苗資料 (把SQL特定批次的疫苗資料抓到C#上，讓網頁顯示)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Click(object sender, EventArgs e)
        {

        }

        protected void gvReadUserInfoFromExel_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}