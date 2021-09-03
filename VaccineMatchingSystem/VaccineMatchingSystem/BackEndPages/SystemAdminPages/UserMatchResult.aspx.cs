using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.BackEndPages.SystemAdminPages
{
    public partial class UserMatchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //DataTable dt = MatchManager.GetWillingUser("AZ");

            //this.GridViewMatchResult.DataSource = dt;
            //this.GridViewMatchResult.DataBind();
        }

        protected void btnVaccineMatch_Click(object sender, EventArgs e)
        {
            Response.Redirect("VaccineMatch.aspx");
        }
    }
}