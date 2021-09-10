using DataFormatTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VaccineMatchingSystem.FrontEndPages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string thisFilePath = Server.MapPath("~/");   //取得自己.aspx的路徑
            string thisFilePathFather = ExcelDataManager.GetUpLevelDirectory(thisFilePath, 2) + "\\Data\\Logs\\";   //找上2層，Logs
            VaccineMatchDBSource.logger.logPath = thisFilePathFather + "Log.log";
        }

        protected void btnToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}