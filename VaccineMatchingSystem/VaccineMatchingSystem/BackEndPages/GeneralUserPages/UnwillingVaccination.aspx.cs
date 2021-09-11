using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchAuth;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.BackEndPages.GeneralUserPages
{
    public partial class UnwillingVaccination1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/FrontEndPages/Login.aspx");
                return;
            }
            this.DropDownList1.SelectedIndex = 0;

            var CurrentUser = AuthManager.GetCurrentUser();
            this.txtName.Text = CurrentUser.Name;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            var CurrentUser = AuthManager.GetCurrentUser();

            Guid CurrentUserGuid = CurrentUser.UserID;


            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('請填入Email')</script>");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('請填入姓名')</script>");
                return;
            }

            string inp_Name = this.txtName.Text;
            string inp_Email = this.txtEmail.Text;
            string ReaseonText = this.DropDownList1.SelectedValue;
            int Reason = Convert.ToInt32(ReaseonText);

            string Feedback = this.txtFeedback.InnerText;

            int RecSysUpdate;
            if (this.RBYesFeedback.Checked)
            {
                RecSysUpdate = 0;
            }
            else
            {
                RecSysUpdate = 1;
            }

            DBHelper.InsertUserFeedback(CurrentUserGuid, inp_Name, inp_Email, Reason, Feedback, RecSysUpdate);
            Response.Redirect("/FrontEndPages/Default.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtEmail.Text = "";
            this.txtFeedback.InnerText = "";
        }
    }
}