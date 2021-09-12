using AlgorithmData;
using DataFormatTransfer;
using Newtonsoft.Json;
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
            #region 驗證ddlVaccName，可以刪
            //ddlVaccName.SelectedIndex = 0;
            //ddlVaccName.Items.Add("QWE");
            //var a = ddlVaccName.Items.FindByText("QWE");
            //string b = a.Text;
            #endregion

            Session["vaccName"] = null;
            Session["vaccNum"] = null;
            Session["vaccID"] = null;

            #region 抓取未匹配之疫苗by選擇疫苗名
            if (ddlVaccName.Items.Count == 1)
            {
                DataTable availableVacc = MatchManager.GetAvailableVaccName(0);
                foreach (DataRow item in availableVacc.Rows)
                {
                    ddlVaccName.Items.Add(item[0].ToString());
                }
            }
            #endregion

        }

        /// <summary>
        /// 計算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;

            #region 宣告class
            //宣告使用者資訊
            UserInfo userInfo = new UserInfo();
            //宣告演算法參數
            AlgorithmParameter algP = new AlgorithmParameter();
            #endregion
            Session["vaccName"] = ddlVaccName.SelectedValue;
            int vaccBatch = Convert.ToInt32(ddlVaccBatch.SelectedItem.Value);
            // 抓取疫苗ID、數量by選擇疫苗批次
            DataRow dataRow = MatchManager.GetVaccIDAndNumByBatch((string)Session["vaccName"], vaccBatch,0);
            Session["vaccNum"] = (int)dataRow[1];
            Session["vaccID"] = dataRow[0];

            string vaccName = ddlVaccName.SelectedValue;
            if (vaccName == "0") return;
            DataTable dtWillingUsers = MatchManager.WillingUsers(vaccName); // 要配對的人們
            int? VaccNumInBatch = (int?)Session["vaccNum"];  //該批次疫苗的數量           *用的時候記得check is Null
            int batch = Convert.ToInt32(ddlVaccBatch.SelectedItem.Value);  //疫苗ID


            #region 抓取演算法參數
            #region 抓取age相關資訊
            try
            {
                algP.age_direction = Convert.ToInt32(ddl_age_direction.SelectedValue);
                algP.age_targetAgeButtom = Convert.ToInt32(txt_age_targetAgeButtom.Text);
                algP.age_targetAgeTop = Convert.ToInt32(txt_age_targetAgeTop.Text);
            }
            catch (Exception ex)
            {
                var a = ex;
            }
            #endregion

            #region 抓取job相關資訊

            //宣告參數 (正式這邊應該從db抓到)
            algP.job_dict = new Dictionary<string, double>();
            //檢查每個欄位是否為空或未選擇權重
            if (!String.IsNullOrWhiteSpace(txt_JobInput1.Text) && ddl_JobWeightSelect1.SelectedIndex != 0)
                algP.job_dict.Add(txt_JobInput1.Text, Convert.ToDouble(ddl_JobWeightSelect1.SelectedValue));
            if (!String.IsNullOrWhiteSpace(txt_JobInput2.Text) && ddl_JobWeightSelect2.SelectedIndex != 0)
                algP.job_dict.Add(txt_JobInput2.Text, Convert.ToDouble(ddl_JobWeightSelect2.SelectedValue));
            if (!String.IsNullOrWhiteSpace(txt_JobInput3.Text) && ddl_JobWeightSelect3.SelectedIndex != 0)
                algP.job_dict.Add(txt_JobInput3.Text, Convert.ToDouble(ddl_JobWeightSelect3.SelectedValue));
            if (!String.IsNullOrWhiteSpace(txt_JobInput4.Text) && ddl_JobWeightSelect4.SelectedIndex != 0)
                algP.job_dict.Add(txt_JobInput4.Text, Convert.ToDouble(ddl_JobWeightSelect4.SelectedValue));
            if (!String.IsNullOrWhiteSpace(txt_JobInput5.Text) && ddl_JobWeightSelect5.SelectedIndex != 0)
                algP.job_dict.Add(txt_JobInput5.Text, Convert.ToDouble(ddl_JobWeightSelect5.SelectedValue));

            //algP.job_dict.Add("醫護人員", 2);
            //algP.job_dict.Add("防疫人員", 1.9);
            //algP.job_dict.Add("政府職員", 1.8);
            //algP.job_dict.Add("航空從業者", 1.7);
            //algP.job_dict.Add("長照", 1.6);
            //algP.job_dict.Add("軍警", 1.5);
            //algP.job_dict.Add("教師", 1.4);
            //algP.job_dict.Add("學生", 1.3);
            //algP.job_dict.Add("有職業其他", 1);
            //algP.job_dict.Add("無職業", 0.8);
            #endregion

            #region 抓取state相關資訊

            algP.state_dict = new Dictionary<string, double>();
            if (!String.IsNullOrWhiteSpace(txt_StateInput1.Text) && ddl_StateWeightSelect1.SelectedIndex != 0)
                algP.state_dict.Add(txt_StateInput1.Text, Convert.ToDouble(ddl_StateWeightSelect1.SelectedValue));
            if (!String.IsNullOrWhiteSpace(txt_StateInput2.Text) && ddl_StateWeightSelect2.SelectedIndex != 0)
                algP.state_dict.Add(txt_StateInput2.Text, Convert.ToDouble(ddl_StateWeightSelect2.SelectedValue));
            if (!String.IsNullOrWhiteSpace(txt_StateInput3.Text) && ddl_StateWeightSelect3.SelectedIndex != 0)
                algP.state_dict.Add(txt_StateInput3.Text, Convert.ToDouble(ddl_StateWeightSelect3.SelectedValue));
            if (!String.IsNullOrWhiteSpace(txt_StateInput4.Text) && ddl_StateWeightSelect4.SelectedIndex != 0)
                algP.state_dict.Add(txt_StateInput4.Text, Convert.ToDouble(ddl_StateWeightSelect4.SelectedValue));
            if (!String.IsNullOrWhiteSpace(txt_StateInput5.Text) && ddl_StateWeightSelect5.SelectedIndex != 0)
                algP.state_dict.Add(txt_StateInput5.Text, Convert.ToDouble(ddl_StateWeightSelect5.SelectedValue));
            //algP.state_dict.Add("因公出國", 2);

            #endregion

            #region 抓取Ordinal 相關資訊
            try
            {
                algP.ordinal_dict = Convert.ToInt32(ddl_ordinal.SelectedValue);
            }
            catch { }
            #endregion

            #region 抓取Area 相關資訊
            if (ddl_Country.Items.Count == 0)
            {
                lbShow.Text = "請輸入地區";
                return;
            }
            algP.area_area = ddl_Country.SelectedItem.Text;

            #endregion
            #endregion
            #region  將演算法insert進db

            #region JASON化
            string JobW = JsonConvert.SerializeObject(algP.job_dict);
            string StateW = JsonConvert.SerializeObject(algP.state_dict);
            #endregion
            //將演算法insert進db
            MatchManager.InsertAlgWeightListIntoDB((Guid)Session["vaccID"], algP.age_targetAgeButtom, algP.age_targetAgeTop, algP.age_direction,
                 JobW, StateW, algP.area_area, algP.ordinal_dict);
            #endregion

            #region 執行演算
            Dictionary<Guid, double> scoreDictionary = new Dictionary<Guid, double>();


            for (int i = 0; i < dtWillingUsers.Rows.Count; i++)
            {
                userInfo.Age = Convert.ToInt32(dtWillingUsers.Rows[i]["Age"]);
                userInfo.Job = dtWillingUsers.Rows[i]["Occupation"].ToString();
                string[] tempState = { dtWillingUsers.Rows[i]["Status"].ToString() };
                userInfo.Status = tempState;
                userInfo.Area = dtWillingUsers.Rows[i]["Area"].ToString();
                userInfo.DoseCount = Convert.ToInt32(dtWillingUsers.Rows[i]["DoseCount"]) - 1;
                //結果儲存
                scoreDictionary.Add((Guid)dtWillingUsers.Rows[i]["UserID"], AlgHelper.GetTotalScore(userInfo, algP));

            }

            #endregion

            //將眾人分數由高至低排序
            var lineupedScoreList = from entry in scoreDictionary orderby entry.Value descending select entry;

            int requestNum = (int)Session["vaccNum"]; //取前n個
            List<Guid> BaiDui = new List<Guid>();
            foreach (var item in lineupedScoreList)
            {
                BaiDui.Add(item.Key);
            }
            //查詢 本次的演算法流水號
            int AlgorithmID = MatchManager.GetAlgID((Guid)Session["vaccID"]);
            //更新匹配到的疫苗的願望狀態
            //Guid AA = (Guid)Session["vaccID"];
            MatchManager.SetVaccAsMatched((Guid)Session["vaccID"]);
            // 列出匹配到的人            
            for (var i = 0; i < requestNum; i++)
            {
                //if (i >= BaiDui.Count) return;
                if (i >= BaiDui.Count) break;
                //Console.WriteLine(BaiDui[i]);
                double peopleScore = scoreDictionary[BaiDui[i]];
                //查詢 該人的願望流水號
                int WillingID = MatchManager.GetWillingID(BaiDui[i]);
                //將該人的匹配結果儲存進db
                MatchManager.InsertMatchingResult(WillingID, AlgorithmID, i+1, BaiDui[i], (float)peopleScore, (string)Session["vaccName"]);
                //更新匹配到的人的願望狀態
                MatchManager.TurnToNoEffective((string)Session["vaccName"], BaiDui[i]);
            }

            //this.lbShow.Text = "OK";

            //Show處理時間
            DateTime dateTime = DateTime.Now;
            var timeSpan = (dateTime - startTime);
            Session["timeSpan"] = timeSpan.ToString();

            //return到目標
            Response.Redirect("UserMatchResult.aspx");

        }

        /// <summary>
        /// 抓取選中之疫苗名，show出批次選擇
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetVaccData_Click(object sender, EventArgs e)
        {
            //DataTable ds = ExcelDataManager.GetCurrentVaccInfo();
            //this.RepeaterShowVacc.DataSource = ds;
            //this.RepeaterShowVacc.DataBind();

            if (ddlVaccName.SelectedIndex != 0)
            {
                Session["vaccName"] = ddlVaccName.SelectedItem.Text;
                //以疫苗名抓取可匹配的疫苗批次
                DataTable availableVacc = MatchManager.GetAvailableVaccBatch((string)Session["vaccName"],0);
                int counter = 0;
                foreach (DataRow item in availableVacc.Rows)
                {
                    ddlVaccBatch.Items.Add("第" + item[0].ToString() + "批次");
                    ddlVaccBatch.Items[counter].Value = item[0].ToString();
                    counter++;
                }
                ddlVaccBatch.Visible = true;
                btnGetVaccData.Visible = true;
                btnGetVaccDataCancel.Visible = true;
                btnGetVaccName.Visible = false;
            }
        }


        protected void btnGetVaccDataCancel_Click(object sender, EventArgs e)
        {
            btnGetVaccData.Visible = true;
            Response.Redirect("VaccineMatch.aspx");
        }

        /// <summary>
        /// 查詢DB內的演算法參數，展開演算法參數填寫區
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetVaccData_Click1(object sender, EventArgs e)
        {
            Session["vaccName"] = ddlVaccName.SelectedItem.Text;
            int vaccBatch = Convert.ToInt32(ddlVaccBatch.SelectedItem.Value);
            // 抓取疫苗ID、數量by選擇疫苗批次
            DataRow dataRow = MatchManager.GetVaccIDAndNumByBatch((string)Session["vaccName"], vaccBatch,0);
            Session["vaccID"] = (Guid)dataRow[0];
            Session["vaccNum"] = (int)dataRow[1];
            //把得到的疫苗情報拿去查詢演算法參數
            DataRow AlgWeightList = MatchManager.GetAlgWeightList((Guid)dataRow[0]);

            if (AlgWeightList != null)  //如果DB中已經有資料
            {
                phAlgWeightList.Visible = true;
                return;
            }
            else
            {
                phAlgWeightList.Visible = true;
            }
            btnGetVaccData.Visible = false;

        }

        /// <summary>
        /// 選擇區域，找出縣市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAreaCheck_Click(object sender, EventArgs e)
        {
            if (ddl_Area.SelectedIndex == 0) return;
            var area = ddl_Area.SelectedItem.Text;
            switch (area)
            {
                case "北區":
                    ddl_Country.Items.Add("台北");
                    ddl_Country.Items.Add("新北");
                    ddl_Country.Items.Add("桃園");
                    ddl_Country.Items.Add("基隆");
                    ddl_Country.Items.Add("新竹");
                    ddl_Country.Items.Add("苗栗");
                    break;
                case "中區":
                    ddl_Country.Items.Add("台中");
                    ddl_Country.Items.Add("彰化");
                    ddl_Country.Items.Add("南投");
                    break;
                case "南區":
                    ddl_Country.Items.Add("雲林");
                    ddl_Country.Items.Add("嘉義");
                    ddl_Country.Items.Add("台南");
                    ddl_Country.Items.Add("高雄");
                    ddl_Country.Items.Add("屏東");
                    break;
                case "東區":
                    ddl_Country.Items.Add("宜蘭");
                    ddl_Country.Items.Add("花蓮");
                    ddl_Country.Items.Add("台東");
                    break;
                case "離島":
                    ddl_Country.Items.Add("離島");
                    break;
                default:
                    return;
            }
            ddl_Country.Visible = true;
            btn_AreaCheck.Visible = false;
            btn_AreaCancel.Visible = true;
            ddl_Area.Visible = false;
            btnCalculate.Visible = true;
        }

        /// <summary>
        /// 重新選擇縣市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAreaCancel_Click(object sender, EventArgs e)
        {
            ddl_Country.Items.Clear();
            ddl_Country.Visible = false;
            btn_AreaCheck.Visible = true;
            ddl_Area.SelectedIndex = 0;
            btn_AreaCancel.Visible = false;
            ddl_Area.Visible = true;
            btnCalculate.Visible = false;
        }



    }
}