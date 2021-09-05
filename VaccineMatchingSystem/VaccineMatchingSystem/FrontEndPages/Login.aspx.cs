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
            if (!Page.IsPostBack)//判斷頁面是不是第一次顯示
            {
                //this.lblCode.Text = RandomCode(5);

                Session.RemoveAll();
                txtAccount.Text = "";
                txtPWD.Text = "";
            }

        }

        protected void btnForgetPWD_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPWD.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txtAccount.Text; // inp 為 input
            string inp_PWD = this.txtPWD.Text;
            string msg;
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out msg))
            {
                this.lblMsg.Text = msg;
                return;
            }
            else
            {
                if (this.txtConfirmCode.Text.Trim() != Session["Verify"].ToString())
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('驗證碼不正確')</script>");
                    return;
                }
                else
                {
                    if (inp_Account == inp_PWD)
                    {
                        Response.Redirect("ChangePWD.aspx");
                    }
                    else
                    {
                        var dr = UserInfoManager.GetAccountUserLevel(inp_Account);
                        if (dr == 0)
                        {
                            Response.Redirect("/BackEndPages/SystemAdminPages/LoginDefaultS.aspx");
                        }
                        else
                        {
                            Response.Redirect("/BackEndPages/GeneralUserPages/LoginDefaultG.aspx");
                        }
                    }
                }
            }
        }

    }
}