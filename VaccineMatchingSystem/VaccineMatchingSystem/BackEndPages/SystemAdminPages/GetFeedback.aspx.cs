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
            //string thisFilePath = Server.MapPath("~/");
            //string outputPath = ExcelDataManager.GetUpLevelDirectory(thisFilePath, 2) + "\\Data\\ExcelFiles\\使用者回饋報表.xlsx";

            //取得機器+user name
            var loginAccount = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //取得機器名
            var machineName = Environment.MachineName;
            //讓loginAccount減去機器名
            loginAccount = loginAccount.Remove(0, machineName.Length + 1);
            string outputPath = $@"C:\Users\{loginAccount}\Downloads\使用者回饋報表.xlsx";


            if (ExcelDataManager.DataTableToExcel(dt, outputPath))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('報表轉換成功!')</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('報表轉換失敗!')</script>");
            }
        }

        protected void GridViewFeedback_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = row.FindControl("lblReasob") as Label;

                var dr = row.DataItem as DataRowView;
                int UserReason = dr.Row.Field<int>("Reason");

                switch (UserReason)
                {
                    case 0:
                        lbl.Text = "系統設計不友善";
                        break;
                    case 1:
                        lbl.Text = "疫苗種類過少";
                        break;
                    case 2:
                        lbl.Text = "基本資料有誤";
                        break;
                    case 3:
                        lbl.Text = "不知道如何使用系統";
                        break;
                    case 4:
                        lbl.Text = "其他原因";
                        break;
                }

                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl1 = row.FindControl("lblGetFeedbackorNot") as Label;

                    var dr1 = row.DataItem as DataRowView;
                    int UserFeedbackGet = dr1.Row.Field<int>("FeedbackGet");

                    switch (UserFeedbackGet)
                    {
                        case 0:
                            lbl1.Text = "願意收到";

                            break;
                        case 1:
                            lbl1.Text = "不願收到";
                            break;

                    }
                }
            }
        }
    }
}