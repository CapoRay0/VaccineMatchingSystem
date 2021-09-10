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

        /// <summary> 忘記密碼按鈕 </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnForgetPWD_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPWD.aspx");
        }

        /// <summary>
        /// 登入按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txtAccount.Text; // inp 為 input
            string inp_PWD = this.txtPWD.Text;
            string msg;

            //驗證是否為登入失敗，如果失敗回傳false
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out msg))
            {
                this.lblMsg.Text = msg;
                return;
            }

            //驗證驗證碼
            #region 開發時隱藏

            if (this.txtConfirmCode.Text.Trim() != Session["Verify"].ToString().Trim())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('驗證碼不正確，請確認內容及大小寫')</script>");
                return;
            }

            #endregion


            //如果帳號=密碼就是第一次登入，導向到更改密碼頁
            if (inp_Account == inp_PWD)
            {
                Response.Redirect("ChangePWD.aspx");
            }

            //如果閒置10分鐘則強制登出
            Session.Timeout = 10;

            //登入成功，根據使用者等級導向至不同頁面
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