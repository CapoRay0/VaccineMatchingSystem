using AlgorithmData;
using DataFormatTransfer;
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
    public partial class VaccineMatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            #region 宣告class
            //宣告使用者資訊
            UserInfo userInfo = new UserInfo();
            //宣告演算法參數
            AlgorithmParameter algP = new AlgorithmParameter();
            #endregion


            DataTable drWillingUser = MatchManager.WillingUsers("AZ"); // 要配對的疫苗名稱

            //Guid UserID = new Guid("85762993-9D61-4AAD-A960-80A15696628D"); // 取使用者的ID近來      

            int? VaccNumInBatch = 0;  //該批次疫苗的數量           *用的時候記得check is Null
            int batch = 1;  //疫苗批次號

            DataRow drVaccineInventory = MatchManager.VaccinePerBatch(batch); // 取得第 n 批疫苗的DataRow
            VaccNumInBatch = Convert.ToInt32(drVaccineInventory["Quantity"]);  //疫苗數量        

            #region 抓取演算法參數
            #region 抓取age相關資訊
            try
            {
                algP.age_direction = Convert.ToInt32(txt_age_direction.Text);
                algP.age_targetAgeButtom = Convert.ToInt32(txt_age_targetAgeButtom.Text);
                algP.age_targetAgeTop = Convert.ToInt32(txt_age_targetAgeTop.Text);

            }
            catch { }


            #endregion

            #region 抓取job相關資訊

            //宣告參數 (正式這邊應該從db抓到)
            algP.job_dict = new Dictionary<string, double>();
            algP.job_dict.Add("醫護人員", 2);
            algP.job_dict.Add("防疫人員", 1.9);
            algP.job_dict.Add("政府職員", 1.8);
            algP.job_dict.Add("航空從業者", 1.7);
            algP.job_dict.Add("長照", 1.6);
            algP.job_dict.Add("軍警", 1.5);
            algP.job_dict.Add("教師", 1.4);
            algP.job_dict.Add("學生", 1.3);
            algP.job_dict.Add("有職業其他", 1);
            algP.job_dict.Add("無職業", 0.8);
            #endregion

            #region 抓取state相關資訊

            algP.state_dict = new Dictionary<string, double>();
            algP.state_dict.Add("因公出國", 2);

            #endregion

            #region 抓取Ordinal 相關資訊
            try
            {

                algP.ordinal_dict = Convert.ToInt32(txt_ordinal.Text);
            }
            catch { }
            #endregion

            #region 抓取Area 相關資訊

            algP.area_area = txt_area.Text;
            #endregion
            #endregion

            #region 執行演算
            double result = 99;
            for (int i = 0; i < drWillingUser.Rows.Count; i++)
            {
                userInfo.Age = Convert.ToInt32(Convert.ToInt32(drWillingUser.Rows[i]["Age"]));
                userInfo.Job = drWillingUser.Rows[i]["Occupation"].ToString();
                string[] tempState = { drWillingUser.Rows[i]["Status"].ToString() };
                userInfo.Status = tempState;
                userInfo.Area = drWillingUser.Rows[i]["Area"].ToString();
                userInfo.DoseCount = Convert.ToInt32(drWillingUser.Rows[i]["DoseCount"]) - 1;
                result = AlgHelper.GetTotalScore(userInfo, algP);
                ltShow.Text += result.ToString();
                ltShow.Text += " ,\r\n";
            }
            //var result = AlgHelper.GetTotalScore(userInfo, algP);
            //ltShow.Text = result.ToString();
            #endregion
        }

        protected void btnGetVaccData_Click(object sender, EventArgs e)
        {
            DataTable ds = ExcelDataManager.GetCurrentVaccInfo();

            this.RepeaterShowVacc.DataSource = ds;
            this.RepeaterShowVacc.DataBind();
        }
    }
}


//while (true) // 無限迴圈
//{
//    DataRow drVaccineInventory = MatchManager.VaccinePerBatch(1); // 取得第 n 批疫苗數量

//    if (Convert.ToInt32(drVaccineInventory["Quantity"]) > 0) // 如果疫苗數量 > 0
//    {
//        // 如果 存在要配對的疫苗名稱，且存在 IsEffective = 1 (有配對需求)
//        if (!MatchManager.CheckWillingUserIsNull("AZ")) // 不是null > 代表存在 (bool)
//        {
//            DataRow drWUser = MatchManager.WillingUsers("AZ"); // 需要不斷刷新DataTable (待優化)
//            if (Convert.ToInt32(drWUser["IsEffective"]) == 1) // 如果有人正在排隊配對 (dr[0])
//            {
//                //string ResultName = drWUser["UserID"].ToString();
//                // 配對

//                MatchManager.TurnToNoEffective("AZ", UserID); // 將配對到的人消除

//                int Reduce = Convert.ToInt32(drVaccineInventory["Quantity"]);
//                Reduce -= 1;
//                MatchManager.QuantityReduce1(1, Reduce);
//            }
//        }
//        else break; // 如果沒人要配 (WillingRegister = null)
//    }
//    else break; // 疫苗沒了 (Quantity = 0)
//}