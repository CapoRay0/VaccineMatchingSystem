using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.BackEndPages.SystemAdminPages
{
    public partial class LoginDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltlShowTotalUserNumb.Text = UserInfoManager.GetGeneralUserCount();
            this.ltlShowTotalAdminUserNumb.Text = UserInfoManager.GetSystemAdminCount();
            this.ltlWillingNumb.Text = UserInfoManager.GetWillingCount();
        }
    }
}