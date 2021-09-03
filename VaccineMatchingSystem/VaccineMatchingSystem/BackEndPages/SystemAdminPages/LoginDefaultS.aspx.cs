using DataFormatTransfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.BackEndPages.SystemAdminPages
{
    public partial class LoginDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltlShowTotalUserNumb.Text = UserInfoManager.GetGeneralUserCount();
            this.ltlShowTotalAdminUserNumb.Text = UserInfoManager.GetSystemAdminCount();
            this.ltlWillingNumb.Text = UserInfoManager.GetWillingCount();
        }


        protected void btnStartMatching_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMatchResult.aspx");
        }

        protected void btnGetVaccData_Click(object sender, EventArgs e)
        {
            string path = "C:\\TryExcelintoC#\\VaccInventoryTest01.xlsx";


            DataTable ds = new DataTable();
            ds = ExcelDataManager.GetDataTableFromExcelFile(path);

            GridViewVaccInv.DataSource = ds;
            GridViewVaccInv.DataBind();
        }

        protected void btnToFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetFeedback.aspx");
        }
    }
}