using DataFormatTransfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchAuth;

namespace VaccineMatchingSystem.BackEndPages.SystemAdminPages
{
    public partial class GetFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/FrontEndPages/Login.aspx");
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = ExcelDataManager.GetUserFeedback();

            this.GridViewFeedback.DataSource = dt;
            this.GridViewFeedback.DataBind();
        }

        protected void btnToExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = ExcelDataManager.GetUserFeedback();

            string outputPath = "C:\\TryExcelintoC#\\使用者回饋報表.xlsx";

            if (ExcelDataManager.DataTableToExcel(dt, outputPath))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('報表轉換成功!')</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('報表轉換失敗!')</script>");
            }
            Response.Redirect("LoginDefaultS.aspx");
        }
    }
}