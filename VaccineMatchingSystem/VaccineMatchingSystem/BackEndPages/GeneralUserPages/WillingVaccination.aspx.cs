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
                this.ltlTitleShow.Text = $"{CurrentUser.Name}先生，歡迎使用疫苗配對系統";
            }
            else if (CurrentUser.Gender == 2)
            {
                this.ltlTitleShow.Text = $"{CurrentUser.Name}小姐，歡迎使用疫苗配對系統";
            }


        }

        protected void LinkVaccAZ_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.cdc.gov.tw/Category/MPage/epjWGimoqASwhAN8X-5Nlw");
        }

        protected void LinkVaccMoz_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.cdc.gov.tw/Category/MPage/epjWGimoqASwhAN8X-5Nlw");
        }

        protected void LinkVaccBNT_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.cdc.gov.tw/Category/MPage/epjWGimoqASwhAN8X-5Nlw");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var CurrentUser = AuthManager.GetCurrentUser();
            Guid CurrentUserGuid = CurrentUser.UserID;

            //List<string> VaccineYesRecord = new List<string>();

            //if 
            //{
            //    //this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('本批次已完成登記')</script>");
            //}
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
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('本批次已完成登記')</script>");
            }

            //Response.Redirect("LoginDefaultG.aspx");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnWillingVaccination.aspx");
        }
    }
}