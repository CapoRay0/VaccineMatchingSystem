using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevloperCtrl;


namespace VaccineMatchingSystem.DeveloperPages
{
    public partial class Dev : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_addUsers_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;

            List<string> OccupationList = new List<string>() { "醫護人員", "政府職員", "航空從業者", "長照人員", "軍警" };
            List<string> StatusList = new List<string>() { "因公出國", "業務出國", "重大傷病" };
            List<string> VaccList = new List<string>() { "AZ", "BNT", "Modena" };
            int dbNum = DevCtrl.GetUserNumber();
            int add = Convert.ToInt32( txt_addUsers.Text);
            int Num = dbNum + add;

            for (int count = dbNum; count < Num; count++)
            {
                Guid userGuid = Guid.NewGuid();
                DevCtrl.AddNewUser(OccupationList, StatusList, userGuid, count);
                DevCtrl.AddNewWilling(userGuid, VaccList);
            }

            DateTime dateTime = DateTime.Now;
            var ans = (dateTime - startTime);
            this.lt_show.Text = "共花費 "+ ans.ToString() + " 秒";

        }

        /// <summary>
        /// 清空民眾與願望
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_clearDB_Click(object sender, EventArgs e)
        {
            DevCtrl.DELETE_FROM_UserInfo();
            DevCtrl.DELETE_FROM_WillingRegister();
        }

        /// <summary>
        /// 清空疫苗庫存，配對紀錄，演算法參數紀錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_clearDB2_Click(object sender, EventArgs e)
        {
            DevCtrl.DELETE_FROM_Algorithm();
            DevCtrl.DELETE_FROM_MatchingResultRecord();
            DevCtrl.DELETE_FROM_VaccineInventory();
            DevCtrl.UPDATE_WillingRegister_SET_IsEffectiveAs_1();
        }

        protected void btn_returnToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("/FrontEndPages/Login.aspx");
        }
    }
}