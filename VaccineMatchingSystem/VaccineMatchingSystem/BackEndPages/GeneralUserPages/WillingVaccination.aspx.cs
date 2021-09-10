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
    public partial class WillingVaccination : System.Web.UI.Page
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


            if (CurrentUser.Gender == 1)
            {
                this.lblTitleShow.Text = $"{CurrentUser.Name}先生您好";
            }
            else if (CurrentUser.Gender == 2)
            {
                this.lblTitleShow.Text = $"{CurrentUser.Name}小姐您好";
            }


        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var CurrentUser = AuthManager.GetCurrentUser();
            Guid CurrentUserGuid = CurrentUser.UserID;

            if (!CheckBoxVaccAZ.Checked && !CheckBoxVaccMoz.Checked && !CheckBoxVaccBNT.Checked)
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('請點選願意施打的疫苗')</script>");

            if (AccountingManager.CheckWillingIfChecked(CurrentUserGuid))
            {
                if (CheckBoxVaccAZ.Checked)
                {
                    string VaccineAZ = "AZ";
                    AccountingManager.InsertUserWillingVaccin(CurrentUserGuid, VaccineAZ);
                }
                if (CheckBoxVaccMoz.Checked)
                {
                    string VaccineModerna = "Moderna";
                    AccountingManager.InsertUserWillingVaccin(CurrentUserGuid, VaccineModerna);
                }
                if (CheckBoxVaccBNT.Checked)
                {
                    string VaccineBNT = "BNT";
                    AccountingManager.InsertUserWillingVaccin(CurrentUserGuid, VaccineBNT);
                }
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('恭喜您，疫苗登記成功!!')</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('本批次已完成登記')</script>");
            }

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnWillingVaccination.aspx");
        }
    }
}