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


        protected void btnStartMatching_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMatchResult.aspx");
        }

        protected void btnToFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetFeedback.aspx");
        }

        protected void btnInsetUserInfo_Click(object sender, EventArgs e)
        {
            string UserInfopath = "C:\\VaccineExcel\\FirstTryUserInfo.xlsx";

            DataTable ds = ExcelDataManager.GetDataTableFromExcelFile(UserInfopath);

            ExcelDataManager.InsertUserInfoIntoSQL(ds);
        }

        protected void btnInsertVaccQuin_Click(object sender, EventArgs e)
        {
            string UserInfopath = "C:\\VaccineExcel\\VaccInventoryTest01.xlsx";

            DataTable dt = ExcelDataManager.GetDataTableFromExcelFile(UserInfopath);

            ExcelDataManager.InsertVaccQuantityIntoSQL(dt);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 好文
        }

        protected void btnGetUserInfo_Click(object sender, EventArgs e)
        {
            DataTable dt = UserInfoManager.GetGeneralUserInfo();

            this.GridUserInfo.DataSource = dt;
            this.GridUserInfo.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
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

        protected void btnGetVaccData_Click(object sender, EventArgs e)
        {
            DataTable ds = ExcelDataManager.GetCurrentVaccInfo();

            this.RepeaterShowVacc.DataSource = ds;
            this.RepeaterShowVacc.DataBind();
        }

        protected void btnSystemExit_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();
            Response.Redirect("/FrontEndPages/Default.aspx");
        }
    }
}