using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.FrontEndPages
{
    public partial class ForgetPWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.lblMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            string inp_Name = this.txtName.Text;
            string inp_ID = this.txtID.Text;
            string NewPwd = this.txtNewPWD.Text;

            UserInfoManager.ChangePwd(inp_Name, inp_ID, NewPwd);


            //Response.Redirect("Login.aspx");
            //this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您的密碼已更改成功!')</script>");
            Response.Write("<Script language='JavaScript'>alert('您的密碼已更改成功!'); location.href='Login.aspx'; </Script>");
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            // 姓名 必填
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                msgList.Add("請輸入姓名");
                errorMsgList = msgList;
                return false;
            }

            // 身分證id 必填
            if (string.IsNullOrWhiteSpace(this.txtID.Text))
            {
                msgList.Add("請輸入身分證");
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


            // 新密碼及確認新密碼須為一致
            if (txtNewPWD.Text.Trim() != txtPWDconf.Text.Trim())
            {
                msgList.Add("請確認新密碼是否一致");
                errorMsgList = msgList;
                return false;
            }

            // 密碼長度限制 (8~16)
            if (this.txtNewPWD.Text.Length < 8 || this.txtNewPWD.Text.Length > 16)
            {
                msgList.Add("密碼長度限制 (需要8~16碼)");
                errorMsgList = msgList;
                return false;
            }

            // 檢查姓名及身分證是否存在
            string inp_Name = this.txtName.Text;
            string inp_ID = this.txtID.Text;
            
            if (!UserInfoManager.CheckInfoIsCorrectForForgotPWD(inp_Name, inp_ID))
            {
                msgList.Add("請確認姓名及身分是否正確");
                errorMsgList = msgList;
                return false;
            }


            errorMsgList = msgList;


            if (msgList.Count == 0)
                return true;
            else
                return false;
        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}