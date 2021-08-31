using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchAuth;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.BackEndPages.GeneralUserPages
{
    public partial class LoginDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/FrontEndPages/Login.aspx");
                    return;
                }

                var CurrentUser = AuthManager.GetCurrentUser();

                Guid CurrentUserGuid = CurrentUser.UserID;

                DataTable dt = UserInfoManager.GetUserInfoFor(CurrentUserGuid);

                this.GridViewCurrentUserInfo.DataSource = dt;
                this.GridViewCurrentUserInfo.DataBind();

                if (CurrentUser.Gender == 1)
                {
                    this.ltlTitleShow.Text = $"{CurrentUser.Name}先生，歡迎使用疫苗配對系統";
                }
                else if (CurrentUser.Gender == 2)
                {
                    this.ltlTitleShow.Text = $"{CurrentUser.Name}小姐，歡迎使用疫苗配對系統";
                }
            }
        }

        protected void btnSystemExit_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();
            Response.Redirect("/FrontEndPages/Default.aspx");
        }

        protected void btnYesDoes_Click(object sender, EventArgs e)
        {
            Response.Redirect("WillingVaccination.aspx");
        }

        protected void btnNoDose_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnWillingVaccination.aspx");
        }
    }
}