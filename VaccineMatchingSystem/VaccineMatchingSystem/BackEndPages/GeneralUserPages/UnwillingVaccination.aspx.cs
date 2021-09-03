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

            var CurrentUser = AuthManager.GetCurrentUser();

            Guid CurrentUserGuid = CurrentUser.UserID;

            string inp_Name = txtName.Text;
            string inp_Email = txtName.Text;
            
            string ReasonText = RadioButtonList1.SelectedValue;
            int Reason = Convert.ToInt32(ReasonText); // 這裡還沒修好
            string Feedback = txtFeedback.InnerText;

            int RecSysUpdate;
            if (RBYesFeedback.Checked)
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
    }
}