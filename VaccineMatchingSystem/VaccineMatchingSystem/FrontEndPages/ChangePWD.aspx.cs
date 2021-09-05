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
    public partial class ChangePWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!AuthManager.IsLogined())
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.lblMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            //如果沒有登入就回頭
            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            string inp_Account = txtAccount.Text;
            Guid userID = currentUser.UserID;
            string newPWD = txtNewPWD.Text;

            UserInfoManager.UpdatePwd(inp_Account, userID, newPWD);

            this.Session["UserLoginInfo"] = null;

            //Response.Redirect("Login.aspx");
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您的密碼已更改成功!')</script>");
        }

        /// <summary> 驗證使用者密碼更新(錯誤提示) </summary>
        /// <param name="errorMsgList"></param>
        /// <returns></returns>
        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            // 帳號 必填
            if (string.IsNullOrWhiteSpace(this.txtAccount.Text))
            {
                msgList.Add("請輸入帳號");
                errorMsgList = msgList;
                return false;
            }

            // 原密碼 必填
            if (string.IsNullOrWhiteSpace(this.txtOrigPWD.Text))
            {
                msgList.Add("請輸入原密碼");
                errorMsgList = msgList;
                return false;
            }

            // 新密碼 必填
            if (string.IsNullOrWhiteSpace(this.txtNewPWD.Text))
            {
                msgList.Add("請輸入新密碼");
                errorMsgList = msgList;
                return false;
            }

            // 確認新密碼 必填
            if (string.IsNullOrWhiteSpace(this.txtPWDconf.Text))
            {
                msgList.Add("請確認新密碼");
                errorMsgList = msgList;
                return false;
            }

            // 原密碼及新密碼不得相同
            if (string.Compare(txtOrigPWD.Text, txtNewPWD.Text, false) == 0)
            {
                msgList.Add("原密碼及新密碼不得相同");
                errorMsgList = msgList;
                return false;
            }

            // 新密碼及確認新密碼須為一致
            if (txtNewPWD.Text.Trim() != txtPWDconf.Text.Trim())
            {
                msgList.Add("請確認新密碼是否一致");
                errorMsgList = msgList;
                return false;
            }

            // 檢查帳號及原密碼是否存在
            string inp_Account = this.txtAccount.Text;
            string inp_PWD = this.txtOrigPWD.Text;

            if (UserInfoManager.CheckInfoIsCorrectForChangPWD(inp_Account, inp_PWD))
            {
                msgList.Add("請確認帳號及密碼是否正確");
                errorMsgList = msgList;
                return false;
            }

            errorMsgList = msgList;

            if (msgList.Count == 0)
                return true;
            else
                return false;
        }
    }
}