using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchAuth;

using System.Data;
using VaccineMatchDBSource;
using System.Data.SqlClient;


namespace VaccineMatchingSystem.BackEndPages.GeneralUserPages
{
    public partial class VaccinationRecord : System.Web.UI.Page
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

            if (!MatchManager.CheckResultForGeneralUserIsNull(CurrentUserGuid))
            {
                DataTable dtResult = MatchManager.GetResultForGeneralUser(CurrentUserGuid);

                this.GridViewShowResult.DataSource = dtResult;
                this.GridViewShowResult.DataBind();
            }
            else
            {
                this.lblNoResult.Text = "尚未匹配到疫苗";
            }



            if (CurrentUser.Gender == 1)
            {
                this.lblTitleShow.Text = $"{CurrentUser.Name}先生您好";
            }
            else if (CurrentUser.Gender == 2)
            {
                this.lblTitleShow.Text = $"{CurrentUser.Name}小姐您好";
            }

        }


        
    }
}