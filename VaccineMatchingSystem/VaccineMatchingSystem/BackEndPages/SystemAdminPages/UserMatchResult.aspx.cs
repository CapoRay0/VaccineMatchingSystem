using AlgorithmData;
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

        protected void btnCalculateScore_Click(object sender, EventArgs e)
        {
            DataTable dt = UserInfoManager.GetGeneralUserInfo();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List<string> UserGuidString = new List<string>();
                UserGuidString.Add(dt.Rows[i][0].ToString());
                List<Guid> UserGuidCollection = UserGuidString.ConvertAll(new Converter<string, Guid>(StringToGuid));
                UserInfo user = new UserInfo();
                //UserInfoModel user = new UserInfoModel();

                foreach (Guid gd in UserGuidCollection)
                {
                    DataRow dr = UserInfoManager.GetUserInfoByGuid(gd);

                    user.Name = dr["Name"].ToString();
                    user.Gender = Convert.ToInt32(dr["Gender"]);
                    user.Age = Convert.ToInt32(dr["Age"]);

                    user.Area = dr["Area"].ToString();
                    user.Job = dr["Occupation"].ToString();
                    string[] tempState = { dr["Status"].ToString() };
                    user.Status = tempState;
                    user.DoseCount = Convert.ToInt32(dr["DoseCount"]);

                    Dictionary<string, double> job_dict = new Dictionary<string, double>();
                    job_dict.Add("職業", 1);
                    AlgorithmParameter alg1 = new AlgorithmParameter()
                    { job_dict = job_dict, state_dict = job_dict };
                    var a = AlgHelper.GetTotalScore(user, alg1);
                    litShowScore.Text += a.ToString() + " + ";
                }
            };
        }

        public static Guid StringToGuid(string pf)
        {
            return Guid.Parse(pf);
        }
    }
}