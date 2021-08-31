using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchAuth;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.FrontEndPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserLoginInfo"] != null)
            {
                string UserAccount = Request["UserLoginInfo"].ToString();
                int dr = UserInfoManager.GetAccountUserLevel(UserAccount);
                if (dr == 0)
                {
                    Response.Redirect("/Back End Pages/System Administrator/LoginDefault.aspx");
                }
                else
                {
                    Response.Redirect("/Back End Pages/GeneralUser/LoginDefault.aspx");
                }
            }
            //else
            //{
            //    if (!this.IsPostBack)
            //    {
            //        Response.Redirect("Default.aspx");
            //    }
            //    else
            //    {
            //        Page_Load(sender, e);
            //    }
            //}
        }

        protected void btnForgetPWD_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Back End Pages/GeneralUser/ChangePWD.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txtAccount.Text; // inp 為 input
            string inp_PWD = this.txtPWD.Text;
            string msg;
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out msg))
            {
                this.ltlMsg.Text = msg;
                return;
            }
            if (inp_Account == inp_PWD)
            {
                Response.Redirect("/Back End Pages/GeneralUser/ChangePWD.aspx");
            }
            else
            {
                var dr = UserInfoManager.GetAccountUserLevel(inp_Account);
                if (dr == 0)
                {
                    Response.Redirect("/Back End Pages/System Administrator/LoginDefault.aspx");
                }
                else
                {
                    Response.Redirect("/Back End Pages/GeneralUser/LoginDefault.aspx");
                }
            }
        }
    }
}